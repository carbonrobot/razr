using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Razr.Models;

namespace Razr.Tests.Models
{
    [TestClass]
    public class PostTests
    {
        [TestMethod]
        public void CanCreateNewPosts()
        {
            var p = new Post();
            p.Summary = "New post";
            p.Body = "I am always dancing in the moonlight";
        }
    }
}
