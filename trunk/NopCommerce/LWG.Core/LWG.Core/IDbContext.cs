using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LWG.Core
{
    public interface IDbContext
    {
        IDbSet<TEntity> Set<TEntity>() where TEntity : class;
        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
        bool IsAttached(object entity);
        IEnumerable<TElement> SqlQuery<TElement>(string sql, params object[] parameters);
        int ExecuteSqlCommand(string sql, int? timeout = null, params object[] parameters);
    }
}
