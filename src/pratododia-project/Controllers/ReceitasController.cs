using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pratododia_project.Models;
using pratododia_project.ViewModels;
using System.Security.Claims;

namespace pratododia_project.Controllers

{
    [Authorize]
    public class ReceitasController : Controller
    {
        private readonly IWebHostEnvironment _webHost;
        private readonly AppDbContext _context;

        public ReceitasController(AppDbContext context, IWebHostEnvironment webHost)
        {
            _context = context;
            _webHost = webHost;
        }

        // Create GET
        public async Task<IActionResult> Create()
        {
            var ViewModel = new ReceitaIngredienteViewModel
            {
                Ingredientes = await _context.Ingredientes.ToListAsync(),
                IngredientesSelecionados = new List<IngredienteViewModel>()
            };

            return View(ViewModel);
        }

        // Create POST
        [HttpPost]
        public async Task<IActionResult> Create(ReceitaIngredienteViewModel model, IFormFile file)
        {
            if (!ModelState.IsValid)
            {
                model.Ingredientes = await _context.Ingredientes.ToListAsync();
                return View(model);
            }

            model.IngredientesSelecionados ??= new List<IngredienteViewModel>();

            var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);
            int userId = int.Parse(userIdString);

            string imagensFolder = Path.Combine(_webHost.WebRootPath, "ImagensReceitas");

            if (!Directory.Exists(imagensFolder))
            {
                Directory.CreateDirectory(imagensFolder);
            }

            string fileName;

            if (file != null && file.Length > 0)
            {
                fileName = Path.GetFileName(file.FileName);
                string fileSavePath = Path.Combine(imagensFolder, fileName);

                using (FileStream stream = new FileStream(fileSavePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                model.CaminhoImg = Path.Combine("ImagensReceitas", fileName);
            }

            else
            {
                model.CaminhoImg = Path.Combine("img", "semImagem.png");
            }

            var receita = new Receita
            {
                IdUsuario = userId,
                DataPublicacao = DateTime.Now,
                CaminhoImg = model.CaminhoImg,
                NomeReceita = model.NomeReceita,
                Descricao = model.Descricao,
                TempoPreparo = model.TempoPreparo,
                Dificuldade = model.Dificuldade,
                Rendimento = model.Rendimento,
                Categoria = model.Categoria,
                Passos = model.Passos
            };

            _context.Add(receita);
            await _context.SaveChangesAsync(); // Salva a receita e gera o ID

            // Associe os ingredientes à receita
            foreach (var ingredienteVm in model.IngredientesSelecionados)
            {
                // Verifique se o IdIngrediente está preenchido
                if (ingredienteVm.IdIngrediente > 0 && ingredienteVm.Quantidade > 0)
                {
                    var ingredienteReceita = new IngredienteReceita
                    {
                        IdReceita = receita.IdReceita,
                        IdIngrediente = ingredienteVm.IdIngrediente,
                        Quantidade = ingredienteVm.Quantidade,
                        Tipo = ingredienteVm.Tipo
                    };

                    _context.Add(ingredienteReceita);
                }

                else
                {
                    model.Ingredientes = await _context.Ingredientes.ToListAsync();
                    return View(model);
                }
            }

            await _context.SaveChangesAsync(); // Salva a lista de ingredientes associada à receita
            return RedirectToAction("Details", new { id = receita.IdReceita });

        }

        // Details GET
        [AllowAnonymous]
        [HttpGet("Receitas/Details/{id:int}")]
        public async Task<IActionResult> Details(int id)
        {
            Receita receita = await _context.Receitas
           .Include(r => r.Usuario)
           .Include(r => r.Comentarios)
               .ThenInclude(c => c.Usuario)
            .Include(r => r.Comentarios)
               .ThenInclude(c => c.RespostasComentario)
               .ThenInclude(rc => rc.Usuario)
            .FirstOrDefaultAsync(r => r.IdReceita == id);

            var ingredientes = await _context.IngredientesReceitas
                                            .Where(i => i.IdReceita == id)
                                            .Include(i => i.Ingrediente)
                                            .ToListAsync();
            if (receita == null)
            {
                return NotFound();
            }
            // Acessos++
            receita.Acessos++;
            await _context.SaveChangesAsync();

            var userId = User.Identity.IsAuthenticated ? User.FindFirstValue(ClaimTypes.NameIdentifier) : null;
            int parsedUserId;
            var usuario = (userId != null) ? await _context.Usuarios.FirstOrDefaultAsync(user => user.IdUsuario == int.Parse(userId)) : null;
            var Passos = receita.Passos.ToList();
            var receitasmaisvistas = await _context.Receitas.OrderByDescending(r => r.Acessos).Take(10).ToListAsync();
            var receitasmaiscomentadas = await _context.Receitas.Select(r => new { Receita = r, nComments = _context.Comentarios.Count(c => c.IdReceita == r.IdReceita) }).OrderByDescending(r => r.nComments).Take(10).Select(r => r.Receita).ToListAsync();
            var receitasmaisavaliadas = await _context.Receitas.OrderByDescending(r => r.Avaliacao).Take(10).ToListAsync();

            var viewModel = new ReceitaVM
            {
                Usuario = usuario,
                Receita = receita,
                eSalva = false,
                Passo = Passos,
                Ingredientes = ingredientes,
                Comentarios = receita.Comentarios.ToList(),
                ReceitaMaisComentadas = receitasmaiscomentadas,
                ReceitaMaisVistas = receitasmaisvistas,
                ReceitaMaisAvaliadas = receitasmaisavaliadas
            };

            if (userId != null && int.TryParse(userId, out parsedUserId))
            {
                var tryRate = await _context.RatedRecipes.FirstOrDefaultAsync(ra => ra.IdReceita == id && ra.IdUsuario == parsedUserId);
                viewModel.MinhaNota = tryRate == null ? 0 : tryRate.Nota;
                viewModel.eSalva = _context.SavedRecipes.Any(s => s.IdReceita == receita.IdReceita && s.IdUsuario == int.Parse(userId));
            }
            else
            {
                viewModel.MinhaNota = 0;
            }
            return View(viewModel);
        }

        // Edit GET
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            // User
            var getUserId = User.Identity.IsAuthenticated ? User.FindFirstValue(ClaimTypes.NameIdentifier) : null;
            int userId = 0;
            if (getUserId != null && !int.TryParse(getUserId, out userId))
            {
                return Unauthorized();  // Caso o ID não seja um número válido
            }

            if (id == null)
            {
                return NotFound();
            }

            // Recipe
            var receita = await _context.Receitas
                .Include(r => r.IngredientesReceitas)
                .ThenInclude(ir => ir.Ingrediente)
                .FirstOrDefaultAsync(r => r.IdReceita == id);

            if (receita == null || userId != receita.IdUsuario)
            {
                var user = await _context.Usuarios.FirstOrDefaultAsync(u => u.IdUsuario == userId);
                if (user == null || !user.IsAdmin)
                {
                    return NotFound();
                }
            }
            // Selected Ing Id's
            var selectedIngredientIds = _context.IngredientesReceitas
                .Where(ir => ir.IdReceita == id)
                .Select(ir => ir.IdIngrediente)
                .ToList();

            // Selected Ingredients
            var ingredientesselecionados = _context.IngredientesReceitas
                .Where(ir => ir.IdReceita == id)
                .Select(ir => new IngredienteViewModel
                {
                    IdIngrediente = ir.IdIngrediente,
                    Quantidade = ir.Quantidade,
                    Tipo = ir.Tipo,
                    Nome = ir.Ingrediente.Nome
                })
                .ToList();

            // Avaliable Ingredients
            var ingredients = await _context.Ingredientes
                .Where(i => !selectedIngredientIds.Contains(i.IdIngrediente))
                .OrderBy(i => i.Nome)
                .ToListAsync();

            //ViewModel
            var ViewModel = new ReceitaIngredienteViewModel
            {
                CaminhoImg = receita.CaminhoImg,
                NomeReceita = receita.NomeReceita,
                Descricao = receita.Descricao,
                TempoPreparo = receita.TempoPreparo,
                Rendimento = receita.Rendimento,
                Categoria = receita.Categoria,
                Passos = receita.Passos,
                Ingredientes = ingredients,
                IngredientesSelecionados = ingredientesselecionados
            };

            return View(ViewModel);
        }

        // Edit POST
        [HttpPost]
        public async Task<IActionResult> Edit(int id, ReceitaIngredienteViewModel model, IFormFile file)
        {
            model.Ingredientes = await _context.Ingredientes.ToListAsync();

            var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);
            int userId = int.Parse(userIdString);

            var prevRecipe = await _context.Receitas.FirstOrDefaultAsync(r => r.IdReceita == id);
            if (prevRecipe == null || prevRecipe.IdReceita != id)
            {
                return NotFound();
            }

            // Utilize a instância carregada (prevRecipe)
            prevRecipe.NomeReceita = model.NomeReceita;
            prevRecipe.CaminhoImg = model.CaminhoImg;
            prevRecipe.Dificuldade = model.Dificuldade;
            prevRecipe.Descricao = model.Descricao;
            prevRecipe.TempoPreparo = model.TempoPreparo;
            prevRecipe.Rendimento = model.Rendimento;
            prevRecipe.Categoria = model.Categoria;
            prevRecipe.Passos = model.Passos;
            prevRecipe.DataPublicacao = DateTime.Now;

            // Imagem
            string imgsFolder = Path.Combine(_webHost.WebRootPath, "ImagensReceitas");
            if (file != null && file.Length > 0)
            {
                string fileName = Path.GetFileName(file.FileName);
                string fileSavePath = Path.Combine(imgsFolder, fileName);

                if (!Directory.Exists(imgsFolder))
                {
                    Directory.CreateDirectory(imgsFolder);
                }

                using (FileStream stream = new FileStream(fileSavePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                prevRecipe.CaminhoImg = Path.Combine("ImagensReceitas", fileName);
            }

            if (ModelState.IsValid)
            {
                var ingredientesReceitasExistentes = _context.IngredientesReceitas.Where(ir => ir.IdReceita == id);
                _context.IngredientesReceitas.RemoveRange(ingredientesReceitasExistentes);

                model.IngredientesSelecionados ??= new List<IngredienteViewModel>();

                if (model.IngredientesSelecionados == null || model.IngredientesSelecionados.Count == 0)
                {
                    ModelState.AddModelError("IngredientesSelecionados", "É necessário selecionar ao menos um ingrediente.");
                    return View(model);
                }
                // Associe os ingredientes à receita
                foreach (var ingredienteVm in model.IngredientesSelecionados)
                {
                    // Verifique se o IdIngrediente está preenchido
                    if (ingredienteVm.IdIngrediente > 0 && ingredienteVm.Quantidade > 0)
                    {
                        var ingredienteReceita = new IngredienteReceita
                        {
                            IdReceita = id,
                            IdIngrediente = ingredienteVm.IdIngrediente,
                            Quantidade = ingredienteVm.Quantidade,
                            Tipo = ingredienteVm.Tipo
                        };

                        _context.Add(ingredienteReceita);
                    }

                    else
                    {
                        model.Ingredientes = await _context.Ingredientes.ToListAsync();
                        return View(model);
                    }

                }

                await _context.SaveChangesAsync();
                return RedirectToAction("Details", new { id = prevRecipe.IdReceita });
            }
            return View(model);
        }


        // Delete POST

        [HttpPost]
        public async Task<IActionResult> DeletarReceita(int id, string returnPage)
        {
            var receita = await _context.Receitas.FindAsync(id);
            if (receita == null)
            {
                return NotFound();
            }

            _context.Receitas.Remove(receita);
            await _context.SaveChangesAsync();

            string path = HttpContext.Request.Path;

            return RedirectToAction("MinhasReceitas");
        }

        // Other Actions
        public async Task<IActionResult> Search(string searchString)
        {
            var ingredientes = await _context.Ingredientes.Where(ing => string.IsNullOrEmpty(searchString) || ing.Nome.Contains(searchString)).ToListAsync();

            return PartialView("_IngredienteFilter", ingredientes);
        }

        [HttpPost]
        public async Task<IActionResult> SaveRecipe(int idReceita)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var receitaSalva = await _context.SavedRecipes
                .FirstOrDefaultAsync(rs => rs.IdReceita == idReceita && rs.IdUsuario.ToString() == userId);

            if (receitaSalva != null)
            {
                _context.SavedRecipes.Remove(receitaSalva);
                await _context.SaveChangesAsync();
                return Json(new { success = true, action = "removed" });
            }
            else
            {
                var novaReceitaSalva = new SavedRecipe
                {
                    IdUsuario = int.Parse(userId),
                    IdReceita = idReceita
                };

                await _context.SavedRecipes.AddAsync(novaReceitaSalva);
                await _context.SaveChangesAsync();
                return Json(new { success = true, action = "saved" });
            }
        }

        [HttpPost]
        public async Task<IActionResult> RateRecipe(int idReceita, int rateValue)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var receita = await _context.Receitas.FirstOrDefaultAsync(r => r.IdReceita == idReceita);

            if (receita == null || userId == null)
            {
                return NotFound();
            };

            var wasRated = await _context.RatedRecipes
                .FirstOrDefaultAsync(ra => ra.IdReceita == idReceita && ra.IdUsuario == int.Parse(userId));

            if (wasRated == null)
            {
                var novaReceitaAvaliada = new RatedRecipe
                {
                    IdReceita = idReceita,
                    IdUsuario = int.Parse(userId),
                    Nota = rateValue
                };
                await _context.RatedRecipes.AddAsync(novaReceitaAvaliada);
            }
            else
            {
                wasRated.Nota = rateValue;
            }
            await _context.SaveChangesAsync();

            // Recalcula a média da avaliação da receita
            var ratings = await _context.RatedRecipes.Where(a => a.IdReceita == idReceita).ToListAsync();
            receita.Avaliacao = (float)ratings.Average(a => a.Nota);

            await _context.SaveChangesAsync();

            return Json(new { success = true, action = wasRated != null ? "atualizarNota" : "salvarNota" });
        }

        [HttpPost]
        public async Task<IActionResult> PlanRecipe(int idReceita, DateTime data)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var receita = await _context.Receitas.FirstOrDefaultAsync(r => r.IdReceita == idReceita);


            if (receita == null || userId == null)
            {
                return NotFound();
            };

            var wasPlanned = await _context.PlannedRecipes.FirstOrDefaultAsync(p => p.IdReceita == idReceita && p.IdUsuario == int.Parse(userId));

            if (wasPlanned == null)
            {
                var NewPlannedRecipe = new PlannedRecipe
                {
                    IdUsuario = int.Parse(userId),
                    IdReceita = idReceita,
                    dataPreparo = data
                };
                await _context.PlannedRecipes.AddAsync(NewPlannedRecipe);
            }
            else
            {
                wasPlanned.dataPreparo = data;
            }
            await _context.SaveChangesAsync();

            return RedirectToAction("MinhasReceitas");

        }

        [HttpPost]
        public async Task<IActionResult> DeletarPlanRecipe(int idReceita, DateTime data)
        {
            var plannedReceita = await _context.PlannedRecipes
                   .FirstOrDefaultAsync(pr => pr.IdReceita == idReceita && pr.dataPreparo.Date == data.Date);
            if (plannedReceita == null)
            {
                return NotFound();
            }

            _context.PlannedRecipes.Remove(plannedReceita);
            await _context.SaveChangesAsync();

            return RedirectToAction("MinhasReceitas");
        }

        [HttpGet]
        public IActionResult FilterRecipeDate(DateTime data)
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var plannedRecipes = _context.PlannedRecipes
                .Where(pr => pr.dataPreparo.Date == data.Date && pr.IdUsuario == userId)
                .ToList();

            if (!plannedRecipes.Any())
            {
                return Json(new { mensagem = "Nenhuma receita planejada para esta data." });
            }

            var receitas = _context.Receitas
                .Where(r => plannedRecipes.Select(pr => pr.IdReceita).Contains(r.IdReceita))
                .ToList();

            return Json(receitas.Select(r => new
            {
                r.NomeReceita,
                r.CaminhoImg,
                r.IdReceita
            }));
        }

        [HttpGet]
        public async Task<IActionResult> MinhasReceitas()
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var receitascriadas = await _context.Receitas.Where(receita => receita.IdUsuario == userId).ToListAsync();
            var receitassalvas = await _context.SavedRecipes.Where(rs => rs.IdUsuario == userId).Include(rs => rs.Receita).ToListAsync();
            var receitasplanejadas = await _context.PlannedRecipes.Where(rp => rp.IdUsuario == userId).Select(rp => rp.dataPreparo.Date).ToListAsync();

            var model = new MinhasReceitasVM
            {
                ReceitasCriadas = receitascriadas,
                ReceitasSalvas = receitassalvas,
                ReceitasPlanejadas = receitasplanejadas
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddComment(int idReceita, string texto)
        {
            var userId = User.Identity.IsAuthenticated ? User.FindFirstValue(ClaimTypes.NameIdentifier) : null;

            if (userId != null && !string.IsNullOrEmpty(texto))
            {
                var comentario = new Comentario
                {
                    IdReceita = idReceita,
                    IdUsuario = int.Parse(userId),
                    Texto = texto,
                    DataComentario = DateTime.Now,
                    NumCurtidas = 0,
                    RespostasComentario = new List<RespostaComentario>()
                };

                _context.Comentarios.Add(comentario);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Details", new { id = idReceita });
        }

        [HttpPost]
        public async Task<IActionResult> DeleteComment(int id, int idReceita)
        {
            var comment = _context.Comentarios.FirstOrDefault(c => c.IdComentário == id);

            if (comment == null)
            {
                return NotFound();
            }
            var respostas = _context.RespostasComentario.FirstOrDefault(r => r.IdComentario == id);
            if (respostas != null)
            {
                _context.RespostasComentario.Remove(respostas);
            }
            var receita = _context.Receitas.FirstOrDefault(r => r.IdReceita == idReceita);

            _context.Comentarios.Remove(comment);

            await _context.SaveChangesAsync();

            return RedirectToAction("Details", new { id = receita.IdReceita });
        }

        [HttpPost]
        public async Task<IActionResult> AddRespostaComentario(int idReceita, int idComentario, string texto)
        {
            var userId = User.Identity.IsAuthenticated ? User.FindFirstValue(ClaimTypes.NameIdentifier) : null;

            if (userId != null && !string.IsNullOrEmpty(texto))
            {
                var respostaComentario = new RespostaComentario
                {
                    IdComentario = idComentario,
                    IdUsuario = int.Parse(userId),
                    Texto = texto,
                    DataResposta = DateTime.Now
                };

                _context.RespostasComentario.Add(respostaComentario);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Details", new { id = idReceita });
        }

        [HttpPost]
        public async Task<IActionResult> DeleteRespostaComentario(int id, int idReceita)
        {
            var respostas = _context.RespostasComentario.FirstOrDefault(r => r.IdResposta == id);
            if (respostas == null)
            {
                return NotFound();
            }
            var receita = _context.Receitas.FirstOrDefault(r => r.IdReceita == idReceita);

            _context.RespostasComentario.Remove(respostas);

            await _context.SaveChangesAsync();

            return RedirectToAction("Details", new { id = receita.IdReceita });
        }
    }
}
