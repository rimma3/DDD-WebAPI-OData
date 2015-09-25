using Microsoft.VisualStudio.TestTools.UnitTesting;
using BandR.Core.Exceptions;

namespace PR.CreativeAPI.UnitTests.Domain.DomainModels.CreativeDomainModels
{
    public partial class Given_A_Creative
    {
        [TestClass]
        public class _When_Panel_Is_Removed_By_Alias : Given_A_Creative
        {
            [TestMethod]
            public void Then_Panel_Count_Is_Decremented()
            {
                // ARRANGE
                int panelId = 1;
                int expectedPanelCount = 0;
                string panelAlias = "test";

                _creative.AddPanel(panelId, panelAlias);

                // ACT                
                _creative.RemovePanel(panelAlias);

                // ASSERT
                Assert.AreEqual(expectedPanelCount, _creative.Panels.Count, "Panel count should be affected when successfully removing a panel.");
            }

            [TestMethod]
            [ExpectedException(typeof(DomainException))]
            public void Then_An_Unrecognized_Alias_Will_Cause_A_DomainException()
            {
                _creative.AddPanel(1, "test");

                _creative.RemovePanel("abc");

                Assert.AreEqual(1, _creative.Panels.Count, "RemovePanelByPanelId did not throw exception.");
            }
        }

        [TestClass]
        public class _When_Panel_Is_Removed_By_PanelId : Given_A_Creative
        {
            [TestMethod]
            public void Then_Panel_Count_Is_Decremented()
            {
                // ARRANGE
                int panelId = 1;
                int expectedPanelCount = 0;
                string panelAlias = "test";

                _creative.AddPanel(panelId, panelAlias);

                // ACT                
                _creative.RemovePanel(panelId);

                // ASSERT
                Assert.AreEqual(expectedPanelCount, _creative.Panels.Count, "Panel count should be affected when successfully removing a panel.");
            }

            [TestMethod]
            public void Then_Panel_Count_Is_Decremented_For_Each_Matching_Panel()
            {
                // ARRANGE
                int panelId = 1;
                int expectedPanelCount = 0;
                string panelAlias1 = "test1", panelAlias2 = "test2";

                _creative.AddPanel(panelId, panelAlias1);
                _creative.AddPanel(panelId, panelAlias2);

                // ACT                
                _creative.RemovePanel(panelId);

                // ASSERT
                Assert.AreEqual(expectedPanelCount, _creative.Panels.Count, "Panel count should be affected when successfully removing a panel.");
            }

            [TestMethod]
            [ExpectedException(typeof(DomainException))]
            public void Then_An_Unrecognized_PanelId_Will_Cause_A_DomainException()
            {
                _creative.AddPanel(1, "test");

                _creative.RemovePanel(2);

                Assert.AreEqual(1, _creative.Panels.Count, "RemovePanelByPanelId did not throw exception.");
            }
        }

        [TestClass]
        public class _When_Removing_PrimaryPanel : Given_A_Creative
        {
            [TestMethod]
            public void Then_Panel_Count_Is_Decremented()
            {
                // ARRANGE
                int panelId = 1;
                int expectedPanelCount = 1;
                string panelAlias1 = "test1", panelAlias2 = "test2";

                _creative.AddPanel(panelId, panelAlias1, true);
                _creative.AddPanel(panelId, panelAlias2);

                // ACT                
                _creative.RemovePrimaryPanel();

                // ASSERT
                Assert.AreEqual(expectedPanelCount, _creative.Panels.Count, "Panel count should be affected when successfully removing a panel.");
            }

            [TestMethod]
            [ExpectedException(typeof(DomainException))]
            public void Then_Lack_Of_A_PrimaryPanel_Will_Cause_A_DomainException()
            {
                _creative.AddPanel(1, "test");

                _creative.RemovePrimaryPanel();

                Assert.AreEqual(1, _creative.Panels.Count, "RemovePanelByPanelId did not throw exception.");
            }
        }
    }
}
