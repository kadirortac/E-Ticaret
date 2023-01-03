using Core.DataAccess;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity,TContext>:IEntityRepository<TEntity>
        where TEntity : class,IEntity,new()
        where TContext: DbContext,new()
    {
        public void Add(TEntity entity)
        {
            /* IDisposable pattern:
             c#'a özel bir yapı !: Siz normalde bir sınıfı newlediğinizde,
            garbageCollector sadece belli zaman aralıklarında gelir ve onu bellekten atar.
            Ama using ile biz bir sınıfı newleyip kullandıktan sonra hemen gc gelir ve bellekten atar.
            Bu yapıya ihtiyaç var çünkü context sınıfların newlenmesi maaliyetlidir. 
           */
            using (TContext context = new TContext())
            {

                var addedEntity = context.Entry(entity); // eklemek istediğimiz entity'nin referansını aldık.
                addedEntity.State = EntityState.Added; // entity'mizin durumunu(state) eklenecek olarak belirttik.
                context.SaveChanges();// yapılan işlemleri kaydet.

            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter) // tek data getirecek method.
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);

            }
        }

        public List<TEntity> getAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                return filter == null    // ternary kullanımı.(if else gibi)
                    ? context.Set<TEntity>().ToList()
                    : context.Set<TEntity>().Where(filter).ToList();
                // ? yanındaki  select * from products kodundan başka bişey değil,en sonunda list e çevir diyoruz.
                //eğer zaten filter null değilse where ile filtreyi koyuyoruz ve listeliyoruz.
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();

            }
        }
    }
}
