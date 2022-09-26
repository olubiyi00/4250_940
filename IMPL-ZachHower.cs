using System;

namespace Exercise
{
    class Program
    {
        /* Using Recursion; take two numbers in from the user (a human) 
         * and add them together then separate the least significant digit 
         * and add it the remaining digits and so on until you have a single digit answer. */

        /*My definition of Done: Fully functional and able to complete its  task or satisfy the demands of the specification without issues.*/ 
        
        static void Main(string[] args)
        {
            Console.WriteLine("Hello User, we are going to do a thing. To start follow the instructions below.");

            //Get user input for first number and store it as int. (exception possiblities: user enters a blank, or letter, or symbol, or negative)
            Console.WriteLine("Enter in a number greater than 10: ");
            int firstNumber;
            int.TryParse(Console.ReadLine(), out firstNumber);

            //Get user input for second number and store it as int. (exception possiblities: user enters a blank, or letter, or symbol, or negative)
            Console.WriteLine("Please enter in a second number greater than 10: ");
            int secondNumber; 
            int.TryParse(Console.ReadLine(), out secondNumber);

            //Test numbers if valid enough
            if (firstNumber <= 10 && secondNumber <= 10)
            {
                Console.WriteLine("Alright you have entered: " + firstNumber + " and " + secondNumber + ". Now working magic: ");
                //Call the recursive function. 
                Console.WriteLine(RecursiveFunctionOne(firstNumber, secondNumber) + "Is the final ending number.");

                Console.WriteLine("Done. Press any key to exit.");
                Console.Read();

            }
            else
            {
                Console.WriteLine("Invalid number set");
                Console.WriteLine("Press any key to exit.");
                Console.Read();
            }
        }


        public static int RecursiveFunctionOne(int numOne, int numTwo)
        {
            //exit of recursive function
            if (numOne+numTwo < 10) return numOne+numTwo;

            //Now the function takes the two numbers, adds them, pulls the least significant digit and then recalls the function to add again.
            Console.WriteLine(numOne + " + " + numTwo);
            numOne = numOne + numTwo;
            Console.Write(" = " + numOne);
            Console.WriteLine();
            numTwo = numOne % 10;
            Console.WriteLine("Least Significant Digit is : " + numTwo);
            numOne = numOne / 10;
            return RecursiveFunctionOne(numOne, numTwo); //recursive call
        }
    }
}
