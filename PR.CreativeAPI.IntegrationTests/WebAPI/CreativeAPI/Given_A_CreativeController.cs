using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CreativeAPI.CreativeControllers;
using PR.CreativeAPI.IntegrationTests.Builder;
using System.Transactions;

namespace PR.CreativeAPI.IntegrationTests.WebAPI.CreativeAPI
{
    public partial class Given_A_CreativeController
    {
        protected CreativesController _creativesController;
        private TransactionScope _transactionScope;

        [TestInitialize]
        public void Initialize()
        {
            _transactionScope = new TransactionScope();
            _creativesController = ControllerAPIBuilder.CreateCreativesController();
        }

        [TestCleanup]
        public void Cleanup()
        {
            if (_transactionScope != null)
            {
                _transactionScope.Dispose();
                _transactionScope = null;
            }
        }
    }
}
