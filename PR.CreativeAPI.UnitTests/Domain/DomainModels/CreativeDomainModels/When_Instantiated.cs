using Microsoft.VisualStudio.TestTools.UnitTesting;
using BandR.Core.Exceptions;
using PR.CreativeAPI.Domain.DomainModels.CreativeDomainModel;
using PR.CreativeAPI.Domain.PersistModels;

namespace PR.CreativeAPI.UnitTests.Domain.DomainModels.CreativeDomainModels
{
    public partial class Given_A_Creative
    {
        [TestClass]
        public class When_Instantiated : Given_A_Creative
        {
            [TestMethod]
            [ExpectedException(typeof(DomainException))]
            public void Then_A_Null_Initial_State_Will_Cause_A_DomainException()
            {
                // ARRANGE
                PersistCreative persistCreative = null;

                // ACT                
                var creative = new Creative(persistCreative);

                // ASSERT
                // Nothing to assert.
            }

            [TestMethod]
            public void Then_NonNull_Initial_State_Allows_Successful_Instantiation()
            {
                var creative = new Creative(new PersistCreative { Active = true });

                Assert.IsNotNull(creative, "Failed to create creative.");
            }

            [TestMethod]
            [ExpectedException(typeof(DomainException))]
            public void Then_An_InActive_State_Will_Cause_A_DomainException()
            {
                var creative = new Creative(new PersistCreative { Active = false });
            }
        }
    }
}
