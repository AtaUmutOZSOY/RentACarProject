using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results.Concrete
{
    public class SuccessResult : Result
    {
        public SuccessResult(bool success) : base(true)
        {
        }

        public SuccessResult(bool success, string massage) : base(true, massage)
        {
        }
        public SuccessResult(string massage): base(true, massage)
        {

        }
    }
}
