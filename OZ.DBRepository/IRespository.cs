using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


namespace OZ.DBRepository
{
    public interface IRespository<TEntity> where TEntity :class
    {
        TEntity Get<Tid>(Tid ID);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> GetByProperty(Expression<Func<TEntity, bool>> filter);
        void Insert(TEntity entity);
        //void Delete(TEntity entity);
        //void SaveChanges();
    }
}
