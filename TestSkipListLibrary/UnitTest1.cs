using SkipListLibrary;

namespace TestSkipListLibrary
{
    [TestClass]
    public class UnitTest1
    {
        const int n = 10;

        [TestMethod]
        public void TestCountEqualZeroAfterInit()
        {
            SkipList<string, int> skipList = new SkipList<string, int>();
            Assert.AreEqual(0, skipList.Count);
        }

        [TestMethod]
        public void TestCountAfterAddedIncrement()
        {
            SkipList<string, int> skipList = new SkipList<string, int>();
            skipList.Add("123", 123);
            Assert.AreEqual(1, skipList.Count);
        }

        [TestMethod]
        public void TestCountEqualZeroAfterAddedAndRemove()
        {
            SkipList<string, int> skipList = new SkipList<string, int>();
            skipList.Add("123", 123);
            skipList.Remove("123");
            Assert.AreEqual(0, skipList.Count);
        }

        [TestMethod]
        public void TestAddCountEqualCountAddedElements()
        {
            SkipList<string, int> skipList = new SkipList<string, int>();
            for (int i = 0; i < n; i++)
            {
                skipList.Add(i.ToString(), i);
            }
            Assert.AreEqual(n, skipList.Count);
        }

        [TestMethod]
        public void TestCountEqualZeroAfterAddedAndRemoveSomeElements()
        {
            SkipList<string, int> skipList = new SkipList<string, int>();
            for (int i = 0; i < n; i++)
            {
                skipList.Add(i.ToString(), i);
            }
            for (int i = 0; i < n; i++)
            {
                skipList.Remove(i.ToString());
            }

            Assert.AreEqual(0, skipList.Count);
        }

        [TestMethod]
        public void TestGetElementsValuesEqualsAddedValues()
        {
            SkipList<string, int> skipList = new SkipList<string, int>();
            for (int i = 0; i < n; i++)
            {
                skipList.Add(i.ToString(), i);
            }
            int GuessedValues = 0;
            for (int i = 0; i < n; i++)
            {
                int value = skipList.GetValue(i.ToString());
                if (value == i)
                    GuessedValues++;
            }

            Assert.AreEqual(n, GuessedValues);
        }

        [TestMethod]
        public void TestGetValueOrDefaultGettedAddedItem()
        {
            SkipList<string, int> skipList = new SkipList<string, int>();
            for (int i = 0; i < n; i++)
            {
                skipList.Add(i.ToString(), i);
            }
            int GuessedValues = 0;
            for (int i = 0; i < n; i++)
            {
                int value = skipList.GetValueOrDefault(i.ToString(), -1);
                if (value == i)
                    GuessedValues++;
            }

            Assert.AreEqual(n, GuessedValues);
        }

        [TestMethod]
        public void TestGetValueOrDefaultGettedDefault()
        {
            SkipList<string, int> skipList = new SkipList<string, int>();
            int GuessedValues = 0;
            for (int i = 0; i < n; i++)
            {
                int value = skipList.GetValueOrDefault(i.ToString(), -1);
                if (value == -1)
                    GuessedValues++;
            }

            Assert.AreEqual(n, GuessedValues);
        }
    }
}