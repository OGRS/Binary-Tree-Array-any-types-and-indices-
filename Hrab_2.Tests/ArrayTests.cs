using System;
using Hrab_2.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Hrab_2.Tests
{
    [TestClass]
    public class ArrayTests
    {
        [TestMethod]
        public void Array_WhenInitialIndex5AndLength10_EndIndexMustBe14()
        {
            One_DimensionalArray array = new One_DimensionalArray(5, 10);

            int end_index = 14;

            Assert.AreEqual(end_index, array.end_index, "The end index is not correct.");
        }

        [TestMethod]
        public void Indexer_WhenIndexIsWrong_ShouldThrowArgumentOutOfRangeExeption()
        {
            One_DimensionalArray array = new One_DimensionalArray(5, 5);

            try
            {
                array[1] = 51;
            }
            catch(ArgumentOutOfRangeException)
            {
                Assert.IsTrue(true);
                return;
            }

            Assert.Fail("No exeption was thrown.");
        }

        [TestMethod]
        public void Indexer_Set10InIndex5_Get10InIndex5()
        {
            One_DimensionalArray array = new One_DimensionalArray(5, 1);

            int element = 10;

            array[5] = 10;

            Assert.AreEqual(element, array[5], "Number is incorrectly written to array.");
        }
    }
}
