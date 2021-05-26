using Microsoft.AspNetCore.Mvc;
using PC_N3.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PC_N3.Controllers
{
    public class ProductoController : Controller
    {
        private readonly ProductoContext _context;
        public ProductoController(ProductoContext context) {
            _context = context;
        }
        // listar producto
        public IActionResult Producto(){
            var productos = _context.Productos.Include(x => x.Categoria).OrderBy(r =>r.Id).ToList();
            return View(productos);
        }

        public IActionResult NuevoProducto(){
            ViewBag.categoria =  _context.Categorias.ToList().Select(r => new SelectListItem(r.NombreCategoria, r.Id.ToString()));
            return View();
        }


        //Editar
        public IActionResult EditarProducto(int id){
            var producto = _context.Productos.Find(id);
            return View(producto);
        }

        [HttpPost]
        public IActionResult EditarProducto(Producto r){
            if(ModelState.IsValid){
                var producto = _context.Productos.Find(r.Id);
                producto.NombreProducto =r.NombreProducto;
                producto.Foto =r.Foto;
                producto.Descripcion =r.Descripcion;
                producto.Precio =r.Precio;
                producto.Celular =r.Celular;
                producto.LugarCompra =r.LugarCompra;
                producto.NombreComprador =r.NombreComprador;
                producto.CategoriaID =r.CategoriaID;
                
                _context.SaveChanges();
                return RedirectToAction("EditarProductoConfirmacion");
            }
            return View(r);
        }
        public IActionResult EditarProductoConfirmacion(){
            return View();
        }

        public IActionResult NuevaProducto(){
            return View();
        }

        [HttpPost]
        public IActionResult NuevoProducto(Producto r){
            if(ModelState.IsValid){
                _context.Add(r);
                _context.SaveChanges();
                return RedirectToAction("NuevoProductoConfirmacion");
            }
            return View(r);
        }
        public IActionResult NuevoProductoConfirmacion(){
            return View();
        }
        [HttpPost]
        public IActionResult BorrarProducto(int id){
            var producto = _context.Productos.Find(id);
            _context.Remove(producto);
            _context.SaveChanges();
            return RedirectToAction("Productos");
        }

    }
}