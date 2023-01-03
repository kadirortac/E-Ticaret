using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class SuccessDataResult<T>:DataResult<T>
    {

        public SuccessDataResult(T data,string message):base(data,true,message) // mesaj ve data verebilir.
        {

        }
        public SuccessDataResult(T data):base(data,true)  // mesaj vermeyip sadce data verebilir
        {

        }
        public SuccessDataResult(string message):base(default,true,message)
        {
                                                                             // data vermeyebilir,default olabilir.
        }
        public SuccessDataResult() : base(default, true)
        {

        }

    }
}
