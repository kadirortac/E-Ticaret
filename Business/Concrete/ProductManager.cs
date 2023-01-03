using Business.Abstract;
using Business.Constans;
using Business.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validations;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTO_s;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {

        IProductDal _productDal;
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }
       
        public IResult Add(Product product)
        {
            
            // loglama
            //cacheremove
            //performans          Bunun gibi işlemlerin her biri aynı validationda olduğu gibi tek satır kaplasa dahi
            //transaction         çorba olacak burası.Onun yerin Add methodunun üstüne [Validate] gibi bir kullanımla 
            //authorization       bu işi çok daha şık bir şekilde yapabiliriz.
            _productDal.Add(product);

            return new SuccessResult(Messages.ProductAdded);
        }

        public IDataResult<List<Product>> getAll()
        {
            // iş kodları

            return new SuccessDataResult<List<Product>>(_productDal.getAll(),"başarılı");
            // eğer iş kodlarından geçerse data access katmanındaki operasyonlara erişebiliriz.
           // iş kodlarından geçtiği için data access katmanındaki getAll methodunu çalıştırdık.
        }

        public IDataResult<List<Product>> getAllByCategoryId(int Id)
        {

            return new SuccessDataResult<List<Product>>(_productDal.getAll(p => p.CategoryId == Id),"başarılı");
        }

        public IDataResult<Product> getById(int id)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId == id), "ürün geldi");
        }

        public IDataResult<List<Product>> getByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_productDal.getAll(p => p.UnitPrice >= min && p.UnitPrice <= max),"başarılı");
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails(),"başarılı");
        }

      
    }
}
