using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OZ.DBRepository
{
    public class SqlRepository<TEntity> : IRespository<TEntity> where TEntity : class
    {
        internal SqlServerDefaultContext ctx;
        internal DbSet<TEntity> dbSet;
        public SqlRepository(SqlServerDefaultContext ctxParam)
        {
            this.ctx = ctxParam;
            this.dbSet = ctxParam.Set<TEntity>();
        }
        public TEntity Get<Tid>(Tid ID)
        {
            return dbSet.Find(ID);
        }
        public IEnumerable<TEntity> GetAll()
        {
            IQueryable<TEntity> query = dbSet;
            return query.ToList();          
        }
        public IEnumerable<TEntity> GetByProperty(Expression<Func<TEntity, bool>> filter)
        {
            return this.dbSet.Where(filter).AsEnumerable();
        }
        public void Insert(TEntity entity)
        {
            using (var dbContextTransaction = ctx.Database.BeginTransaction())
            {
                try
                {
                    this.dbSet.Add(entity);
                    ctx.SaveChanges();
                    dbContextTransaction.Commit();
                }
                catch(Exception)
                {
                    dbContextTransaction.Rollback();
                }
            }
        }

    }
}
