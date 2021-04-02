using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TripMs.Data.Context;
using TripMs.Domain.Interfaces;

namespace TripMs.Data.Repository
{
  public  class Repository<T> : IRepository<T> where T : class
    {
        protected readonly TripMsContext Context;
        public Repository(TripMsContext context)
        {
            Context = context;
        }

        #region Async Functions

        public virtual async Task AddAsync(T entity)
        {
            try
            {
                await Context.Set<T>().AddAsync(entity);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        public virtual async Task AddRangeAsync(IEnumerable<T> entities)
        {
            try
            {
                await Context.Set<T>().AddRangeAsync(entities);
            }
            catch (Exception e)
            {
                var s = e.ToString();
                throw;
            }
        }

        public virtual async Task<T> GetAsync(Expression<Func<T, bool>> condition = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> includes = null)
        {
            try
            {
                IQueryable<T> query = Context.Set<T>();
                if (includes != null)
                {
                    query = includes(query);
                }

                if (condition != null)
                {
                    return await query.FirstOrDefaultAsync(condition);
                }

                return await query.FirstOrDefaultAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }


        public virtual async Task<IEnumerable<T>> GetListAsync(Expression<Func<T, bool>> condition = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> includes = null)
        {
            IQueryable<T> query = Context.Set<T>();
            if (includes != null)
            {
                query = includes(query);
            }

            if (condition != null)
            {
                return await query.Where(condition).ToListAsync();
            }

            return await query.ToListAsync();
        }

        //public virtual async Task<IEnumerable<T>> ExecuteStoreQueryAsync(string commandText, params object[] parameters)
        //{
        //    try
        //    {
        //        return await Context.Set<T>().FromSql(commandText, parameters).ToListAsync();
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e);
        //        throw;
        //    }
        //}
        //public virtual async Task<IEnumerable<T>> ExecuteStoreQueryAsync(string commandText, Func<IQueryable<T>, IIncludableQueryable<T, object>> includes = null)
        //{
        //    try
        //    {
        //        return await Context.Set<T>().FromSql(commandText, includes).ToListAsync();
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e);
        //        throw;
        //    }
        //}


        #endregion

        #region Sync Functions

        public string Add(T entity)
        {
            string response = "";
            try
            {
                Context.Set<T>().Add(entity);
                Context.SaveChanges();

                response = "Added done";

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                response = "Add Not done , with Exeption \n" + e;
            }
            return response;
        }



        public void AddRange(IEnumerable<T> entities)
        {
            try
            {
                Context.Set<T>().AddRange(entities);
            }
            catch (Exception e)
            {
                var s = e.ToString();
            }
        }

        public T Get(Expression<Func<T, bool>> condition = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> includes = null)
        {
            try
            {
                IQueryable<T> query = Context.Set<T>();

                if (includes != null)
                {
                    query = includes(query);
                }

                if (condition != null)
                {
                    return query.FirstOrDefault(condition);
                }

                return query.FirstOrDefault();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }


        public virtual IEnumerable<T> GetList(Expression<Func<T, bool>> condition = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> includes = null)
        {
            IQueryable<T> query = Context.Set<T>();

            if (includes != null)
            {
                query = includes(query);
            }

            if (condition != null)
            {
                return query.Where(condition).ToList();
            }

            return query.ToList();

        }


        public string RemoveById(Guid id)
        {
            T table = Context.Set<T>().Find(id);
            Context.Set<T>().Remove(table);
            Context.SaveChanges();
            return "Delete Done";
        }

        public void RemoveRange(IEnumerable<T> entites)
        {
            try
            {
                Context.Set<T>().RemoveRange(entites);

            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        //public IEnumerable<T> ExecuteStoreQuery(string commandText, params object[] parameters)
        //{
        //    try
        //    {
        //        return Context.Set<T>().FromSql(commandText, parameters).ToList();
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e);
        //        throw;
        //    }
        //}

        //public IEnumerable<T> ExecuteStoreQuery(string commandText, Func<IQueryable<T>, IIncludableQueryable<T, object>> includes = null)
        //{
        //    try
        //    {
        //        return Context.Set<T>().FromSql(commandText, includes).ToList();
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e);
        //        throw;
        //    }
        //}

        #endregion

        #region Generic Controller Test

        public T GetById(Guid id)
        {
            IQueryable<T> query = Context.Set<T>();
            return Context.Set<T>().FirstOrDefault();
        }



        public string Update(T entity)
        {
            Context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            Context.SaveChanges();
            return "Update Done";
        }

        #endregion
    }

}
