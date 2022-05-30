using Business.Abstract;
using Business.Constants;
using Core.DataAccess.Abstract;
using Core.Entity.Abstract;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BaseManager<TEntity> : IBaseService<TEntity> where TEntity : class, IEntity, new()
    {
        IEntityRepository<TEntity> _entityRepository;
        
        public virtual IResult Add(TEntity entity)
        {
            _entityRepository.Add(entity);
            return new SuccessResult(Messages.ActionMessages.SuccedAdd);   
        }
            

        public virtual IResult Delete(TEntity entity)
        {
            _entityRepository.Delete(entity);
            return new SuccessResult(Messages.ActionMessages.SuccedRemove);
        }

        

        public virtual IDataResult<List<TEntity>> GetAll()
        {
            var results = _entityRepository.GetAll();
            if (results != null)
            {
                return new SuccessDataResult<List<TEntity>>(results);
            }
            return null;
        }

        public virtual IDataResult<List<TEntity>> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            var entities = _entityRepository.GetAll();
            return new SuccessDataResult<List<TEntity>>(entities);
        }

        public virtual IResult Update(TEntity entity)
        {
            _entityRepository.Update(entity);
            return new SuccessResult();
        }




    }
}
