using NUnit.Framework;
using Skeleton.Models;
using System;
using System.Linq;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DatabaseTests
    {
        [Test]
        public void StoringCapacityIs16IntegersAndCantAdd17thElement()
        {
            Assert.Throws<InvalidOperationException>(() => new Database(Enumerable.Range(0, 17).ToArray()));
        }

        [Test]
        public void AddsElementOnNextFreeCell()
        {
            Assert.IsTrue(new Database(Enumerable.Range(0, 16).ToArray()).Fetch().Last() == 15);
        }

        [Test]
        public void RemovesElementAtTheLastIndex()
        {
            Database db = new Database(Enumerable.Range(0, 16).ToArray());

            db.Remove();

            Assert.IsTrue(db.Fetch().Last() == 14);
        }

        [Test]
        public void CantRemoveFromEmptyDB()
        {
             Assert.Throws<InvalidOperationException>(() => new Database().Remove());
        }

        [Test]
        public void ConstructorStoresValuesInArrayAndFetchReturnsElements()
        {
            Database db = new Database(Enumerable.Range(0, 16).ToArray());

            Assert.AreEqual(db.Fetch(), Enumerable.Range(0, 16).ToArray());
        }
    }
}
