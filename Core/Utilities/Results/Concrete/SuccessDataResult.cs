using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results.Concrete
{
    public class SuccessDataResult<T> : DataResult<T>
    {
        public SuccessDataResult(T data, bool success) : base(data, true)
        {
        }

        public SuccessDataResult(T data, bool success, string massage) : base(data, true, massage)
        {

        }
        public SuccessDataResult(string massage):base(default, true, massage)
        {

        }
        public SuccessDataResult():base(default,true)
        {

        }
        public SuccessDataResult(T Data): base(Data,true)
        {
                
        }
    }
}
