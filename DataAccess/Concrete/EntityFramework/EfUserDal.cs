using Core.DataAccess.Concrete;
using Core.Entity.Concrete;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    internal class EfUserDal:EfEntityRepositoryBase<User,RentACarProjectContext>,IUserDal
    {
    }
}
