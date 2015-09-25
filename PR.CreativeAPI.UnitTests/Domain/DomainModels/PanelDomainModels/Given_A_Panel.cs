using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PR.CreativeAPI.Domain.DomainModels.PanelDomainModel;
using PR.PanelAPI.UnitTests.TestObjectFactories;

namespace PR.CreativeAPI.UnitTests.Domain.DomainModels.PanelDomainModels
{
    [TestClass]
    public class Given_A_Panel
    {
        protected Panel _panel = null;

        [TestInitialize]
        public void Initialize()
        {
            _panel = PanelFactory.CreatePanelDomainObject();
        }	
    }
}
