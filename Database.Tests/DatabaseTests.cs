namespace Database.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    [TestFixture]
    public class DatabaseTests
    {
        private Database db;
        [SetUp]
        public void SetUp()
        {
            this.db = new Database();
        }

        [TestCase(new int[] {})]
        [TestCase(new int[] { 1 })]
        [TestCase(new int[] { 1, 2, 3 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void ConstructorShouldAddLessThan16Elements(int[]elementsToAdd)
        {
            //Arrange
            Database testdb = new Database(elementsToAdd);

            //Act
            int[] actualDate = testdb.Fetch();
            int[] expecteDate = elementsToAdd;

            int actualCount = testdb.Count;
            int expectedCount = expecteDate.Length;

            //Assert
            CollectionAssert.AreEqual(expecteDate, actualDate, "Database constructor should initialize data field correctly!");
            Assert.AreEqual(expectedCount, actualCount, "Constructor should set initial value for count field!");
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 18, 19 })]
        public void ConstructorMustNotAllowMoreThan16Elements(int[] elementsToAdd)
        {

            Assert.Throws<InvalidOperationException>(() =>
            {

                Database testDb = new Database(elementsToAdd);
            }, "Array's capacity must be exactly 16 integers!");
        }
        [Test]
        public void CountMustReturnActualCount()
        {
            int[] initData = new int[] { 1, 2, 3 };
            Database testDb = new Database(initData);

            int actualCount = testDb.Count;
            int expectedCount = initData.Length;

            Assert.AreEqual(actualCount, expectedCount, "Count should return the count of the added element");
        }
        [Test]
        public void CountMustReturnZeroWhenNoElements()
        {
            int actualCount = this.db.Count;
            int expectedCount = 0;

            Assert.AreEqual(actualCount, expectedCount, "Count must return zero when no elements");
        }
        [TestCase(new int[] { 1 })]
        [TestCase(new int[] { 1, 2, 3 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void AddMustBeLessThan16(int[]elementsToAdd)
        {
            foreach (int el in elementsToAdd)
            {
                this.db.Add(el);
            }
            int[] actualData = this.db.Fetch();
            int[] expectedData = elementsToAdd;

            int actualCount = this.db.Count;
            int expectedCount = elementsToAdd.Length;

            CollectionAssert.AreEqual(actualData, expectedData, "Add should add phisically element to the field");
            Assert.AreEqual(actualCount, expectedCount, "Add should change the element count when adding ");
        }
        [Test]
        public void AddShouldThrowExceptionWhenAddingMoreThank16Elements()
        {
            for (int i = 1; i <= 16; i++)
            {
                this.db.Add(i);
            }
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.db.Add(17);
            }, "Array capacity must be exectly 16 integers");
        }
        [TestCase(new int[] { 1 })]
        [TestCase(new int[] { 1, 2, 3 })]
        public void RemoveShouldRemoveLastElement(int[] startElements)
        {
            foreach (int el in startElements)
            {
                this.db.Add(el);
            }
            this.db.Remove();
            List<int> elList = new List<int>(startElements);
            elList.RemoveAt(elList.Count - 1);

            int[] actualData = this.db.Fetch();
            int[] expectedData = elList.ToArray();

            int actualCount = this.db.Count;
            int expectedCount = elList.Count;

            CollectionAssert.AreEqual(actualData, expectedData, "Remove must remove phisically element in data field");
            Assert.AreEqual(actualCount, expectedCount, "Remove should change count in collection");
        }
        [Test]
        public void RemoveShouldHaveRemoveMoreThanOnce()
        {
            List<int> initData = new List<int>() {1, 2, 3 };
            foreach (int el in initData)
            {
                this.db.Add(el);
            }
            for (int i = 0; i < initData.Count; i++)
            {
                this.db.Remove();
            }
            int[] actualData = this.db.Fetch();
            int[] expectedData = new int[] { };

            int actualCount  = this.db.Count;
            int expectedCount = 0;

            CollectionAssert.AreEqual(actualData, expectedData, "Remove should remove phisically element in data field");
            Assert.AreEqual(actualCount, expectedCount, "Remove should decrement the count of database");
        }
        [Test]
        public void RemoveShouldThrowExpectionWhenThereAreNoElements()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.db.Remove();
            }, "The collection is empty");
        }
        [TestCase(new int[] { })]
        [TestCase(new int[] { 1 })]
        [TestCase(new int[] { 1, 2, 3 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]

        public void FetchShouldReturnCopyArray(int[] elements)
        {
            foreach (int el in elements)
            {
                this.db.Add(el);
            }

            int[] actualData = this.db.Fetch();
            int[] expectedData = elements;

            CollectionAssert.AreEqual(actualData, expectedData, "Fetch should return the copy of existing data");
        }
    }
}
