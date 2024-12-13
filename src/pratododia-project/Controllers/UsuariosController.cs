using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BCrypt.Net;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using pratododia_project.Models;
using pratododia_project.ViewModels;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace pratododia_project.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly IWebHostEnvironment _webHost;
        private readonly AppDbContext _context;

        public UsuariosController(AppDbContext context, IWebHostEnvironment webHost)
        {
            _context = context;
            _webHost = webHost;
        }

        //CRUD
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdUsuario,NomeUsuario,Email,Senha,IsAdmin")] Usuario usuario)
        {
            if (ModelState.IsValid && !_context.Usuarios.Any(user => user.Email == usuario.Email))
            {
                usuario.Senha = BCrypt.Net.BCrypt.HashPassword(usuario.Senha);
                usuario.CaminhoImg = Path.Combine("img", "usuarioDefault.jpg");
                _context.Add(usuario);
                await _context.SaveChangesAsync();

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, usuario.NomeUsuario),
                    new Claim(ClaimTypes.Email, usuario.Email),
                    new Claim(ClaimTypes.NameIdentifier, usuario.IdUsuario.ToString()),
                    new Claim(ClaimTypes.Role, usuario.IsAdmin.ToString()),
                };
                var usuarioIdentity = new ClaimsIdentity(claims, "login");
                ClaimsPrincipal principal = new ClaimsPrincipal(usuarioIdentity);

                var props = new AuthenticationProperties
                {
                    AllowRefresh = true,
                    ExpiresUtc = DateTime.UtcNow.ToLocalTime().AddHours(8),
                    IsPersistent = true
                };

                await HttpContext.SignInAsync(principal, props);

                return RedirectToAction("Index", "Home");
            }
            ViewBag.Message = "Email já cadastrado!";
            return View();
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Usuarios.ToListAsync());
        }

        public async Task<IActionResult> Edit(UsuarioIngredienteViewModel model)
        {
            var userId = User.Identity.IsAuthenticated ? User.FindFirstValue(ClaimTypes.NameIdentifier) : null;
            int userIdInt = 0;
            if (!string.IsNullOrEmpty(userId) && int.TryParse(userId, out userIdInt))
            {
                var usuario = await _context.Usuarios.FindAsync(userIdInt);
                var ingredientes = await _context.Ingredientes.ToListAsync();
                var usuarioIngredientes = await _context.UsuarioIngredientes.Where(ui => ui.IdUsuario == userIdInt).ToListAsync();
                usuario.Senha = BCrypt.Net.BCrypt.HashPassword(usuario.Senha);

                var viewModel = new UsuarioIngredienteViewModel
                {
                    Usuario = usuario,
                    Ingredientes = ingredientes,
                    UsuarioIngrediente = usuarioIngredientes
                };
                return View("Profile", viewModel);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Usuario usuario, IFormFile file)
        {

            string imagensFolder = Path.Combine(_webHost.WebRootPath, "ImagensUsuarios");

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
                usuario.CaminhoImg = Path.Combine("ImagensUsuarios", fileName);
            }

            if (ModelState.IsValid)
            {
                usuario.Senha = BCrypt.Net.BCrypt.HashPassword(usuario.Senha);
                _context.Update(usuario);
                await _context.SaveChangesAsync();
                return RedirectToAction("Profile", new { edit = false });

            }

            var ingredientes = await _context.Ingredientes.ToListAsync();
            var usuarioIngredientes = await _context.UsuarioIngredientes.Where(ui => ui.IdUsuario == usuario.IdUsuario).ToListAsync();

            var viewModel = new UsuarioIngredienteViewModel
            {
                Usuario = usuario,
                Ingredientes = ingredientes,
                UsuarioIngrediente = usuarioIngredientes
            };
            ViewBag.Edit = true;

            return View("Profile", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ProfilePic(IFormFile file)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var usuario = await _context.Usuarios.FindAsync(int.Parse(userId));

            string imagensFolder = Path.Combine(_webHost.WebRootPath, "ImagensUsuarios");

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
                usuario.CaminhoImg = Path.Combine("ImagensUsuarios", fileName);
            }

                _context.Update(usuario);
                await _context.SaveChangesAsync();
                return RedirectToAction("Profile");
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(m => m.IdUsuario == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario != null)
            {
                _context.Usuarios.Remove(usuario);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        //Methods for Profile.cshtml
        public IActionResult Profile(UsuarioIngredienteViewModel model, bool edit = false)
        {
            var userId = User.Identity.IsAuthenticated ? User.FindFirstValue(ClaimTypes.NameIdentifier) : null;
            int userIdInt = 0;
            if (!string.IsNullOrEmpty(userId) && int.TryParse(userId, out userIdInt))
            {
                var usuario = _context.Usuarios.Include(u => u.UsuarioIngredientes).ThenInclude(ui => ui.Ingrediente).FirstOrDefault(u => u.IdUsuario == userIdInt);

                var viewModel = new UsuarioIngredienteViewModel
                {
                    Usuario = usuario,
                    Ingredientes = _context.Ingredientes.ToList(),
                    UsuarioIngrediente = usuario.UsuarioIngredientes.ToList()
                };

                ViewBag.Edit = edit;
                return View(viewModel);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> AtualizarStatusIngrediente(int idIngrediente, bool ocultar)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!int.TryParse(userId, out var userIdInt)) return NotFound();

            var usuarioIngrediente = await _context.UsuarioIngredientes.FirstOrDefaultAsync(usuarioIng => usuarioIng.IdUsuario == userIdInt && usuarioIng.IdIngrediente == idIngrediente);

            if (usuarioIngrediente == null)
            {
                usuarioIngrediente = new UsuarioIngrediente
                {
                    IdUsuario = userIdInt,
                    IdIngrediente = idIngrediente,
                    Status = ocultar
                };
                await _context.UsuarioIngredientes.AddAsync(usuarioIngrediente);
            }
            else
            {
                usuarioIngrediente.Status = ocultar;
                _context.UsuarioIngredientes.Update(usuarioIngrediente);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction("Profile");
        }

        [HttpPost]
        public async Task<IActionResult> AtualizarStatusRestricao(int restricaoSelecionada)
        {

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!int.TryParse(userId, out var userIdInt)) return NotFound();

            var restricoesSelecionadas = (TipoRestricao)restricaoSelecionada;

            var ingredientesRestricao = await _context.Ingredientes.Where(ing => (ing.Restricao & restricoesSelecionadas) != 0).ToListAsync();


            foreach (var ingrediente in ingredientesRestricao)
            {
                var usuarioIngrediente = await _context.UsuarioIngredientes.FirstOrDefaultAsync(ui => ui.IdUsuario == userIdInt && ui.IdIngrediente == ingrediente.IdIngrediente);

                if (usuarioIngrediente == null)
                {
                    usuarioIngrediente = new UsuarioIngrediente
                    {
                        IdUsuario = userIdInt,
                        IdIngrediente = ingrediente.IdIngrediente,
                        Status = true
                    };
                    await _context.UsuarioIngredientes.AddAsync(usuarioIngrediente);
                }
                else
                {
                    usuarioIngrediente.Status = true;
                    _context.UsuarioIngredientes.Update(usuarioIngrediente);
                }
            }

            await _context.SaveChangesAsync();
            return RedirectToAction("Profile");
        }

        [HttpPost]
        public async Task<IActionResult> LimparIngredientesOcultos()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!int.TryParse(userId, out var userIdInt)) return NotFound();

            var ingredientesOcultos = await _context.UsuarioIngredientes
                .Where(ui => ui.IdUsuario == userIdInt && ui.Status == true)
                .ToListAsync();

            foreach (var usuarioIngrediente in ingredientesOcultos)
            {
                usuarioIngrediente.Status = false;
            }

            _context.UsuarioIngredientes.UpdateRange(ingredientesOcultos);
            await _context.SaveChangesAsync();

            return RedirectToAction("Profile");
        }

        //Auth
        [HttpPost]
        public async Task<IActionResult> Login(Usuario usuario)
        {
            var data = await _context.Usuarios
        .FirstOrDefaultAsync(user => user.Email == usuario.Email);


            if (data == null)
            {
                ViewBag.Message = "Usuário e/ou senha inválidos!";
                return View();
            }

            bool senhaValida = BCrypt.Net.BCrypt.Verify(usuario.Senha, data.Senha);

            if (senhaValida)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, data.NomeUsuario),
                    new Claim(ClaimTypes.Email, data.Email),
                    new Claim(ClaimTypes.NameIdentifier, data.IdUsuario.ToString()),
                    new Claim(ClaimTypes.Role, data.IsAdmin.ToString()),
                };
                var usuarioIdentity = new ClaimsIdentity(claims, "login");
                ClaimsPrincipal principal = new ClaimsPrincipal(usuarioIdentity);

                var props = new AuthenticationProperties
                {
                    AllowRefresh = true,
                    ExpiresUtc = DateTime.UtcNow.ToLocalTime().AddHours(8),
                    IsPersistent = true
                };

                await HttpContext.SignInAsync(principal, props);

                return Redirect("/");
            }
            else
            {
                ViewBag.Message = "Usuário e/ou senha inválidos!";
                return View();
            }
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();

            return RedirectToAction("Login", "Usuarios");
        }

        //Views
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        private bool UsuarioExists(int id)
        {
            return _context.Usuarios.Any(e => e.IdUsuario == id);
        }
    }
}
