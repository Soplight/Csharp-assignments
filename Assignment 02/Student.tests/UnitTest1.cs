using System;
using Xunit;

namespace Assignment_02
{
    public class UnitTest1
    {
        [Fact]
        public void Test_Status_New_Given_With_Datetime_Now()
        {
            //Arrange
            var expected = "This is Student 1. Name is Sop Merv. His current study status is: New";

            var stu = new Student(1, DateTime.Now.AddYears(3), DateTime.Now.AddMonths(-4), DateTime.Now.AddYears(3), "Sop", "Merv");

            //Act
            var result = stu.ToString();
            //Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Test_Status_Active_Given_With_Datetime_Now()
        {
            //Arrange
            var expected = "This is Student 1. Name is Sop Merv. His current study status is: Active";

            var stu = new Student(1, DateTime.Now.AddYears(3), DateTime.Now.AddYears(-3), DateTime.Now.AddYears(3), "Sop", "Merv");

            //Act
            var result = stu.ToString();
            //Assert
            Assert.Equal(expected, result);
        }


    }
}
