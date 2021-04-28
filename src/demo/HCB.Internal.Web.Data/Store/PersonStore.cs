using System.Collections.Generic;
using System.Threading.Tasks;
using HCB.Internal.Web.Data.Entity;
using HCB.Internal.Web.Data.Infrastructure;
using TG.Blazor.IndexedDB;

namespace HCB.Internal.Web.Data.Store
{
    public class PersonStore : DBStore<Person>
    {
        public PersonStore(IndexedDBManager db) : base(db)
        {
        }

        public static List<StoreSchema> GetSchema()
        {
            return new List<StoreSchema>()
            {
                new StoreSchema
                {
                    DbVersion = 2,
                    Name = nameof(Person),
                    PrimaryKey = new IndexSpec { Name = "id", KeyPath = "id", Auto = true },
                    Indexes = new List<IndexSpec>
                    {
                        // Index has to be in camel case.
                        // Because when saving into indexDB, they are camel case.
                        // Filter function will automatically convert into camel case.
                        new IndexSpec{Name="firstName", KeyPath = "firstName", Auto=false},
                        new IndexSpec{Name="lastName", KeyPath = "lastName", Auto=false},
                        new IndexSpec{Name="phoneNumber", KeyPath = "phoneNumber", Auto=false},
                    }
                }
            };
        }
    }
}