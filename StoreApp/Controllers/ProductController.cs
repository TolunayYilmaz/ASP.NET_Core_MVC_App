
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using Entities.Models;
using Repositories;
using Repositories.Contracts;
using Services.Contracts;

namespace StoreApp.Controllers
{
    public class ProductController:Controller
    {
        // public readonly RepositoryContext _context;
        // //constructer sayesinde connection ouşur defaultta Dependency Incejtion patterni uygulanır.
        // public ProductController(RepositoryContext context)
        // {
        //     _context = context;
        // }
        //Araya katman eklenmediği için yukarıdaki kod satırında direkt
        //database ulaşılılıyordu ve kod esnekliği saplanmıyordu

        //bağımlılıkalrı aşşağıdaki nesneyi çağarar çözeriz.
        // private readonly IRepositoryManager _manager;

        // public ProductController(IRepositoryManager manager)
        // {
        //     _manager = manager;
        // }
        //Yukarıdaki repository yerine Service manager tarafından yeni katman il çözümlenmesini istiyoruz.

        private readonly IServiceManager _manager;

        public ProductController(IServiceManager manager)
        {
            _manager = manager;
        }

        public IActionResult Index()
        {
            // var context = new RepositoryContext(
                
            //     new DbContextOptionsBuilder<RepositoryContext>()
            //     .UseSqlite("DataSource = C:\\Users\\Tolunay\\Desktop\\MVC\\ProductDb.db")
            //     .Options
            //     );

            // var model=_context.Products.ToList();
            var model=_manager.ProductService.GetAllProducts(false);

            return View(model);

        }

        // eşleşmelerin daha doğru gerçekleşmesi için FromRoute attribute kullanıldı.
        public IActionResult Get([FromRoute(Name ="id")] int id)
        {
            // Product product = _context.Products.First(p=>p.ProductId.Equals(id));
            // return View(product);
            var model =_manager.ProductService.GetOneProduct(id,false);
            return View(model);
        }
    }
}