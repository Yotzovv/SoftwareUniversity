using NUnit.Framework;
using Skeleton.Abstraction.Interfaces;

namespace Skeleton.Tests
{
    [TestFixture]
    public class HeroTests
    {
        [Test]
        public void HeroGainsExperienceAfterAttackIfTargetDies()
        {
            ITarget fakeTarget = new Dummy(10, 10);
            Hero hero = new Hero("Camrollont");

            hero.Attack(fakeTarget);

            Assert.IsTrue(hero.Experience == 10, "Hero gains no experience!");
        }
    }
}
