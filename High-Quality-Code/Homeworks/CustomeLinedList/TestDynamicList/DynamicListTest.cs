using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using CustomLinkedList;

namespace TestDynamicList
{
    [TestClass]
    public class DynamicListTest
    {
        // Use ClassInitialize to run code before running the first test in the class
        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
        }

        // Use ClassCleanup to run code after all tests in a class have run
        [ClassCleanup]
        public static void ClassCleanup()
        {
        }

        // Use TestInitialize to run code before running each test
        [TestInitialize]
        public void TestInitialize()
        {
        }

        // Use TestCleanup to run code after each test has run
        [TestCleanup]
        public void TestCleanup()
        {
        }

        [TestMethod]
        public void TestDynamicListConstructorAndCounter()
        {
            var testDynamicList = new DynamicList<int>();
            Assert.AreEqual(testDynamicList.Count, 0);
            Assert.AreNotEqual(testDynamicList.Count, 1);
        }

        [TestMethod]
        public void TestDynamicListAddMethodToEmptyAndNonEmptyList()
        {
            var testDynamicList = new DynamicList<double>();
            testDynamicList.Add(1.1);
            Assert.AreEqual(testDynamicList.Count, 1);

            testDynamicList.Add(2.2);
            Assert.AreEqual(testDynamicList.Count, 2);
            Assert.AreNotEqual(testDynamicList.Count, 3);
        }

        [TestMethod]
        public void TestDynamicListIndexerGetterAndSetter()
        {
            var testDynamicList = new DynamicList<string>();
            testDynamicList.Add("first");
            string equalString = testDynamicList[0];
            Assert.AreEqual(testDynamicList[0], equalString);

            testDynamicList[0] = "scond";
            string notEqualString = "notSecond";
            Assert.AreNotEqual(testDynamicList[0], notEqualString);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestDynamicListIndexerOutOfRangeGetter()
        {
            var testDynamicList = new DynamicList<string>();
            string firstString = testDynamicList[0];;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestDynamicListIndexerOutOfRangeSetter()
        {
            var testDynamicList = new DynamicList<string>();
            testDynamicList[1] = "out of range";
            testDynamicList[-1] = "out of range";
        }

        [TestMethod]
        public void TestDynamicListRemoveAtMethodWithCorrectData()
        {
            var testDynamicList = new DynamicList<decimal>();
            decimal elementToAdd = 1.5m;
            testDynamicList.Add(elementToAdd);
            Assert.AreEqual(testDynamicList.Count, 1);

            decimal removedElement = testDynamicList.RemoveAt(0);
            Assert.AreEqual(testDynamicList.Count, 0);
            Assert.AreEqual(removedElement, 1.5m);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestDynamicListRemoveAtMethodWithOutOfRangeParameeters()
        {
            var testDynamicList = new DynamicList<char>();
            testDynamicList.Add('*');
            testDynamicList.RemoveAt(1);
        }

        [TestMethod]
        public void TestDynamicListRemoveMethod()
        {
            var testDynamicList = new DynamicList<int>();
            int elementToAdd = 1;
            testDynamicList.Add(elementToAdd);
            testDynamicList.Add(2);
            int returnedElementIndex = testDynamicList.Remove(2);

            Assert.AreEqual(testDynamicList.Count, 1);
            Assert.AreEqual(returnedElementIndex, 1);

            int returnedNotFoundElementIndex = testDynamicList.Remove(3);
            Assert.AreEqual(returnedNotFoundElementIndex, -1);
        }

        [TestMethod]
        public void TestDynamicLisIndexOfMethod()
        {
            var testDynamicList = new DynamicList<double>();
            double elementToAdd = 1.44;
            testDynamicList.Add(elementToAdd);
            testDynamicList.Add(2.44);
            testDynamicList.Add(1.44);

            int returnedFirstFoundElementIndex = testDynamicList.IndexOf(1.44);

            Assert.AreEqual(returnedFirstFoundElementIndex, 0);

            int returnedNotFoundElementIndex = testDynamicList.IndexOf(3.44);
            Assert.AreEqual(returnedNotFoundElementIndex, -1);
        }

        [TestMethod]
        public void TestDynamicLisContainsMethod()
        {
            var testDynamicList = new DynamicList<string>();
            testDynamicList.Add("first");
            testDynamicList.Add("Second");
            Assert.IsTrue(testDynamicList.Contains("first"));
            Assert.IsFalse(testDynamicList.Contains("not Second"));
        }


    }
}
