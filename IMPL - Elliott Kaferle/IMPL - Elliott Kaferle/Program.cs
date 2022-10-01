WCK- The point of the exercise was to think the problem out before coding it. To take time to understand the requirements 
by doing a design, to define test cases and test data, etc. It doesn't look like you did any of this. 
    Just jumped into the code?? Required reading specifically said don't do this.
        
    so which problem are you solving? no comments about the purpose or the design??
    
    you have a unique approach using a List for all the digits. 
    
    more feedback below is prefixed by WCK-
    
    
using System;
using System.Collections.Generic;

namespace IMPL___Elliott_Kaferle
{
    class Program
    {
        static List<int> Digit = new List<int>();    WCK- using member data as "global variables" so you don't have to pass parameters??
                                                     WCK- why static? or everything is static. That's called procedural programming using an OO language.
                                                     WCK- why a list when you only want 2 numbers?
        String Numbers;
        static void Main(string[] args)
        {
            HumanInput();
            LeastSum(Digit);
            Console.WriteLine(Digit[0]);
        }

        static void HumanInput()
        {
            String Input1;                             WCK- what coding standard are you using. I've never seen variables start with capital letters AND
                                                              methods and classes also starting with capital letters. 
                                                            Why aren't you initializing variables at declaration; required reading said to do this.
            String Input2;
            int Num1;
            int Num2;
            Console.WriteLine("Please input two numbers: ");    //accepting input from the user.  WCK- should prompt them for integers if that is what you want
            Input1 = Console.ReadLine();
            Input2 = Console.ReadLine();

            Num1 = Int16.Parse(Input1);                   WCK- what happens if the Parse fails? because it is a string, a float, or a number>maxInt?
            Num2 = Int16.Parse(Input2);                  WCK- why parse with Int16? seems odd, should have a comment explaining why

            Digit.Add(Num1);
            Digit.Add(Num2);
        }

        static void LeastSum(List<int> list)                           WCK- now your variables start with lower case. Is there a standard? or were parts of the 
                                                                     program written by different people using different standards?
        {
            int sum = 0;

            for (int i = 0; i < list.Count; i++)
            {
                sum = sum + list[i];               WCK- what happens if sum > maxInt; since you accept negatives, what if sum<-maxInt?
            } //taking the list and going through it and adding each index to the sum.


            String number = sum.ToString();
            var charArray = number.ToCharArray(); //separating the sum into digits through a CharArray
            sum = 0;
            for (int i = 0; i < charArray.Length - 1; i++)
            {
                sum = sum + (int)Char.GetNumericValue(charArray[i]); WCK- this is not how the problem defined it; it was to pull off the LSB and
                                                                         add it to the remaining digits; you are adding all the digits together using
                                                                         a running sum. You may get the same answer or not, but it isn't what was asked for.
                                                                              Is the "(int)" a hard cast? If it isn't what is it? if it is, using a hard cast
                                                                             is dangerous. You are forcing the value to be an integer even if it isn't.
            }

            number = sum.ToString();
            charArray = number.ToCharArray();
            sum = 0;
            foreach (var c in charArray)                  WCK- I finally see why you used a List; this is why comments are needed. I had to read the whole 
                                                                program to understand why you were doing what you were doing at the start.
            {
                Digit.Clear();  //Clearing the list from earlier
                Digit.Add(c);
            }
            if (charArray.Length == 1)
            {

                return;
            }
            else
            {
                LeastSum(Digit);
            }
        }
    }
}
