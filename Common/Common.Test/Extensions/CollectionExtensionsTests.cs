using Common.Extensions;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Common.Test.Extensions
{
    [TestClass]
    public class CollectionExtensionsTests
    {
        #region Test Methods

        [TestMethod]
        public void NotNullTest()
        {
            var collection = new List<string> {null, "hello"};
            collection.NotNull().Should().BeEquivalentTo(collection.Skip(1));
        }

        #endregion Test Methods
    }
}
