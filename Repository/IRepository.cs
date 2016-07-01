﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IRepository : IDisposable
    {
        TEntity Create<TEntity>(TEntity newEntity) where TEntity : class;
        bool Update<TEntity>(TEntity modifiedEntity) where TEntity : class;
        bool Delete<TEntity>(TEntity deletedEntity) where TEntity : class;
        TEntity FindEntity<TEntity>(Expression<Func<TEntity, bool>> criteria) where TEntity : class;
        TEntity FindEntity<TEntity, TEntityR>(Expression<Func<TEntity, bool>> criteria1, Expression<Func<TEntity, TEntityR>> criteria2) where TEntity : class;
        TEntity FindEntity<TEntity>(Expression<Func<TEntity, bool>> criteria1, string criteria2, string criteria3) where TEntity : class;
        IEnumerable<TEntity> GetAll<TEntity>(Expression<Func<TEntity, bool>> criteria) where TEntity : class;
        IEnumerable<TEntity> GetAll<TEntity>() where TEntity : class;
    }
}
