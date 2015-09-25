using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BandR.Core.Exceptions;
using PR.CreativeAPI.Domain.DomainModels.PanelDomainModel;
using PR.CreativeAPI.Domain.PersistModels;

namespace PR.CreativeAPI.UnitTests.Domain.DomainModels.PanelDomainModels
{
    [TestClass]
    public class _When_Instantiated : Given_A_Panel
    {
        [TestMethod]
        [ExpectedException(typeof(DomainException))]
        public void Then_A_Null_Initial_State_Will_Cause_A_DomainException()
        {
            PersistPanel persistPanel = null;

            var panel = new Panel(persistPanel);
        }

        [TestMethod]
        public void Then_NonNull_Initial_State_Allows_Successful_Instantiation()
        {
            var panel = new Panel(new PersistPanel { Active = true });

            Assert.IsNotNull(panel, "Failed to create panel.");
        }

        [TestMethod]
        [ExpectedException(typeof(DomainException))]
        public void Then_An_InActive_State_Will_Cause_A_DomainException()
        {
            var panel = new Panel(new PersistPanel{ Active = false });
        }
    }
}
