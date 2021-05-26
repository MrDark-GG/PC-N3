using Microsoft.AspNetCore.Mvc;
using PC_N3.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PC_N3.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly ProductoContext _context;
        public CategoriaController(ProductoContext context){
            _context = context;
        }
        public IActionResult Categorias(){
            var categoria = _context.Categorias.Include(x => x.Producto).OrderBy(r => r.Id).ToList();
            return View(categoria);
        }

        public IActionResult NuevaCategoria(){
            return View();
        }

        [HttpPost]
        public IActionResult NuevaCategoria(Categoria c){
            if(ModelState.IsValid){
                _context.Add (c);
                _context.SaveChanges();
                return RedirectToAction("Categorias");
            }
            return View(c);
        }

        [HttpPost]
        public IActionResult BorrarCategoria(int id){
           
            var categoria= _context.Categorias.Find(id);
            _context.Remove(categoria);
            _context.SaveChanges();

            return RedirectToAction("Categorias");
        }
    }
}