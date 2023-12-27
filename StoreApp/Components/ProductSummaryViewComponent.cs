using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace StoreApp.Components
{
    public class ProductSummaryViewComponent:ViewComponent
    {
        private readonly  IServiceManager _manager;

        public ProductSummaryViewComponent(IServiceManager manager)
        {
            _manager = manager;
        }

        public string Invoke()
        {
            //service katmanından çekilmeliidr 
            //çünkü kurala bağlı veri alınmalıdır.
            return _manager.ProductService.GetAllProducts(false).Count().ToString();
        }
    }
    
}