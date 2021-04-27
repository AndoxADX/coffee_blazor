using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TG.Blazor.IndexedDB;

namespace HCB.Internal.Web.Data.Infrastructure
{
    public interface IDBStore<T> where T : IEntity
    {
        Task Add(T obj);
        Task<T> Get(long id);
        Task<IList<T>> Filter<TIndex>(string indexName, TIndex indexValue);
        Task<IList<T>> Filter<TProperty, TIndex>(Expression<Func<T, TProperty>> expression, TIndex indexValue);
        Task Delete(long id);
    }
}