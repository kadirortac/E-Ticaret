using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess
{

    // Generic Constraint => Sınırlandırma getirmek.
    // : class yazarak   referans tip olabilir demek dedik ve sınırlandırıdık
    // yani T yerine referans tip yazılabilir sadece mesela int yazılamaz.
    // bu durumda da her class ı yazabiliyor oluyoruz, biraz daha sınrılandırma getirerek sadece entity classlar olabilir diyeceğiz.
    // bizim istediğimiz classların ortak özelliği hepsinin IEntity olması yani ", IEntity " yazarak hem IEntity hem de IEntity i implement eden classları oraya verebiliriz.
    // böylece her sınıfı da oraya yazamaz olduk, sınırlandırma getirdik.Şİmdiki sıkıntımız ise IEntitiy nin oraya yazılabilir olması biz bunu istemiyoruz 
    // bu yüzden hemen yanına " new () " yazarak oraya yeni bir şart eklemiş olduk şartmıız ne peki ? 
    // new() diyerek newlenebilir bi IEntity istiyorum dedik. IEntity tek başına bir soyut sınıf (interface) olduğu için newlenemez bu şekilde son sıkıntımızı da çözdük.

    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        List<T> getAll(Expression<Func<T, bool>> filter = null); // Bu içteki ifade ile biz verilerimizi LINQ ile filreleyebileceğiz.
        T Get(Expression<Func<T, bool>> filter);               // E biz bunu zaten yapıyorduk diyebilirisin evet ama her bir filtre için ayrı ayrı LINQ ifadesi yazıyorduk biz bu yapı topluca filtreleme yapma imkanı sağlıyor
        void Add(T entity);                                    // mesela getAllByCategory diye bir method gibi filtrelemk istediğimiz her bir şey için bu şekilde ayrı ayrı method yazmamayı vaad ediyor.
        void Delete(T entity);
        void Update(T entity);
        //  List<T> getAllByCategory(int categoryId);
    }
}

/* Şimdi neden IEntityRepository diye bir interface yarattık? 
   çünkü biz her varlığımız için(product,category,user) interface yaratacağımız zaman o interface'in 
   içini ayrı ayrı o varlığıa göre doldurmak zorundaydık ama methodlar asla değişmiyor sadece 
   methodların aldığı varlık değişiyor. E ben bunu genericlerle dinamik bir şekilde her seferinde kendim
   methodları o varlık tipine göre yazmaktan kurtlurum.Yani ben her varlık için yarattığım interface'i 
   üst bir interface'den implement edersem bu amelelikten kurtulurum. T harfi bizim product,category vs temsil
   ediyor.
*/