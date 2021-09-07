using System;

namespace LeapYear
{
    public class LeapYearFunctions
    {
        public bool IsLeapYear(int year)
        {
            if (year % 4 == 0) //Is year divisible by 4?
            {
                if(year % 100 == 0) //Is year divisible by 100?
                {
                    if(year % 400 == 0) //if divisible by 400, is leap year.
                    {
                        return true;
                    }
                    return false;//if not, it is not a leap year
                }
            }
        return false;//if not divisible by 4, is not leap year. 
        }

        public static void Main(string[] args) 
        {
            new LeapYearFunctions().UserInputLeapYear();
        }


         public void UserInputLeapYear(){
                var l = new LeapYearFunctions();
                Console.WriteLine("Enter a number to see if it's a leapyear!:");
                
                var yearbool = l.IsLeapYear(l.GetUserInput());

                if(yearbool)
                {
                    Console.WriteLine("yay");
                } else {
                    Console.WriteLine("nay");
                }
            
        }

        public int GetUserInput()
        {
            string val;
            val = Console.ReadLine();
            return Convert.ToInt32(val);
        }
    }
}
