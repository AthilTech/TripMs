using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TripMs.Domain.Interfaces
{
    public interface IRepository<T> where T : class
    {
        #region async
        Task AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> entities);


        Task<T> GetAsync(Expression<Func<T, bool>> condition = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> includes = null);
        Task<IEnumerable<T>> GetListAsync(Expression<Func<T, bool>> condition = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> includes = null);
        string Update(T entity);





        //T GetById(Guid ID,
        //       Func<IQueryable<T>, IIncludableQueryable<T, object>> includes = null);



        //Task<IEnumerable<T>> ExecuteStoreQueryAsync(String commandText, params object[] parameters);
        //Task<IEnumerable<T>> ExecuteStoreQueryAsync(String commandText, Func<IQueryable<T>,
        //    IIncludableQueryable<T, object>> includes = null);
        #endregion


        #region sync Functions

        string Add(T entity);
        void AddRange(IEnumerable<T> entities);

        T Get(Expression<Func<T, bool>> condition = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> includes = null);

        IEnumerable<T> GetList(Expression<Func<T, bool>> condition = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> includes = null);

        //IEnumerable<T> ExecuteStoreQuery(String commandText, params object[] parameters);

        //IEnumerable<T> ExecuteStoreQuery(String commandText,
        //    Func<IQueryable<T>, IIncludableQueryable<T, object>> includes = null);

        string RemoveById(Guid id);
        void RemoveRange(IEnumerable<T> entites);
        #endregion
    }
}
