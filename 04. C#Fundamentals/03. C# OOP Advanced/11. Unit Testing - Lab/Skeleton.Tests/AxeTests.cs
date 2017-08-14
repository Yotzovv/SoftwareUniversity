using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
    {
        [Test]
        public void AxeLosesDurabilityAfterAttack()
        {
            //Arranfge
            Axe axe = new Axe(10, 10);
            Dummy dummy = new Dummy(10, 10);

            //Action
            axe.Attack(dummy);

            //Assert
            Assert.AreEqual(9, axe.DurabilityPoints, @"Axe durability doesn't change after attack.");
        }

        [Test]
        public void AttackWithBrokenAxe()
        {
            //Arrange
            Axe axe = new Axe(1, 1);
            Dummy dummy = new Dummy(20, 20);

            //Action
            axe.Attack(dummy);

            //Assert
            Assert.Throws<InvalidOperationException>(() => axe.Attack(dummy));
        }
    }
}
