using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    /* EntityFramework, veritabanında oluşturduğun product,category,manager gibi tabloları, bizim IEntity'e bağlı 
product,category,manager gibi nesnelerimizle ilişkilenirmemizi sağlayacak.
Bunun için bir context dediğimiz yapıyı kurmalıyız.Context demek: veritabanı ile kendi classlarımızı 
ilişkilendirdiğimiz classtır.
    Tabi bu class'ın bir context sınıf olduğunu bildirmemiz lazım.Bunun için ef'den gelen bir base sınıfı kullanacağız.
    onun adı da DbContext.
 */
    public class NorthwindContext:DbContext
    {
        // Aşağıdaki methodta,senin projen ile ilişkilendirilecek veritabanını belirtiyoruz.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=NorthWind;Trusted_Connection=true");
            

        }
        // DbSet ile hangi nesnemiz veritabanındaki hangi tabloya karşılık gelecek onu belirtiyoruz.
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }    



    }
}
