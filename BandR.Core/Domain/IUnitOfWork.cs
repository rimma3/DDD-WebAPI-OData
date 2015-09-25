using System;

using BandR.Core.Data;

namespace BandR.Core.Domain
{
    public interface IUnitOfWork<TContext> : IDisposable
        where TContext : BaseDbContext
    {
        void Commit();
    }
}