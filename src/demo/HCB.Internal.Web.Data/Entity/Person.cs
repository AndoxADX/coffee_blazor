using HCB.Internal.Web.Data.Infrastructure;

namespace HCB.Internal.Web.Data.Entity
{
    public class Person : IEntity
    {
        public long? Id { get; set; }
        public int Version { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
    }
}