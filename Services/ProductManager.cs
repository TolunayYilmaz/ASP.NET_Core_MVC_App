using AutoMapper;
using Entities.Dtos;
using Entities.Models;
using Repositories;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{ //Product servis katmanı oluşturuldu
    public class ProductManager : IProductService
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;

        public ProductManager(IRepositoryManager manager,IMapper mapper)
        {
            _manager = manager;
            _mapper=mapper; 
        }

        public void CreateProduct(ProductDtoForInsertion productDto)
        {
            // Product product = new Product()
            // {
            //     ProductName=productDto.ProductName,
            //     Price=productDto.Price,
            //     CategoryId=productDto.CategoryId
            // };
            // yukarıdaki işlemi mapper ile yapabiliriz aşşağıda 
            Product product=_mapper.Map<Product>(productDto);
            _manager.Product.CreateOneProduct(product);
            _manager.Save();
        }

        public void DeleteOneProduct(int id)
        {
           Product product= _manager.Product.GetOneProduct(id,false);
           if(product is not null)
           {
            _manager.Product.DeleteOneProduct(product);
            _manager.Save();
           }
         
        }

        public IEnumerable<Product> GetAllProducts(bool trackChanges)
        {
            return _manager.Product.GetAllProducts(trackChanges);
        }

        public Product? GetOneProduct(int id, bool trackChanges)
        {
            var product=_manager.Product.GetOneProduct(id,trackChanges);
            if(product is null)
            {
             throw new Exception("Product is not found");
            }
            return product;

        }

        public ProductDtoForUpdate? GetOneProductForUpdate(int id, bool trackChanges)
        {
            var product =GetOneProduct(id,trackChanges);
            var productDto =_mapper.Map<ProductDtoForUpdate>(product);
            return productDto;

        }

        public void UpdateOneProduct(ProductDtoForUpdate productDto)
        {
            //var entity =_manager.Product.GetOneProduct(productDto.ProductId,true);
            // entity.ProductName=productDto.ProductName;
            // entity.Price=productDto.Price;
            // entity.CategoryId=productDto.CategoryId;
            var entity =_mapper.Map<Product>(productDto);
            _manager.Product.UpdateOneProduct(entity);
            _manager.Save();
            
        }
    }

}

