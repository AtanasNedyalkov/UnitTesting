namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class WarriorTests
    {

        [Test]
        public void IsConstructorIsWorkingCorrectly()
        {
            string expectedName = "Pesho";
            int expectedDamage = 50;
            int expectedHp = 60;

            Warrior warrior = new Warrior(expectedName, expectedDamage, expectedHp);

            string actualName = warrior.Name;
            int actualDamage = warrior.Damage;
            int actualHp = warrior.HP;

            Assert.AreEqual(expectedName, actualName, "Constructor should initialize the name of the Warrior");
            Assert.AreEqual(expectedDamage, actualDamage, "Constructor should initialize the damage of the Warrior");
        }
        [Test]
        public void GetterNameShouldGetNameProperly()
        {
            string expectedName = "Pesho";
            Warrior warrior = new Warrior(expectedName, 50, 60);

            string actualName = warrior.Name;
            Assert.AreEqual(expectedName, actualName, "Name should be get properly and return the value of Name");
        }
        [TestCase(null)]
        [TestCase("")]
        [TestCase("     ")]
        public void SetterNameValidation(string testName)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior(testName, 50, 60);
            }, "Name should not be empty or whitespace!");
        }
        [Test]
        public void GetterDamageWorksProperly()
        {
            int expectedDamage = 55;
            Warrior warrior = new Warrior("Pesho", expectedDamage, 60);
            int actualDamage = warrior.Damage;

            Assert.AreEqual(expectedDamage, actualDamage, "Getter of prop should return the value of damage");
        }
        [TestCase(0)]
        [TestCase(-1)]
        public void SetterOfDamageValidation(int testDamage)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior("Pesho", testDamage, 60);
            }, "Damage value should be positive!");
        }
        [TestCase(0)]
        [TestCase(29)]
        [TestCase(30)]
        public void AttackWhenHpIsTooLow(int startHp)
        {
            Warrior warriorAttack = new Warrior("Pesho", 60, startHp);
            Warrior warriorDeffend = new Warrior("Pesho", 60, 50);
            Assert.Throws<InvalidOperationException>(() =>
            {
                warriorAttack.Attack(warriorDeffend);
            }, "Your HP is too low in order to attack other warriors!");

        }
    }
}