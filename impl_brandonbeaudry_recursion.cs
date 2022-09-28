using System;
using System.IO;

/* Using Recursion; take two numbers in from the user (a human) and add them together 
 * then separate the least significant digit and add it the remaining digits and so
 * on until you have a single digit answer
 */

/* Definition of done: Print to the screen the final input of all additions or the
 * appropriate error message for failure
 */

/* Assumptions made: The last digit of a negative number is also negative when seperated
 */

public class impl_brandonbeaudry_recursion
{
    public static void Main()
    {
        string input = "";
        string firsthalf = "";
        string secondhalf = "";
        int a = 0; //First user input
        int b = 0; //Second user input
        int c = 0; //a + b

        Console.WriteLine("Input 2 numbers seperated by a space.");
        input = Console.ReadLine();
        input = input.Trim();//Remove the whitespace from the input

        //Stop if the number of inputs is greater than 2
        if (input.Split(' ').Length > 2)
        {
            Console.WriteLine("Too many values were given.");
            Environment.Exit(1);
        }
        //Stop if the number of inputs is less than 2
        if (input.Split(' ').Length < 2)
        {
            Console.WriteLine("Not enough values were given.");
            Environment.Exit(1);
        }
        firsthalf = input.Split(' ')[0]; //Takes the first input and puts it into firsthalf
        secondhalf = input.Split(' ')[1];//Takes the second input and puts it into firsthalf

        //checks to see if either value is valid for integer
        if(int.TryParse(firsthalf, out int res1) && int.TryParse(secondhalf, out int res2))
        {
            a = int.Parse(firsthalf);
            b = int.Parse(secondhalf);
        }
        else
        {
            Console.WriteLine("Either input is not valid for an integer (either too large/small, incorrect format, or input as a string.)");
            Environment.Exit(1);
        }
        c = a + b;

        /* Remove the last character from c and add it into C, repeat until C is a single number
         * The first condition checks if the integer to string is longer than 2, continuing for values of 100+ and -10 below
         * The second condition has two statements. 
         * The first statement checks if the integer to string is longer than 1, continuing for values of 10+ and -1 below
         * The second statement requires that the interger is not negative, which means it will not continue for any negative values
         * Only one has to be valid, so both are invalid for -9 to 9
         */
        while (c.ToString().Length > 2 || (c.ToString().Length > 1 && !(c.ToString().Substring(0,1).Equals("-"))))
        {
            int removelast = c / 10;    //with integers, dividing by 10 removes the last value
            int last = c % 10;          //with integer, modulus by 10 keeps only the last value
            c = removelast + last;
        }

        Console.WriteLine("Final Value: " + c);
    }
}
