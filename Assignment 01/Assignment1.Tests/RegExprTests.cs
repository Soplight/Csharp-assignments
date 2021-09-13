using Xunit;
using System;

namespace Assignment1.Tests
{
    public class RegExprTests
    {
        [Fact]
        public void Test_SplitLine_With_Spaces()
        {
            //Arrange
            var input = new string[]{"This is a test.", "ThIs IS aaaaaa test 69", "1000000"};
            var expected = new string[]{"This", "is", "a" ,"test" ,"ThIs", "IS", "aaaaaa", "test", "69", "1000000"};

            //act
            var result = RegExpr.SplitLine(input);
            
            foreach(var s in result)
            {
                  Console.WriteLine(s);
            }
            //Assert
            Assert.Equal(expected, result);
        }


        [Fact]
        public void Test_Regex_Resolution()
        {
            //Arrange
            var input = new string[]
            {"1920x1080", 
            "1024x768, 800x600, 640x480", 
            "320x200, 320x240, 800x600", 
            "1280x960"};

            var expected = new (int,int)[]
            {(1920, 1080), (1024, 768), (800, 600), 
            (640, 480), (320, 200), (320, 240), 
            (800, 600), (1280, 960)
            };

            //Act
            var result = RegExpr.Resolution(input);

            //Assert
            Assert.Equal(expected, result);

        }

    }

}
