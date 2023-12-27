using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.Config
{
    public class CategoryConfig:IEntityTypeConfiguration<Category>
    {
         public void Configure(EntityTypeBuilder<Category> builder)
        {
             builder.HasKey(p=>p.CategoryId);//Category ıd 
            //kelimesi yok ise manuel olarak haskey metodu ile ıd atanır.
            builder.Property(p=>p.CategoryName).IsRequired();//zorunlu veri olnasu gerektiği metod.
          
              builder.HasData(
                new Category(){ CategoryId=1,CategoryName="Book"},
                new Category(){ CategoryId=2,CategoryName="Electronic"}
              );  
        }
        
    }
}