using Services.Contracts;

namespace Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categorService;

        public ServiceManager(IProductService productService, ICategoryService categorService)
        {
            _productService = productService;
            _categorService = categorService;
        }

        public IProductService ProductService =>_productService;

        public ICategoryService CategoryService => _categorService;
    }
}