using Core.DataAccess;
using Entities.Concrete;
using Entities.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    // product nesnem ile yani tablomla ilgili yapacağım veritabanı işlemlerinin operasyonlarını(ekle,sil,güncelle) tutan bir interface.
    public interface IProductDal :IEntityRepository<Product>
    {

        List<ProductDetailDto> GetProductDetails();

    }
}
