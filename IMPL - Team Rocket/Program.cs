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
            string twoNums = Console.ReadLine(); // get both inputted numbers
            if (twoNums == null) {
                Console.WriteLine("Unknown input!");
                return;
            }

            string[] nums = twoNums.Split(' ');
            if (nums.Length < 2) {
                Console.WriteLine("Not enough numbers inputted!");
                return;
            }
            // get parsed versions of both inputted numbers
            int firstNum = Int32.Parse(nums[0]);
            int secondNum = Int32.Parse(nums[1]);

            // add both and input to recursive method
            int added = firstNum + secondNum;
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
            num = (num - lastDigit) / 10;
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
