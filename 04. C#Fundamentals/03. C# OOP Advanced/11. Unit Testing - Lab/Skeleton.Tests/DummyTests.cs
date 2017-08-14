using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        [Test]
        public void DummyLosesHealth()
        {
            //Arange
            Dummy dummy = new Dummy(10, 10);
            Axe axe = new Axe(10, 10);

            //Action
            axe.Attack(dummy);

            Assert.IsTrue(dummy.Health == 0, "Dummy does not lose health when attacked!");
        }

        [Test]
        public void DeadDummyThrowsExceptionIfAttacked()
        {
            //Arange
            Dummy dummy = new Dummy(0, 0);
            Axe axe = new Axe(10, 10);
            
            //Assert
            Assert.Throws<InvalidOperationException>(() => dummy.TakeAttack(axe.AttackPoints));
        }

        [Test]
        public void DeadDummyCanGiveXP()
        {
            Dummy dummy = new Dummy(0, 10);
            Axe axe = new Axe(10, 10);

            //Assert
            Assert.IsTrue(dummy.GiveExperience() >= 0, "Dummy does not give experience!");
        }

        [Test]
        public void AliveDummyCantGiveXP()
        {
            Dummy dummy = new Dummy(10, 10);
            Axe axe = new Axe(5, 5);

            axe.Attack(dummy);

            Assert.Throws<InvalidOperationException>(() => dummy.GiveExperience(), "Dummy gives XP!");
        }
    }
}
