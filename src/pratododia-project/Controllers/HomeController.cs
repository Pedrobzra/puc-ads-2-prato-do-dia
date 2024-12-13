using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pratododia_project.Models;
using pratododia_project.ViewModels;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;

namespace pratododia_project.Controllers
{
    [AllowAnonymous]
    public class HomeController(AppDbContext context) : Controller
    {
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public async Task<IActionResult> Index([FromQuery] string? categoria, [FromQuery] string? nomeReceita, bool? status)
        {
            var receitas = context.Receitas.AsQueryable();
            var userId = User.Identity.IsAuthenticated ? int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)) : (int?)null;

            // Filtro por Ingredientes Ocultos do Usuário
            if (userId.HasValue)
            {
                var ingredientesOcultosIds = context.UsuarioIngredientes
                    .Where(ui => ui.IdUsuario == userId && ui.Status == true)
                    .Select(ui => ui.IdIngrediente)
                    .ToList();

                if (ingredientesOcultosIds.Any())
                {
                    receitas = receitas.Where(r => !r.IngredientesReceitas
                        .Any(ir => ingredientesOcultosIds.Contains(ir.IdIngrediente)));
                }
            }

            // Filtro por Categoria
            if (!string.IsNullOrEmpty(categoria))
            {
                if (Enum.TryParse<TipoReceita>(categoria, true, out var categoriaEnum))
                {
                    receitas = receitas.Where(r => r.Categoria == categoriaEnum);
                }
            }

            // Filtro por Nome da Receita
            if (!string.IsNullOrWhiteSpace(nomeReceita))
            {
                receitas = receitas.Where(r => r.NomeReceita.Contains(nomeReceita));
            }

            // Converte para Lista
            var listaReceitas = await receitas.ToListAsync();

            // Verifica se é uma requisição AJAX
            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                return PartialView("_RecipesMenu", listaReceitas);
            }

            // Carrega dados adicionais para a View
            var tipoReceitas = Enum.GetValues(typeof(TipoReceita)).Cast<TipoReceita>().ToList();
            var categorias = Enum.GetValues(typeof(TipoIngrediente)).Cast<TipoIngrediente>().ToList();
            var ingredientes = await context.Ingredientes.ToListAsync();
            var viewModel = new IngredienteReceitaHomeViewModel
            {
                Receitas = listaReceitas,
                Ingredientes = ingredientes,
                Categorias = categorias,
                TipoReceitas = tipoReceitas
            };

            return View(viewModel);
        }
        public class IngredientesRequest
        {
            public string[] ListaIngredientes { get; set; }
        }

        [HttpPost]
        public IActionResult Index([FromBody] IngredientesRequest request, bool? status)
        {
            var receitas = context.Receitas.AsQueryable();
            var userId = User.Identity.IsAuthenticated ? int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)) : (int?)null;

            if (userId.HasValue)
            {
                var ingredientesOcultosIds = context.UsuarioIngredientes
                    .Where(ui => ui.IdUsuario == userId && ui.Status == true)
                    .Select(ui => ui.IdIngrediente)
                    .ToList();

                if (ingredientesOcultosIds.Any())
                {
                    receitas = receitas.Where(r => !r.IngredientesReceitas
                        .Any(ir => ingredientesOcultosIds.Contains(ir.IdIngrediente)));
                }
            }

            if (request?.ListaIngredientes == null || request.ListaIngredientes.Length == 0)
            {
                return PartialView("_RecipesMenu", receitas);
            }

            var idIngredientes = context.Ingredientes.Where(ing => request.ListaIngredientes.Contains(ing.Nome)).Select(ing => ing.IdIngrediente).ToList();
            var idReceitas = context.IngredientesReceitas.Where(ir => idIngredientes.Contains(ir.IdIngrediente)).Select(ir => ir.IdReceita).ToList();
            var receitasFiltradas = receitas.Where(r => idReceitas.Contains(r.IdReceita)).ToList();

            return PartialView("_RecipesMenu", receitasFiltradas);
        }


        [HttpPost]
        public async Task<IActionResult> Create(Ingrediente ingrediente)
        {
            if (Request.Form["RestricoesSelecionadas"].Any())
            {
                foreach (var restricao in Request.Form["RestricoesSelecionadas"])
                {
                    ingrediente.Restricao |= Enum.Parse<TipoRestricao>(restricao);
                }
            }
            context.Add(ingrediente);
            await context.SaveChangesAsync();

            var referer = Request.Headers["Referer"].ToString();
            if (!string.IsNullOrEmpty(referer))
            {
                return Redirect(referer);
            }


            return Redirect("/");
        }

        public async Task<IActionResult> ListIngredient()
        {
            var ingredientes = await context.Ingredientes.ToListAsync();
            return View(ingredientes);
        }

        
        public async Task<IActionResult> Delete(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var ingrediente = await context.Ingredientes.FindAsync(id);
            if (ingrediente == null)
            {
                return NotFound();
            }

            return View(ingrediente);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ingrediente = await context.Ingredientes.FindAsync(id);
            if (ingrediente != null)
            {
                context.Ingredientes.Remove(ingrediente);
            }

            await context.SaveChangesAsync();
            return RedirectToAction("ListIngredient");
        }
    }
}
