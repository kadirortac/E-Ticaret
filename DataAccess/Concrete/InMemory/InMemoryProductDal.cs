using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products; // global değişkenler altçizgi ile başlar.(Genel kural)
        public InMemoryProductDal()
        {
            _products = new List<Product> {
            new Product{ProductId=1,CategoryId=1,ProductName="Bardak",UnitPrice=15,UnitsInStock=15 },
            new Product{ProductId=2,CategoryId=1,ProductName="Kamera",UnitPrice=500,UnitsInStock=3 },
            new Product{ProductId=3,CategoryId=2,ProductName="Telefon",UnitPrice=1500,UnitsInStock=2 },
            new Product{ProductId=4,CategoryId=2,ProductName="Klavye",UnitPrice=150,UnitsInStock=65 },
            new Product{ProductId=5,CategoryId=2,ProductName="Fare",UnitPrice=85,UnitsInStock=1 }






            };
        }
        public void Add(Product product)
        {
            _products.Add(product); 
        }

        // List yapısı referans tipli olduğu için direkt olarak product'ı sil diyemiyoruz çünkü bizim referans numarasına ihtiyacımız var.
        public void Delete(Product product) // lINQ yapısı ile( dile gömülü sorgulama ) liste bazlı yapıları aynı sql gibi filreleyebiliyoruz.
                                            // c# ' ın güçlü yanalrından biri de LINQ 'tir.         
        {
            Product deleteToProduct=null;
           /* foreach (var p in _products)
            {
                if (p.ProductId == product.ProductId)
                {
                    deleteToProduct = p; // fake productın referansını silinecek olanın referansına eşitledik.
                }
                _products.Remove(deleteToProduct);
           }
            */

            // üsttekini yapmak yerine LINQ yapısını kullanmak daha kolay. 
            deleteToProduct = _products.SingleOrDefault(p=>p.ProductId==product.ProductId);

            // foreach döngüsü yerine tek satırlık bu kodu yazarız.Daha sonra da deleteToProduct'ı sileriz.
            _products.Remove(deleteToProduct);
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> getAll()
        {

            return _products;
        }

        public List<Product> getAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Product> getAllByCategory(int categoryId)
        {
           return _products.Where(p => p.CategoryId == categoryId).ToList();
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Product product)
        {
            Product productToUpdate;

            productToUpdate = _products.FirstOrDefault(p=>p.ProductId==product.ProductId); // güncellenecek referans buluyoruz.

            productToUpdate.ProductName = product.ProductName; // aldığımız referans ile ürün ismini güncelledik.
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;
            productToUpdate.CategoryId = product.CategoryId;
        }
    }
}
