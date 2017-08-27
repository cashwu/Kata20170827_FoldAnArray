using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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

        [TestMethod]
        public void input_1_2_3_and_1_should_return_4_2()
        {
            FoldArrayShouldBe(new[] { 4, 2 }, new[] { 1, 2, 3 }, 1);
        }

        [TestMethod]
        public void input_1_2_3_4_5_and_1_should_return_6_6_3()
        {
            FoldArrayShouldBe(new[] { 6, 6, 3 }, new[] { 1, 2, 3, 4, 5 }, 1);
        }

        [TestMethod]
        public void input_1_2_3_4_5_and_2_should_return_9_6()
        {
            FoldArrayShouldBe(new[] { 9, 6 }, new[] { 1, 2, 3, 4, 5 }, 2);
        }

        [TestMethod]
        public void input_1_2_3_4_5_and_3_should_return_15()
        {
            FoldArrayShouldBe(new[] { 15 }, new[] { 1, 2, 3, 4, 5 }, 3);
        }

        [TestMethod]
        public void input_n9_9_n8_8_66_23_and_1_should_return_14_75_0()
        {
            FoldArrayShouldBe(new[] { 14, 75, 0 }, new[] { -9, 9, -8, 8, 66, 23 }, 1);
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
            var halfArrayLength = array.Length / 2;

            var result = array.Take(halfArrayLength).Zip(array.Reverse().Take(halfArrayLength), (a, b) => a + b).ToList();

            if (array.Length % 2 != 0)
            {
                result.Add(array[halfArrayLength]);
            }

            array = result.ToArray();

            runs--;

            return runs == 0 ? array : FoldArray(array, runs);
        }
    }
}
