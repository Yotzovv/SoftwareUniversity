using NUnit.Framework;
using Skeleton.Models;
using System;

namespace Skeleton.Tests
{
    public class ListIteratorTests
    {
        [Test]
        public void ChecksIfAnyPassedValueIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => new ListIterator(null));
        }
    }
}
