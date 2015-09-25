namespace BandR.Core.Domain
{
    public interface IAggregateUtilizer<in TAggregateRoot>
        where TAggregateRoot : IAggregateRoot
    {
        void Remove(TAggregateRoot root);
    }
}