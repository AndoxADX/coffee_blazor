namespace HCB.Internal.Web.Data.Infrastructure
{
    public interface IEntity
    {
        long? Id { get; set; }
        int Version { get; set; }
    }
}