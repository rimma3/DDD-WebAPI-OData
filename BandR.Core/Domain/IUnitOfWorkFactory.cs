using BandR.Core.Data;

namespace BandR.Core.Domain
{
    public interface IUnitOfWorkFactory<out TUnitOfWork>
        where TUnitOfWork : IUnitOfWork<BaseDbContext>
    {
        TUnitOfWork Create();
    }
}