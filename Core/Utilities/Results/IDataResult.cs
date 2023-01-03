using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{

    // return ile birşey döndüren methodlar için(List<Product> getAll)
    // ıdataresult ı kullancağız ve bunu generic olarak birçok tipe(product,category)
    // uygun şekilde çalışmasını sağlayacağız.
    public interface IDataResult<T>:IResult 
    {                       // IResult'tan bool tipi ve mesajı aldık.Geriye sadece geri döndürülecek data kaldı.
        T data{ get; }     // T tipinde geri döndürülecek datamız.
    }
}

// YANİ KISACA; IResult VOİD TİPLİ METHODLAR İÇİN SADECE İŞLEM TÜRÜ(BOOLEAN) VE MESAJ İÇEREN BİR RESULT TİPİ.
// AMA IDataResult RETURN TİPLİ YANİ List<Product> getAll GİBİ METHODLAR BİZE ÜRÜN DÖNDÜRECEK MESELA,YANİ BUNDA
// VOİD TİPLİ RESULT'A GÖRE EKSTRA OLARAK GERİ DÖNDÜRÜLECEK DATAYA DA İHTİYACIMIZ VAR.E BİZ ZATEN IResult İLE 
// MESAJ VE İŞLEM TÜRÜNÜ(BOOL) İÇEREN BİR RESULT SOYUTU YAPMIŞTIK,IDataResult SADECE BUNU MİRAS ALIP EKSTRA OLARAK
// DATA İÇEREN BİR FİELD'İ OLSUN O DA T TİPİNDE OLSUN ÇÜNKÜ IDataResult İNTERFACEİMİZ GENERİC, YANİ BİRÇOK TİPTE
// ÇALIŞABİLİR.SADECE VERMEN GEREKEN PARAMETREYİ T YERİNE YAZ.İSTER PRODUCT YAZ İSTER CATEGORY.