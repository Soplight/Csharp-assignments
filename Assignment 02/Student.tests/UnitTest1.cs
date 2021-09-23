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
            var stu = new Student(1);
            stu.StartDate = DateTime.Now;
            stu.EndDate = new DateTime(2025, 1, 1);
            stu.Surname = "Merv";
            stu.GivenName = "Sop";
            //Act
            var result = stu.ToString();
            //Assert
            Assert.Equal(expected, result);
        }
    }
}
