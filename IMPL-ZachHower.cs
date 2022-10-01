WCK- The point of the exercise was to think the problem out before coding it. To take time to understand the requirements 
by doing a design, to define test cases and test data, etc. I don't see a design or testing. You do restate the problem which is a good idea.
    
    You constrained the problem by limiting inputs to integers above 10; this is fine, it makes it easier to solve but it is not in the description below so 
    you should call this out.
    
    What test cases did you use to test this? 
    Some good comments. You need some more 
    You validate your inputs but I don't know CS well enough to know if you are actually handling the user passing in a string instead of a number (I 
         suspect you aren't)
    You constrain it to above 10 but you condition only checks if BOTH numbers are <=10. I think you meant for this to be if EITHER are <=0
        THis is another edge case that should have been checked. Lower bound of 11 so test 10,11 and 11,10 and 11, 11 and 9,9 (fail, fail, pass, fail)
    
    feedback inlined with prefix of WCK-

using System;

namespace Exercise
{
    class Program
    {
        /* Using Recursion; take two numbers in from the user (a human) 
         * and add them together then separate the least significant digit 
         * and add it the remaining digits and so on until you have a single digit answer. */

        /*My definition of Done: Fully functional and able to complete its  task or satisfy the demands of the specification without issues.*/ 
                      WCK- DoD should also include updating design, all test cases pass (this is how you show it is fully functional and satisfies the spec)
                           - I think you are saying this but you could also be interpreting that it works with expected inputs so you consider that
                              fully functional .
                          - if I enter maxInt,maxInt; I'm pretty sure it fails
                          - if I enter MaxInt,0; I think it will work (this is called an edge case because MaxInt,1 should fail)
                                 
        
        static void Main(string[] args)
        {
            Console.WriteLine("Hello User, we are going to do a thing. To start follow the instructions below.");

            //Get user input for first number and store it as int. (exception possiblities: user enters a blank, or letter, or symbol, or negative)
            Console.WriteLine("Enter in a number greater than 10: ");
            int firstNumber;
            int.TryParse(Console.ReadLine(), out firstNumber);          WCK- what happens here? does it throw an exception or return a bool? 
                                                                      or set the output to zero if it can't parse??

            //Get user input for second number and store it as int. (exception possiblities: user enters a blank, or letter, or symbol, or negative)
            Console.WriteLine("Please enter in a second number greater than 10: ");
            int secondNumber; 
            int.TryParse(Console.ReadLine(), out secondNumber);

            //Test numbers if valid enough to continue, negatives, letters or too low of value numbers will be reject and program will end.
            if (firstNumber <= 10 && secondNumber <= 10)           WCK- what if one of the numbers is <= 10 and the other is not. is that okay? or did you mean ||
            {
                Console.WriteLine("Invalid number set");
                Console.WriteLine("Press any key to exit.");
                Console.Read();
            }
            else
            {
                Console.WriteLine("Alright you have entered: " + firstNumber + " and " + secondNumber + ". Now working magic: ");
                //Call the recursive function. 
                Console.WriteLine(RecursiveFunctionOne(firstNumber, secondNumber) + "Is the final ending number.");

                Console.WriteLine("Done. Press any key to exit.");
                Console.Read();
            }
        }

WCK- you need a comment for the method explaining the parameters and the assumption they must be positive and describe what the output is
    - I like that you used modulo and simple integer division
    
        public static int RecursiveFunctionOne(int numOne, int numTwo)
        {
            //exit of recursive function
            if (numOne+numTwo < 10) return numOne+numTwo;

            WCK- as stated in the required reading, having two or more exit points from a method is not good practice
                - why not set a local variable to be the sum so you don't have to keep adding numOne and numTwo (you do it 3 times)
                - what if numOne and numTwo add up to a number bigger than maxInt??
                    
            //Now the function takes the two numbers, adds them, pulls the least significant digit and then recalls the function to add again.
            Console.WriteLine(numOne + " + " + numTwo);
            numOne = numOne + numTwo;
            Console.Write(" = " + numOne);
            Console.WriteLine();
            numTwo = numOne % 10;
            Console.WriteLine("Least Significant Digit is : " + numTwo);     WCK- so you print this out each recursive call??? on purpose?
            numOne = numOne / 10;
            return RecursiveFunctionOne(numOne, numTwo); //recursive call
        }
    }
}
