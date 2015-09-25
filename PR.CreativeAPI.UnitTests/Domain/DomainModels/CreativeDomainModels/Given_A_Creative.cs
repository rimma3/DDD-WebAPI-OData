using Microsoft.VisualStudio.TestTools.UnitTesting;
using PR.CreativeAPI.Domain.DomainModels.CreativeDomainModel;
using PR.CreativeAPI.UnitTests.TestObjectFactories;

namespace PR.CreativeAPI.UnitTests.Domain.DomainModels.CreativeDomainModels
{
    [TestClass]
    public partial class Given_A_Creative
    {
        protected Creative _creative = null;

        [TestInitialize]
        public void Initialize()
        {
            _creative = CreativeFactory.CreateCreativeDomainObject();
        }					
    }
}
