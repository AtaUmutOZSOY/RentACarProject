using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results.Concrete
{
    public class ErrorResult : Result
    {
        public ErrorResult(bool error) : base(false)
        {
        }

        public ErrorResult(bool success, string massage):base(false, massage)
        {

        }
        public ErrorResult(string massage) : base(false, massage)
        {
        }

    }
}
