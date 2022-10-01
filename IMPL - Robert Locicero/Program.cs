WCK- The point of the exercise was to think the problem out before coding it. To take time to understand the requirements 
by doing a design, to define test cases and test data, etc.
     I'm not seeing the artifacts for these. Did you test it?
     
     Nice comments, nice variable naming, good use of white space. but you forgot the last two items in the problem statement.
     
     more feedback inlined below prefixed with WCK-
     
     
     /*
 * Implementation Project - Robert LoCicero
 * Software Engineering 1
 * 
 * Take in a string (from a user or a file), compute the total number of occurrences of each character in the ASCII set. 
 * Print out the top three characters (with the most occurrences). Print out how many characters in the ASCII set you didn’t detect. 
 * Then print out the string in reverse order. 
 * */

/*
 * Robert Locicero - Software Engineer 1
 * Program.cs - Runs the implementation of the string problem
 * 
 * 
 */

using System.Text;

namespace impl
{
    /// <summary>
    /// Program class defines the methods to run the implementation of the problem
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Main function that calls other functions and runs the program.
        /// </summary>
        static void Main(string[] args)
        {
            int choice = GetInputType();
            //Gets the string outputs from either medium and runs the algorithm to count ASCII characters
            if(choice == 1)
            {
                DetectOccurences(GetFileInput());
            }
            else
            {
                DetectOccurences(GetStringInput());
            }
            WCK- what about a count on how many chars not detected? and reversing the string
        }

        /// <summary>
        /// Gets the users Input type
        /// 1 - For File
        /// 2 - For String
        /// Will continue to call itself until user input is valid
        /// </summary>
        /// <returns></returns>
        public static int GetInputType()
        {
            int choice;
            bool isValidChoice = true; //do while marks to false if it fails requirments

            do
            {
                Console.WriteLine("Would you like to enter a string or file?");
                Console.WriteLine("\tFile - Enter 1.\n\tString - Enter 2.");
                Console.Write("Choice: ");

                //TryParse will mark variable as false until user enters 1 or 2
                isValidChoice = Int32.TryParse(Console.ReadLine(), out choice);

                //Will then keep isValidChoice as true if the input is 1 or 2, else it will mark it back to false.
                if(choice < 0 || choice > 2)
                {
                    isValidChoice = false;
                    Console.Write("Invalid Choice try again.");
                }
                    
            } while(!isValidChoice);

            return choice;
        }

        /// <summary>
        /// Gets input string form file
        /// </summary>
        /// <returns></returns>
        public static string GetFileInput()
        {
            string? fileName; //is nullable because fileName will be handled dealt with if null
            bool isValidFile = true; //do while marks to false if it fails requirments

            do
            {
                Console.WriteLine("Enter the name of the input file in the project directory: ");
                fileName = Console.ReadLine();

                if (!File.Exists(fileName) || fileName == null || fileName.Length == 0)   WCK- I would change the order; check null, check empty, check exists
                                                                                               on the other hand. do you need to check null or empty; File.Exists 
                                                                                                    does already doesn't it?
                {
                    isValidFile = false;
                    Console.Write("File does not exist in project directory.");
                }
                else if(new FileInfo(fileName).Length == 0)
                {
                    isValidFile = false;
                    Console.WriteLine("File is empty. Pick another with content.");
                }

            } while(!isValidFile);

            List<string> lines = File.ReadAllLines(fileName).ToList();         WCK- ah,you include carriage returns in the input. cool. most people didn't
            return lines.ToString();
        }

        /// <summary>
        /// Gets string input from user
        /// </summary>
        /// <returns></returns>
        public static string GetStringInput()
        {
            string? stringInput; //is nullable because stringInput will be handled if null
            bool isValidString = true; //do while marks to false if it fails requirments

            do
            {
                Console.Write("Enter the string to be evaluated: ");
                stringInput = Console.ReadLine();

                if(stringInput == null || stringInput.Length == 0)
                {
                    Console.WriteLine("Invalid string try again.");
                }

            } while(!isValidString);

            return stringInput;
        }


        /// <summary>
        /// Creates a count for each occurce of all characters
        /// Then spits out the top 3 characters occured
        /// </summary>
        public static void DetectOccurences(string input)
        {
            Dictionary<char, int> charDict = new Dictionary<char, int>(); //each char (key) and its count (value)
            foreach(char c in input)
            {
                //Add the character to the dictionary and counts its first occurence if this is the first the char appeared in the loop
                if(!charDict.ContainsKey(c))
                {
                    charDict.Add(c, 1);
                }
                else
                {
                    charDict[c]++;
                }
            }

            
            var topThreeOccurences = charDict.OrderByDescending(x => x.Value).Take(3).ToList();        WCK- what if there's a tie; 5 4 3 3 3 3 2 (6 chars meet criteria)
                

            Console.WriteLine("Top 3 Occurences");
            foreach(KeyValuePair<char, int> keyValuePair in topThreeOccurences)
            {
                Console.WriteLine($"{keyValuePair.Key} - {keyValuePair.Value}");
            }
        }


    }
}
