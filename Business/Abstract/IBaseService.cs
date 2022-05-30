using Core.Entity.Abstract;
using Core.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBaseService<T> where T : class,IEntity,new()
    {
        IResult  Add(T entity);
        IResult Delete(T entity);
        IResult Update(T entity);
        IDataResult<List<T>> GetAll(Expression<Func<T,bool>> filter = null);
        


        
    }
}
