using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SGIMVC.Models.DTO;
using SGIMVC.Repository;
using SGIMVC.Repository.Interfaces;
using SGIMVC.Utilities;

namespace SGIMVC.Controllers
{
    public class ProductosController : Controller
    {
        private readonly IProductoRepository _productoRepository;

        public ProductosController(IProductoRepository productoRepository)
        {
            this._productoRepository = productoRepository;
        }
        [HttpGet]
        // GET: ProductController
        public ActionResult Index()
        {
            return View(new ProductoDTO() { });
        }

        public async Task<IActionResult> GetAllProducts()
        {
            try
            {
                //Llama al repositorio
                var data = await _productoRepository.GetAllAsync(UrlResources.UrlBase + UrlResources.UrlProducto);
                return Json(new { data });
            }
            catch (Exception ex)
            {
                // Log the exception, handle it, or return an error message as needed
                return StatusCode(500, "Internal Server Error. Please try again later.");
            }
        }


        // GET: ProductoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProductoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
