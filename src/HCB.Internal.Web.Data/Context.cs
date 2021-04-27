using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HCB.Internal.Web.Data.Entity;
using HCB.Internal.Web.Data.Infrastructure;
using HCB.Internal.Web.Data.Store;
using TG.Blazor.IndexedDB;

namespace HCB.Internal.Web.Data
{
    public class Context
    {
        public IDBStore<Person> personStore { get; init; }
        private IndexedDBManager _db;
        private ContextFactory _factory;
        public Context(IndexedDBManager db, ContextFactory factory)
        {
            _db = db;
            _factory = factory;
            personStore = new PersonStore(db);
            // personStore.CreateStore();
        }

        // Use this when something went wrong with the Database
        public async Task ResetDb()
        {
            await _factory.ResetDbStore(_db);
        }
    }
}
