using System.ComponentModel.DataAnnotations;
using Entities.Models;

namespace Entities.Dtos
{   public record ProductDto
    {
        //veri oluştuktan sonra verinin değişmemsesi için set olan yerşleri init yapıldı.
         public int ProductId { get; init; }
       [Required(ErrorMessage ="Product Name is required.")]
        public String? ProductName { get; init; }=String.Empty;
       [Required(ErrorMessage ="Price is required.")]
        public decimal Price { get; init; }

        public int? CategoryId {get;init;}//Foreign Key

    }
    
}