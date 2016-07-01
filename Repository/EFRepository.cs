using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class EFRepository : IRepository, IDisposable
    {
        protected DbContext Context;

        public EFRepository(DbContext context, bool autoDetectChangesEnabled = false, bool proxyCreationEnabled = false)
        {
            Context = context;
            Context.Configuration.AutoDetectChangesEnabled = autoDetectChangesEnabled;
            Context.Configuration.ProxyCreationEnabled = proxyCreationEnabled;
        }

        public TEntity Create<TEntity>(TEntity newEntity) where TEntity : class
        {
            TEntity Result = null;

            try
            {
                Result = Context.Set<TEntity>().Add(newEntity);
                TrySaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Result;
        }

        public bool Delete<TEntity>(TEntity deletedEntity) where TEntity : class
        {
            bool Result = false;

            try
            {
                Context.Set<TEntity>().Attach(deletedEntity);
                Context.Set<TEntity>().Remove(deletedEntity);
                Result = TrySaveChanges() > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Result;
        }

        public TEntity FindEntity<TEntity>(Expression<Func<TEntity, bool>> criteria) where TEntity : class
        {
            TEntity Result = null;

            try
            {
                Result = Context.Set<TEntity>().FirstOrDefault(criteria);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Result;
        }

        public TEntity FindEntity<TEntity>(Expression<Func<TEntity, bool>> criteria, params string[] relations) where TEntity : class
        {
            TEntity Result = null;

            try
            {
                var query = Context.Set<TEntity>().AsQueryable();

                foreach (var item in relations)
                {
                    query = query.Include(item);
                }

                Result = query.FirstOrDefault(criteria);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Result;
        }

        public bool Update<TEntity>(TEntity modifiedEntity) where TEntity : class
        {
            bool Result = false;
            try
            {
                Context.Set<TEntity>().Attach(modifiedEntity);
                Context.Entry<TEntity>(modifiedEntity).State = EntityState.Modified;
                
                Result = TrySaveChanges() > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Result;
        }

        public IEnumerable<TEntity> GetAll<TEntity>(Expression<Func<TEntity, bool>> criteria) where TEntity : class
        {
            List<TEntity> Result = null;

            try
            {
                Result = Context.Set<TEntity>().Where(criteria).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Result;
        }

        public IEnumerable<TEntity> GetAll<TEntity>() where TEntity : class
        {
            List<TEntity> Result = null;

            try
            {
                Result = Context.Set<TEntity>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Result;
        }

        protected virtual int TrySaveChanges()
        {
            return Context.SaveChanges();
        }

        public void Dispose()
        {
            if (Context != null)
            {
                Context.Dispose();
            }
        }

        public IEnumerable<TEntity> GetAll<TEntity>(params string[] relations) where TEntity : class
        {
            List<TEntity> Result = null;

            try
            {

                var query = Context.Set<TEntity>().AsQueryable();

                foreach (var item in relations)
                {
                    query = query.Include(item);
                }

                Result = query.ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Result;
        }
    }
}
