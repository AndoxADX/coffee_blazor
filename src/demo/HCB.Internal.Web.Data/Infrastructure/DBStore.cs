using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TG.Blazor.IndexedDB;

namespace HCB.Internal.Web.Data.Infrastructure
{
    public class DBStore<T> : IDBStore<T> where T : IEntity
    {
        protected IndexedDBManager _db { get; init; }

        public DBStore(IndexedDBManager db)
        {
            _db = db;
        }

        public virtual Task Add(T obj)
        {
            var record = ToStoreRecord(obj);
            return _db.AddRecord(record);
        }
        public virtual Task<T> Get(long id)
        {
            return _db.GetRecordById<long, T>(typeof(T).Name, id);
        }
        public virtual async Task<IList<T>> Filter<TIndex>(string indexName, TIndex indexValue)
        {
            if (typeof(T).GetProperties().Any(p => p.Name == indexName) is not true)
                throw new InvalidOperationException("Invalid Index Name.");

            var result = await _db.GetAllRecordsByIndex<TIndex, T>(new StoreIndexQuery<TIndex>()
            {
                Storename = typeof(T).Name,
                // Convert to camelCase
                IndexName = Char.ToLowerInvariant(indexName[0]) + indexName.Substring(1),
                QueryValue = indexValue
            });
            return result ?? new List<T>();
        }
        public virtual async Task<IList<T>> Filter<TProperty, TIndex>(Expression<Func<T, TProperty>> expression, TIndex indexValue)
        {
            MemberExpression memberExpression = (MemberExpression)expression.Body;
            var indexName = memberExpression.Member.Name;
            var list = typeof(T).GetProperties().Select(p => p.Name).ToList();
            if (typeof(T).GetProperties().Any(p => p.Name == indexName) is not true)
                throw new InvalidOperationException("Invalid Index Name.");

            var result = await _db.GetAllRecordsByIndex<TIndex, T>(new StoreIndexQuery<TIndex>()
            {
                Storename = typeof(T).Name,
                // Convert to camelCase
                IndexName = Char.ToLowerInvariant(indexName[0]) + indexName.Substring(1),
                QueryValue = indexValue
            });

            return result ?? new List<T>();
        }

        public virtual Task Delete(long id)
        {
            return _db.DeleteRecord(typeof(T).Name, id);
        }

        StoreRecord<T> ToStoreRecord(T obj) => new StoreRecord<T>
        {
            Storename = typeof(T).Name,
            Data = obj
        };
    }
}