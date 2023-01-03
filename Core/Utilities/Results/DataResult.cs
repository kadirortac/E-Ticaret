using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class DataResult<T> : Result, IDataResult<T>
    {
        public DataResult(T data,bool Success,string Message):base(Success,Message)
        {
            this.data = data;
          
        }

        public DataResult(T data,bool Success):base(Success)
        {
            this.data = data;
        }

        public T data { get; }
    }
}
