using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using PR.CreativeAPI.Data.UnitTests.DAL.Moq;
using PR.CreativeAPI.Domain.PersistModels;
using PR.CreativeAPI.Data;
using BandR.Core.Data;
using PR.CreativeAPI.Domain.DomainModels.CreativeDomainModel;
using PR.CreativeAPI.Core.Data;

namespace PR.CreativeAPI.UnitTests.DAL.Repositories.CreativeDomainRepository
{
    public partial class Given_A_CreativeRepository
    {
        protected PersistCreative _persistCreative;
        protected UnitOfWork<Creative,PersistCreative> _unitOfWork;
        protected Repository<Creative, PersistCreative> _creativeRepository;
        [TestInitialize]
        public void Initialize()
        {
            _persistCreative = new PersistCreative { CreativeId = 1, CreativeName = "ABC", AdvertiserId = 46 };
            SetupCreativeRepository();

        }

        private void SetupCreativeRepository()
        {
            var persistCreative = new List<PersistCreative> { _persistCreative }.AsQueryable();
            var dbSetMock = new Mock<IDbSet<PersistCreative>>();

            dbSetMock.Setup(m => m.Provider).Returns(persistCreative.Provider);
            dbSetMock.Setup(m => m.Expression).Returns(persistCreative.Expression);
            dbSetMock.Setup(m => m.ElementType).Returns(persistCreative.ElementType);
            dbSetMock.Setup(m => m.GetEnumerator()).Returns(persistCreative.GetEnumerator());
            
            MockRepositories.creativeContext.Setup(mock => mock.GetTypedSet<PersistCreative>()).Returns(dbSetMock.Object);
            MockRepositories.creativeContext.Setup(mock => mock.GetTypedSet<PersistCreative>().Find(It.IsAny<object>())).Returns(_persistCreative);

            MockRepositories.unitOfWorkContext.Setup(mock => mock.Create()).Returns(new BandRUnitOfWork<BaseDbContext>(MockRepositories.creativeContext.Object));
            
            _creativeRepository = new Repository<Creative, PersistCreative>(MockRepositories.creativeContext.Object);
            _unitOfWork = new UnitOfWork<Creative, PersistCreative>(MockRepositories.creativeContext.Object);

        }
    }
}
