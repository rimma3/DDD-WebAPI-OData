using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using PR.CreativeAPI.Data;
using BandR.Core.Data;
using BandR.Core.Domain;

namespace PR.CreativeAPI.Data.UnitTests.DAL.Moq
{
    public static class MockRepositories
    {
        public static Mock<BaseDbContext> dbContext { get; private set; }
        public static Mock<BaseDbContext> creativeContext { get; private set; }
        public static Mock<IUnitOfWorkFactory<IUnitOfWork<BaseDbContext>>> unitOfWorkContext { get; private set; }
        static MockRepositories()
        {
            dbContext = new Mock<BaseDbContext>();
            creativeContext = new Mock<BaseDbContext>();
            unitOfWorkContext = new Mock<IUnitOfWorkFactory<IUnitOfWork<BaseDbContext>>>();
        }
    }
}
