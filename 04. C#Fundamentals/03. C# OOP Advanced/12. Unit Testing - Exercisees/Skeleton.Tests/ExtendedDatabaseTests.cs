using NUnit.Framework;
using Skeleton.Models;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class ExtendedDatabaseTests
    {
        [Test]
        public void UsernamesAreUnique()
        {
            Person[] people = { new Person(1, "Suzanitta"), new Person(2, "Suzanitta") };
            Assert.Throws<InvalidOperationException>(() => new ExtendedDatabase(people));
        }

        [Test]
        public void IdsAreUnique()
        {
            Person[] people = { new Person(1, "Suzanitta"), new Person(1, "Suzka") };
            Assert.Throws<InvalidOperationException>(() => new ExtendedDatabase(people));
        }

        [Test]
        public void ChecksIfUsernameToRemoveExists()
        {
            Assert.Throws<InvalidOperationException>(() => new ExtendedDatabase().Remove("Stoiko"));
        }

        [Test]
        public void ChecksIfUsernameToFindExists()
        {
            Assert.Throws<InvalidOperationException>(() => new ExtendedDatabase().FindByUsername("Stoiko"));
        }

        [Test]
        public void CheksIfUsernameGivenToFindIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => new ExtendedDatabase().FindByUsername(null));
        }

        [Test]
        public void ChecksIfUserIsPresentById()
        {
            Assert.Throws<InvalidOperationException>(() => new ExtendedDatabase().FindById(3));
        }

        [Test]
        public void ChecksIfIdsArePositive()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new ExtendedDatabase().FindById(-2));
        }
    }
}
