using Entities.Dtos;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Services.Contracts;

namespace StoreApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController:Controller
    
    {
        private readonly IServiceManager _manager;

        public ProductController(IServiceManager manager)
        {
            _manager = manager;
        }

        public IActionResult Index()
        {
            var model =_manager.ProductService.GetAllProducts(false);
            return View(model);
        }
        public IActionResult Create()
        {
            ViewBag.Categories = GetCategoiesSelectList();
            
           //list oluşturuldu foreach ifadesine gerek kalmaz
            return View();
        }

        private SelectList GetCategoiesSelectList()
        {
            return new SelectList( _manager.CategoryService.GetAllCategories(false)
            ,"CategoryId","CategoryName","1");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([FromForm] ProductDtoForInsertion productDto)
        {
            if(ModelState.IsValid)
            {
            _manager.ProductService.CreateProduct(productDto);
            return RedirectToAction("Index");
            }
            return View();
          
        }
         [HttpPost]
         [ValidateAntiForgeryToken]
         public IActionResult Update([FromForm]ProductDtoForUpdate productDto)
         {
            if(ModelState.IsValid){
            _manager.ProductService.UpdateOneProduct(productDto);
             return RedirectToAction("Index");
            }
             return View();
            
         }

// aşağıda routtan gelen değer alınır.
        [HttpGet]
        public IActionResult Update([FromRoute(Name ="id")]int id)
         {
            ViewBag.Categories = GetCategoiesSelectList();
            var model =_manager.ProductService.GetOneProductForUpdate(id,false);
            return View(model);
         }

        [HttpGet]
         public IActionResult Delete([FromRoute(Name ="id")] int id)
         {
           
            _manager.ProductService.DeleteOneProduct(id);
            return RedirectToAction("Index");
         }
    }
}