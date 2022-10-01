WCK- The point of the exercise was to think the problem out before coding it. To take time to understand the requirements 
by doing a design, to define test cases and test data, etc.
You did all these! GREAT!
    I've already look at the other files before I opened this one. THere is feedback in each.
    
    Good comments. I followed everything pretty easily even though I don't know C#
    
    additional feedback inlined below prefixed with WCK-
    
using System;
using System.Diagnostics;
using System.Numerics;
using System.Collections.Generic;
using System.Linq;

/*
 * Implementation Project
 * Software Engineering 1
 * 
 * This project takes in two numbers, adds them together, and
 * then recursively takes the last digit off of the result.
 * It adds that last digit to the result (that is now missing the last digit).
 * It performs this until the result is a single digit (negative or positive).
 * It then returns that result.
 * 
 *
 * Christian Calhoun
 * Micah Crawford
 * Victoria Dixon 
 * Drew Dorris
 * Amanda Lee
 */
namespace Project1
{
    class Program
    {
        /*
         * Start of program
         */
        public static void Main(string[] args)
        {
            string twoNums = Console.ReadLine(); // get both inputted numbers   WCK- no prompt to the user as what to enter?
            if (twoNums == null) {               WCK- I don't know C# but twoNums couldn't be null the way it is declared above. I thought you had to expliciting
                                                      tell C# it can be nullable. WIth a preceding ?String twoNums =...          
                Console.WriteLine("Unknown input!");
                return;        WCK- multiple returns from the same method is discouraged ; makes it less maintainable
            }

            string[] nums = twoNums.Split(' ');   WCK- what if there is a preceding space or trailing. Shouldn't you trimwhitespace first?
                                                     WCK- what if there are three or more numbers? nums will have all of them. you ignore the rest???
            if (nums.Length < 2) {
                Console.WriteLine("Not enough numbers inputted!");
                return;
            }
            // get parsed versions of both inputted numbers
            int firstNum = Int32.Parse(nums[0]);                      WCK- what happens here if they aren't numeric? what if they are floats?
            int secondNum = Int32.Parse(nums[1]);

            // add both and input to recursive method
            int added = firstNum + secondNum;         WCK- what happens if the sum is > maxInt or <minInt
            Console.WriteLine("Added together: " + added);
            int result = GetLastDigitAddedWithRestOfNum(added);

            Console.WriteLine("Result is " + result);
            return;
        }

        // Method which recursively finds result of last value of number added with same number without that digit
        public static int GetLastDigitAddedWithRestOfNum(int num) {
            // This retrieves the last digit of the number
            int lastDigit = num % 10;
            //Console.WriteLine(lastDigit); // debug
            // This is the inputted number with the last digit removed. Reduce it by a factor of 10 and remove the last number.
            // Example
            // 953 ---> (953 - 3) / 10 ---> 95
            num = (num - lastDigit) / 10;     WCK- this works but no need to subtract lastDigit as the division will drop the remainder on the floor
                                                   
            //Console.WriteLine(num); // debug

            // Clarification was made that the last digit matches the sign of the rest of the number
            // We do not change the sign of the last digit
            int added = lastDigit + num;
            if (added < 10 && added > -10) {
                // It's a single digit, so we're done!
                return added;
            }
            Console.WriteLine("Currently at " + added); // this is for debug but displaying it anyway
            return GetLastDigitAddedWithRestOfNum(added);
        }

        // Unit test to verify correct result from normal values
        public static bool ReturnsCorrectResult() {
            // unimpl
            return false;
        }

        // Unit test to verify input that would result in a negative result does
        public static bool CanReturnNegative() {
            // unimpl
            return false;
        }

        // Only one digit inputted returns false
        public static bool ReturnsFromNotEnoughDigits() {
            // unimpl
            return false;
        }
    }
}
