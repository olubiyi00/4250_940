WCK- Overall, very good job. The point of the exercise was to think the problem out before coding it. To take time to understand the requirements 
by doing a design, to define test cases and test data, etc. You did most of that. AND you caught the test case I normally trip people up with (see bottom of file)

    Do you count spaces as a character? If I pass your document into itself when running, would it process "WCK-" or the whole thing or just up to the carriage return?
    Is counting spaces included in the requirements? That is to say, what do I mean when I say "a string".
        
  feedback inlined below prefixed by WCK-
    
using System;

namespace ClassExample.Controllers
{
    public class IMPT
    {
        /*
        Design:

        Take in a string(from a user or a file), compute the total number of
        occurrences of each character in the ASCII set. Print out the top three characters
        (with the most occurrences). Print out how many characters in the ASCII set you didn’t detect.
        Then print out the string in reverse order.
 
        1. Take a string from the user
        2. Turn every character of string into an arraylist
        3. Handle the arraylist to display 3 statements

        Display 3 print statements:
            - Top 3 occuring strings
            - How many ASCII characters were not in the string
            - Print the string in reverse order
        */
        
        static void Main(string[] args)
        {
            Console.WriteLine("Please input a string: \n");

            // This line takes the user input and turning it into a string.

            string input = Console.ReadLine();

            // This is Error Handling for when user inputs nothing. 
            if (input != String.Empty || input != null){}
            else
            {
                throw new ArgumentException("Input cannot be null or empty string", "input");
            }

            // Try-Catch handling for turning inputed string into an ArrayList. Any error with throw an exception.

            try
            {
                // Creating a new ArrayList of String of the input above where every character is a value
                // in the array list.

                List<String> inputList = new List<String>(Arrays.asList(input.split(",")));         WCK- string.split. clever
            }
            catch (Exception e1)
            {
                Console.WriteLine("String cannot be turned into Array List.");
                throw;
            }

            /// <summary>                                       WCK- could you sort the array inputList first and use that? 
                                                                    But I do like your logic here. It has some elegance and shows good understanding of String.
                                                                   it just might be more brute force than necessary; computational cost is not relevant for this
                                                                   problem but if this approach was used in a large loop it would add up.
            /// This block cycles through every character in the string and counts occurences to display.
            /// The purpose is to count every character in the List
            /// </summary>

            while (input.Length > 0)
            {
                // Displays the 0 (first) position character and then counts up for every position after.
                Console.Write(input[0] + " = ");

                int cal = 0; // This integer is the occurences counter and counts up for every instance.

                for (int i = 0; i < input.Length; i++)
                {
                    if (input[0] == input[i])
                    {
                        cal++;
                    }
                }

                Console.WriteLine(cal);
                input = input.Replace(input[0].ToString(), string.Empty);   
            }
        }

        /// <summary>
        /// This block of code cycles through every ArrayList character of the inputed string and compares
        /// them with an ArrayList of all ASCII values. A newly created ArrayList of all unused ASCII values
        /// will then be displayed
        /// </summary>

        // I am not sure how to complete the coding section of this part.           WCK- you could do the following
                                                                                      remove duplicates from inputList, sort it
                                                                                          iterate through the ascii char set (0-255)
                                                                                          keep count of how many chars do not appear in the inputList

        /// <summary>
        /// This block of code prints a reverse order of the inputed string ArrayList called inputList
        /// </summary>

        // Displays the values of the ArrayList.
        Console.WriteLine( "The ArrayList  contains the following values:" );
        IMPT(inputList);

        // Reverses the order of the values in the ArrayList.
        inputList.Reverse();

        // Displays the values in the ArrayList.
        Console.WriteLine( "After reversing:" );
        IMPT(inputList);

        /*
         - Definition of Done -
        With the problem given to me, I have created a design/plan to complete it.
        After the design was completed, I prepared the code with class and object structures.
        To start the coding process, I set up the user input to prepare for the 3 seperate print statements.
        I handled the user input to prepare for any unwanted inputs.
        I documented all blocks of code and any lines that needed aditional information.
        Although in the environment I worked in couldn't be tested, I went through the code to ensure accuracy.
        Therefore I believe the implementation of this problem is complete with the time allocated to me.   
        */
    }
}
