using Repositories.Contracts;

namespace Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _context;
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

        public RepositoryManager(IProductRepository productRepository, RepositoryContext context,ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _context=context;
            _categoryRepository=categoryRepository;
            //Yukarıdakileri Ioc Kaydı yapılmaz ise hata verir .
            //IoC kaydı program.cs builder bölümüdür.
        }

        public IProductRepository Product => _productRepository;

        public ICategoryRepository Category => _categoryRepository;

        public void Save()
        {
            _context.SaveChanges();
        }
        //Managerla bütün repolara erişmek istiyoruz
        //Bağımlılıkların hepsini IoC çözecek
        //Manager Kaydetme işlemi için context entegre edildi.
        
    }
}