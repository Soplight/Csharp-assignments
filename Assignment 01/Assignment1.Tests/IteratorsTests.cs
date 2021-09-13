using Xunit;
using System;
using System.Collections.Generic;
using System.Collections;

namespace Assignment1.Tests
{
    public class IteratorsTests
    {

        /*[Theory]
        [InlineData(new object[][]{new object[]{1,3,6,576,10}}, new object[]{1,3,6,576,10})]//you can pass arrays to this but not arrays of arrays?*/
        [Fact]
        public void Test_Flatten_That_It_Returns_All_Elements()
        {
            //Arrange
            var enumerable = new List<List<object>>(){new List<object>(){1,"MIP","wowow", true, false}};
            var enumerable2 = new object[][]{new object[]{1,"MIP","wowow", true, false}};
            var expected = new object[]{1,"MIP","wowow", true, false};
            //Act
            var result = Iterators.Flatten<object>(enumerable2);            
            //Assert
            Assert.Equal(result, expected);
        }

        public static bool Even(int i)
        {
            return i % 2 == 0;
        }

        Predicate<int> even = Even;

        [Fact]
        public void Test_Filter()
        {
            //Arrange
            var enumerable = new int[]{1,2,3,4,5,6};
            var expected = new int[]{2, 4, 6};

            //Act
            var result = Iterators.Filter(enumerable, even);

            //Assert
            Assert.Equal(result, expected);
        }
    }
}
