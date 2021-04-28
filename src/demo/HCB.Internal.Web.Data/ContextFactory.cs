using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HCB.Internal.Web.Data.Entity;
using HCB.Internal.Web.Data.Infrastructure;
using HCB.Internal.Web.Data.Store;
using TG.Blazor.IndexedDB;

namespace HCB.Internal.Web.Data
{
    public class ContextFactory
    {
        public static string DB_NAME = "hcb.internal.web.data";
        private DbStore _dbStore { get; set; }
        public ContextFactory()
        {
        }

        public async Task ResetDbStore(IndexedDBManager db)
        {
            await db.OpenDb();
            await db.DeleteDb(DB_NAME);
            ConfigureDB1(_dbStore);
            await db.OpenDb();
        }

        // Setup the indexed DB with versioning.
        public void ConfigureDB(DbStore dbStore)
        {
            _dbStore = dbStore;
            ConfigureDB1(dbStore);
        }

        private static void ConfigureDB1(DbStore dbStore)
        {
            dbStore.DbName = DB_NAME; //example name
            dbStore.Version = 2;

            dbStore.Stores.Clear();

            // Configure Schemas
            dbStore.Stores.AddRange(PersonStore.GetSchema());
        }
    }
}
