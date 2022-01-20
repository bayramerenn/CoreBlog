using CoreBlog.Business.Abstract;
using CoreBlog.DataAccess.Abstract;
using CoreBlog.DataAccess.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CoreBlog.Business.Concrete
{
    public class GenericManager<TEntity> : IGenericService<TEntity> where TEntity : class
    {
        private readonly IGenericDal<TEntity> _genericDal;
        private readonly IUnitOfWork _unitOfWork;

        public GenericManager(IGenericDal<TEntity> genericDal, IUnitOfWork unitOfWork)
        {
            _genericDal = genericDal;
            _unitOfWork = unitOfWork;
        }
        public GenericManager()
        {

        }

        public void Delete(TEntity entity)
        {
            _genericDal.Delete(entity);
            _unitOfWork.Commit();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _genericDal.GetByIdAsync(id);
        }

        public async Task<IEnumerable<TEntity>> GetListAllAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            return await _genericDal.GetListAllAsync(filter);
        }

        public async Task InsertAsync(TEntity entity)
        {
            await _genericDal.InsertAsync(entity);
            await _unitOfWork.CommitAsync();
        }

        public void Update(TEntity entity)
        {
            _genericDal.Update(entity);
            _unitOfWork.Commit();
        }

        public async Task<TEntity> WhereAsync(Expression<Func<TEntity, bool>> filter)
        {
            return await _genericDal.WhereAsync(filter);
        }
    }
    
    
}
