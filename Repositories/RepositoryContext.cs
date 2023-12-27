

using System.Reflection;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Config;

namespace Repositories
{

public class RepositoryContext:DbContext
    {
     public DbSet<Product> Products { get; set; }
     public DbSet<Category> Categories { get; set; }

     //constructer sayesinde connection ouşur defaultta Dependency Incejtion patterni uygulanır.
    public RepositoryContext(DbContextOptions<RepositoryContext> options) :base(options)
    {
    
    }
   
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            #region  Model Confige Taşındı
            // modelBuilder.Entity<Product>()
            // .HasData(
            //     new Product() {ProductId =1, CategoryId=2, ProductName="Computer",Price=17_000},
            //     new Product() {ProductId =2, CategoryId=2, ProductName="Keyboard",Price=1_000},
            //     new Product() {ProductId =3, CategoryId=2, ProductName="Mouse",Price=500},
            //     new Product() {ProductId =4, CategoryId=2, ProductName="Monitor",Price=7_000},
            //     new Product() {ProductId =5, CategoryId=2, ProductName="Deck",Price=1_500},
            //     new Product() {ProductId =6, CategoryId=1, ProductName="History",Price=25},
            //     new Product() {ProductId =7, CategoryId=1, ProductName="Hamlet",Price=45}
            // );
           #endregion
            #region CategoryModelConfigeTaşındı 
            // modelBuilder.Entity<Category>()
            // .HasData(
                
            //     new Category(){ CategoryId=1,CategoryName="Book"},
            //     new Category(){ CategoryId=2,CategoryName="Electronic"}

            // );
            #endregion
        
            //Config doyasını entegre etme
            // modelBuilder.ApplyConfiguration(new ProductConfig());
            // modelBuilder.ApplyConfiguration(new CategoryConfig());
            //Yukarıdaki tipleri tek tek yazmak yerine dinamik olaak aşşağıda otomatik çözer.
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

    }





}
 
