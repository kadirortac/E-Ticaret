using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {
                                                  // this: bu class demek yani Result
                                                  // this(): contructor demek. this(success) diyince 2.ctordan bahsediliyor.
        public Result(bool success, string message):this(success)
        {
           
            this.Message = message;  // bu ctor da mesaj gönderilmek istenirse çalışcak.
                                     // Ama succes'i 2 ctor'da da yazmak istemediğim için ve bu ctor diğer ctor'u da kapsadığı için yukarıdaki gibi birşey yapılabilir.
        }

        public Result(bool success)
        {                              // bu ctor, istenilirse mesaj gönderilmeyebilir demek.
            this.Success=success;
        }

        // Uyarı! Get yani read only methodlar, ctorlar ile set edilebilir. Aynı yukarıda yaptığımız gibi.
        public bool Success { get;  }

        public string Message { get; }
    }
}
