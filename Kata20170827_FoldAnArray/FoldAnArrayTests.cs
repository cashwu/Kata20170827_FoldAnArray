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
            for (var num = 1; num <= runs; num++)
            {
                var result = new List<int>();
                var halfArrayLength = array.Length / 2;
                for (var i = 0; i < halfArrayLength; i++)
                {
                    result.Add(array[i] + array[array.Length - 1 - i]);
                }

                if (array.Length % 2 != 0)
                {
                    result.Add(array[halfArrayLength]);
                }

                array = result.ToArray();
            }

            return array;
        }
    }
}
