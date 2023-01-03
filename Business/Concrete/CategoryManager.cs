using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {

        ICategoryDal _categoryDal; // İş sınıfımızdan veri erişim katmanına gitmemiz ve oradaki methodları kullanarak veri çekmemiz lazım.Bunun için Category tablomuza ait interface'i kullanarak gevşek bağımlı yapıyoruz.(inMemory,ef vs )

        public CategoryManager(ICategoryDal categoryDal){

            _categoryDal= categoryDal;                     
        }

        public IResult Add(Category category)
        {
            _categoryDal.Add(category);

            return new SuccessResult("başarılı");
        }

        public IDataResult<List<Category>> getAll()
        {
           return new SuccessDataResult<List<Category>>(_categoryDal.getAll(),"başarılı");
        }

        public IDataResult<Category> getById(int id)
        {
            return new SuccessDataResult<Category>(_categoryDal.Get(c=>c.CategoryId==id),"başarılı");
        }

        public IDataResult<Category> getByName(String name)
        {
            return new SuccessDataResult<Category>(_categoryDal.Get(c=>c.CategoryName==name),"başarılı");
        }

        
    }
}
