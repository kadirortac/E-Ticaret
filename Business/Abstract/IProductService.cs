using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
   public interface IProductService
    {
        IDataResult < List<Product> > getAll();
        IDataResult<List<Product>> getAllByCategoryId(int Id);
        IDataResult<List<Product>> getByUnitPrice(decimal min,decimal max);
        IDataResult< List<ProductDetailDto> > GetProductDetails();
        IDataResult<Product> getById(int id);
        IResult Add(Product product);
    }
}
