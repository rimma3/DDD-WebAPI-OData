using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BandR.Core.Exceptions;

namespace PR.CreativeAPI.UnitTests.Domain.DomainModels.CreativeDomainModels
{
    public partial class Given_A_Creative
    {
        [TestClass]
        public class _When_Panel_Is_Added : Given_A_Creative
        {
            [TestMethod]
            public void Then_Panel_Count_Is_Incremented()
            {
                // ARRANGE
                int panelId = 1;
                int expectedPanelCount = 1;
                string panelAlias = "test";

                // ACT
                _creative.AddPanel(panelId, panelAlias);
                
                // ASSERT
                Assert.AreEqual(expectedPanelCount, _creative.Panels.Count, "Panel count should be affected when successfully adding a panel.");
            }

            [TestMethod]
            public void Then_Panel_Can_Be_Added_Twice_With_Unique_Alias()
            {
                // ARRANGE
                int panelId = 1;
                int expectedPanelCount = 2;
                string panelAlias1 = "test", panelAlias2 = "test2";

                // ACT
                _creative.AddPanel(panelId, panelAlias1);
                _creative.AddPanel(panelId, panelAlias2);
                
                // ASSERT
                Assert.AreEqual(expectedPanelCount, _creative.Panels.Count, "Panel count should be affected when successfully adding a panel twice with unique panel aliases.");
               
            }

            [TestMethod]
            [ExpectedException(typeof(DomainException))]
            public void Then_A_Null_PanelAlias_Will_Cause_A__DomainException()
            {
                // ARRANGE
                int panelId = 1;
                int expectedPanelCount = 0;
                string panelAlias = null;

                // ACT
                _creative.AddPanel(panelId, panelAlias);

                Assert.AreEqual(expectedPanelCount, _creative.Panels.Count, "Panel count should be zero.");
            }

            [TestMethod]
            [ExpectedException(typeof(DomainException))]
            public void Then_A_Blank_PanelAlias_Will_Cause_A__DomainException()
            {
                // ARRANGE
                int panelId = 1;
                int expectedPanelCount = 0;
                string panelAlias = "";

                // ACT
                _creative.AddPanel(panelId, panelAlias);

                Assert.AreEqual(expectedPanelCount, _creative.Panels.Count, "Panel count should be zero.");
            }

            [TestMethod]
            [ExpectedException(typeof(DomainException))]
            public void Then_A_Duplicate_PanelAlias_Will_Cause_A_DomainException()
            {
                int panelId = 1;
                int expectedPanelCount = 1;
                string panelAlias = "test";

                _creative.AddPanel(panelId, panelAlias);
                _creative.AddPanel(panelId, panelAlias);

                Assert.AreEqual(expectedPanelCount, _creative.Panels.Count, "Panel count should be one.");
            }

            [TestMethod]
            [ExpectedException(typeof(DomainException))]
            public void Then_A_PanelAlias_With_Only_Whitespace_Will_Cause_A_DomainException()
            {
                // ARRANGE
                int panelId = 1;
                int expectedPanelCount = 0;
                string panelAlias = "          ";

                // ACT
                _creative.AddPanel(panelId, panelAlias);

                Assert.AreEqual(expectedPanelCount, _creative.Panels.Count, "Panel count should be zero.");
            }

            [TestMethod]
            public void Then_PanelAlias_Should_Match_What_Is_Passed_In()
            {
                // ARRANGE
                int panelId = 1;
                string panelAlias = "test";

                // ACT
                _creative.AddPanel(panelId, panelAlias);

                // ASSERT
                Assert.AreEqual(panelAlias, _creative.Panels.First().PanelAlias, "PanelAlias was not set correctly.");
            }

            [TestMethod]
            public void Then_PanelAlias_Should_Respect_WhiteSpace()
            {
                // ARRANGE
                int panelId = 1;
                string panelAlias = " test 1 ";

                // ACT
                _creative.AddPanel(panelId, panelAlias);

                // ASSERT
                Assert.AreEqual(panelAlias, _creative.Panels.First().PanelAlias, "AddPanel failed to respect whitespace in PanelAlias.");
            }

            [TestMethod]
            public void Then_Panel_IsPrimaryPanel_Value_True_Is_Respected()
            {
                // ARRANGE
                int panelId = 1;
                string panelAlias = "test";
                bool isPrimaryPanel = true;

                // ACT
                _creative.AddPanel(panelId, panelAlias, isPrimaryPanel);

                // ASSERT
                Assert.AreEqual(isPrimaryPanel, _creative.Panels.First().IsPrimaryPanel, "IsPrimaryPanel was not set correctly.");
            }

            [TestMethod]
            public void Then_Panel_IsPrimaryPanel_Value_False_Is_Respected()
            {
                // ARRANGE
                int panelId = 1;
                string panelAlias = "test";
                bool isPrimaryPanel = false;

                // ACT
                _creative.AddPanel(panelId, panelAlias, isPrimaryPanel);

                // ASSERT
                Assert.AreEqual(isPrimaryPanel, _creative.Panels.First().IsPrimaryPanel, "IsPrimaryPanel was not set correctly.");
            }

            [TestMethod]
            public void Then_Panel_IsPrimaryPanel_Default_Value_Is_False()
            {
                // ARRANGE
                int panelId = 1;
                string panelAlias = "test";
                bool isPrimaryPanel = false;

                // ACT
                _creative.AddPanel(panelId, panelAlias);

                // ASSERT
                Assert.AreEqual(isPrimaryPanel, _creative.Panels.First().IsPrimaryPanel, "IsPrimaryPanel was not set correctly.");
            }

            [TestMethod]
            [ExpectedException(typeof(DomainException))]
            public void Then_Panel_IsPrimaryPanel_Can_Only_Be_True_For_One_CreativePanel()
            {
                // ARRANGE
                int panelId = 1;
                string panelAlias1 = "test1", panelAlias2 = "test2";
                bool isPrimaryPanel = true;

                // ACT
                _creative.AddPanel(panelId, panelAlias1, isPrimaryPanel);
                _creative.AddPanel(panelId, panelAlias2, isPrimaryPanel);

                // ASSERT
                Assert.AreEqual(1, _creative.Panels.Count, "Panel count incremented when it should not have.");
            }
        }
    }
}
