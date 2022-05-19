using Common.Extensions;
using FluentAssertions;

namespace Common.Test
{
    [TestClass]
    public class CollectionExtensionsTests
    {
        #region Test Methods

        [TestMethod]
        public void NotNullTest()
        {
            var collection = new List<string> { null, "hello" };
            collection.NotNull().Should().BeEquivalentTo(collection.Skip(1));
        }

        [TestMethod]
        public void MoveItemTest()
        {
            var list = new List<int> { 1, 2, 3 };
            list.MoveItem(2, 2).Should().BeEquivalentTo(new List<int> { 1, 3, 2 });
        }

        #endregion Test Methods
    }
}
