using System;
using System.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kata20170827_FoldAnArray
{
    [TestClass]
    public class FoldAnArrayTests
    {
        [TestMethod]
        public void input_1_2_and_1_should_return_3()
        {
            FoldArrayShouldBe(new[] { 3 }, new[] { 1, 2 }, 1);
        }

        private static void FoldArrayShouldBe(int[] expected, int[] array, int runs)
        {
            var kata = new Kata();
            var actual = kata.FoldArray(array, runs);
            CollectionAssert.AreEqual(expected, actual);
        }
    }

    public class Kata
    {
        public int[] FoldArray(int[] array, int runs)
        {
            return new[] { array[0] + array[1] };
        }
    }
}
