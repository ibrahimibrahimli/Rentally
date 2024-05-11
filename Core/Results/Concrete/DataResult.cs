using Core.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Results.Concrete
{
    public class DataResult<T> : Result, IDataResult<T>
    {
        public DataResult(T Data, bool IsSucces) : base(IsSucces)
        {
            this.Data = Data;
        }

        public DataResult(T Data, string Message, bool IsSucces) : base(Message, IsSucces)
        {
            this.Data = Data;
        }

        public T Data { get; }
    }
}
