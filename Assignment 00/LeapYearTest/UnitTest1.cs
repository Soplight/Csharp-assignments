using System;
using System.IO;
using Xunit;
using LeapYear;

namespace LeapYearTest
{
    public class UnitTest1
    {
        [Theory]
        [InlineData(1700, false)]
        [InlineData(1800, false)]
        [InlineData(1900, false)]
        [InlineData(1600, true)]
        [InlineData(2000, true)]
        public void TestIsLeapYear(int i, bool expected)
        {
            var l = new LeapYearFunctions();
            var result = l.IsLeapYear(i);
            Assert.Equal(result, expected);
        }

        [Theory]
        [InlineData(1700, "nay")]
        [InlineData(1800, "nay")]
        [InlineData(1900, "nay")]
        [InlineData(1600, "yay")]
        [InlineData(2000, "yay")]
        public void TestUserInputYear(int year, string expected){
            //ARRANGE
            
            var writer = new StringWriter();
            Console.SetOut(writer);//takes output of console - does not account for newlines

            var reader = new StringReader(year.ToString());//input goes here
            Console.SetIn(reader);//input for console, takes year and puts it in console for main function
            
            //act
            LeapYearFunctions.Main(new string[] {});
            
            var output = writer.GetStringBuilder().ToString().Trim(); //takes out and converts it to string
            var sploutput = output.Split(' ', '\n');//takes output and splits on newlines \n
            
            //Assert
            Assert.Equal(expected, sploutput[1]);
        }
    }

    /*            Console.SetOut(writer); //sets output to writer
            l.Main(new string [2]);
            Console.WriteLine("Not a year");*/
}
