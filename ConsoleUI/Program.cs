using Business.Concrete;
using DataAccess.Concrete.InMemory;
using DataAccess.Concrete.EntityFramework;

namespace ConsoleUI
{

   public class Program
    {

       static void Main(string[] args)
        {
              ProductTest();

           // CategoryTest();
        }

        private static void CategoryTest()
        {
            CategoryManager categoryManager = new CategoryManager(new EFCategoryDal());
            foreach (var category in categoryManager.getAll())
            {
                Console.WriteLine(category.CategoryName);
            }
        }

        private static void ProductTest()
        {
            ProductManager productManager = new ProductManager(new EFProductDal());
            var result = productManager.GetProductDetails();
            if (result.Success == true)
            {
                foreach (var product in result.data)

                {
                    Console.WriteLine(product.ProductName + " // " + product.CategoryName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
          
        }
    }





}
