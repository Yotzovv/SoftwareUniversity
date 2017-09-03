using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Hell.Tests
{
    [TestFixture]
    public class InventoryTests
    {
        private HeroInventory sut;
        private IItem axe;
        private IItem sword;
        private IRecipe greatAxeRecipe;

        [SetUp]
        public void TestInit()
        {
            sut = new HeroInventory();
            axe = new CommonItem("Axe", 1, 2, 3, 1, 2);
            sword = new CommonItem("Sword", 1, 1, 1, 1, 1);
            greatAxeRecipe = new RecipeItem("GreatAxe", 5, 5, 6, 4, 4, new List<string>() { "Axe", "Sword" });

            sut.AddCommonItem(axe);
            sut.AddRecipeItem(greatAxeRecipe);
        }

        [Test]
        public void AddsItem()
        {
            Type itemsType = typeof(HeroInventory);
            var field = itemsType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                                 .FirstOrDefault(f => f.GetCustomAttribute(typeof(ItemAttribute)) != null);
            var collection = (Dictionary<string, IItem>)field.GetValue(this.sut);

            Assert.IsTrue(collection.Count == 1);
        }

        [Test]
        public void AddsRecipe()
        {
            Type hiType = typeof(HeroInventory);
            var field = hiType.GetField("recipeItems", BindingFlags.Instance | BindingFlags.NonPublic);
            var collection = (Dictionary<string, IRecipe>)field.GetValue(sut);

            Assert.IsTrue(collection.Count == 1);
        }

        [Test]
        public void GivesStrengthBonus()
        {
            Assert.IsTrue(sut.TotalStrengthBonus == 1);
        }

        [Test]
        public void GivesAgilityBonus()
        {
            Assert.IsTrue(sut.TotalAgilityBonus == 2);
        }

        [Test]
        public void GivesIntelligenceBonus()
        {
            Assert.IsTrue(sut.TotalIntelligenceBonus == 3);
        }

        [Test]
        public void GivesHitPointsBonus()
        {
            Assert.IsTrue(sut.TotalHitPointsBonus == 1);
        }

        [Test]
        public void GivesDmgBonus()
        {
            Assert.IsTrue(sut.TotalDamageBonus == 2);
        }

        [Test]
        public void DeletesReqItemsOnObtainingRecipeItems()
        {
            sut.AddCommonItem(sword);

            Assert.IsTrue(sut.TotalStrengthBonus == 5);
        }

        [Test]
        public void DuplicateItemThrowsException()
        {
            Assert.Throws<ArgumentException>(() => sut.AddCommonItem(axe));
        }

        [Test]
        public void DuplicateRecipeThrowsException()
        {
            Assert.Throws<ArgumentException>(() => sut.AddRecipeItem(greatAxeRecipe));
        }

        [Test]
        public void NewInventoryStatsEqualsZero()
        {
            sut = new HeroInventory();

            long totalStatsValue = sut.TotalAgilityBonus
                                 + sut.TotalStrengthBonus
                                 + sut.TotalIntelligenceBonus
                                 + sut.TotalHitPointsBonus
                                 + sut.TotalDamageBonus;

            Assert.IsTrue(totalStatsValue == 0);
        }

        [Test]
        public void CantAddNullAtItems()
        {
            Assert.Throws<NullReferenceException>(() => sut.AddCommonItem(null));
        }

        [Test]
        public void CantAddNullAtRecipes()
        {
            Assert.Throws<NullReferenceException>(() => sut.AddRecipeItem(null));
        }
    }
}
