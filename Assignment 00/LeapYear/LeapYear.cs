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
            UserInputLeapYear();
        }


         public static void UserInputLeapYear(){
                Console.WriteLine("Enter a year to find out if it's a leapyear:");
                try 
                {
                    ValidateUserInput(GetUserInput());
                }
                catch  (Exception)
                {
                    Console.WriteLine("Only numbers are allowed.");
                }
                
            
        }

        public static void ValidateUserInput(int year)
        {
            try 
            {
                if(year < 1582) 
                {
                    throw new ArgumentException("Year has to be higher than 1582");
                } 
                else 
                {
                    if(new LeapYearFunctions().IsLeapYear(year))
                    {
                        Console.WriteLine("yay");
                    } else {
                        Console.WriteLine("nay");
                    }
                }
            } 
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static int GetUserInput()
        {
            string val;
            val = Console.ReadLine();
            return Convert.ToInt32(val);
        }
    }
}
