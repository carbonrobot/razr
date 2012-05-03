using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Razr.Repository;
using Razr.Services;

namespace Razr.Tests.Services
{
    [TestClass]
    public class ModelServiceTests
    {
        [TestMethod]
        public void CanCreateQuickDraft()
        {
            var context = new DataContext();
            var logger = new TestLogger();
            var service = new ModelService(context, logger);

            var title = "This is the best idea I have ever had";
            var response = service.CreateQuickDraft(title);
            var result = response.Result;

            Assert.IsFalse(response.HasError);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Id > 0);
            Assert.AreEqual(title, result.Title);
        }
    }

    public class TestLogger : ILogger
    {
        public void Error(Exception exception)
        {
            // nothing
        }
    }

}
