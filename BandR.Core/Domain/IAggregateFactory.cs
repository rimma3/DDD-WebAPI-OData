namespace Onpoint.Core.Domain
{
    public interface IAggregateFactory<in TAggregateRoot>
        where TAggregateRoot : IAggregateRoot
    {
        void AddAggregate(TAggregateRoot root);
    }
}