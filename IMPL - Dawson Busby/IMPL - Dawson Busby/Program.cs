WCK- The point of the exercise was to think the problem out before coding it. To take time to understand the requirements 
by doing a design, to define test cases and test data, etc.
    I'm not seeing a design or test planning. I didn't even know which problem you were solving until I read the code.
    You need more comments. You need to think it through before coding (my impression is that you did not). Aspects of the solution are
    much more complicated than needed which makes it less maintainable.

    you forgot the requirement for printing out how many chars were not detected at all.
        
    additional feedback below prefixed by WCK-
    
    
    // See https://aka.ms/new-console-template for more information
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Linq;


//---------------------------
// Dawson Busby
// Software Engineering I
// ASCII Class Example 
// 9/26/2022
//---------------------------


// THIS PROGRAM WAS NOT FINISHED TOO MY LIKING BECAUSE I HAD TO LEAVE EARLY DUE TO DRIVING TO NEXT CLASS UNIX      WCK- you are welcome to continue work on it; 

//Variables used
string str = "";
Console.WriteLine("Enter a string value: ");
str = Console.ReadLine();
//Visual sake
Console.WriteLine();


//INPUT VALIDATION
if (string.IsNullOrEmpty(str))
{
    Console.WriteLine("String can't be empty! Input your string once more");
    str = Console.ReadLine();
}
//ASCII VALIDATION - Makes sure all values in string are ASCII, if not replace with empty.   ; WCK- how could they be anything else? 
str = Regex.Replace(str, @"[^\u0000-\u007F]+", string.Empty);        WCK- I always have to look up regex. Does this do what you want? HOw do you know?
                                                                          looks like you are comparing to charindex of 0-255. could it be anything else?


//assigning value to ascii conversion
byte[] ASCIIvalues = Encoding.ASCII.GetBytes(str);
List<int> list = new List<int>();

//Console.WriteLine("ASCII VALUES IN GIVEN STRING: ");
//Appending values to List to iterate through for reoccurences
//foreach (var value in ASCIIvalues)
//{
//    list.Add(value);
//    Console.Write(value + ", ");

//}


//Visual sake
Console.WriteLine();
//Detecting Duplicate values          WCK- might more comments than this; looks like you are doing a key-value pair where key is the char and value is the count?/?
Dictionary<int, int> dictDuplication = list.GroupBy(x => x)
                                    .Where(g => g.Count() > 1)
                                    .ToDictionary(x => x.Key, x => x.Count());

////Adding space for visual
//Console.WriteLine();
////Below processing code to show value, and the count
//Console.WriteLine("BELOW HAS VALUES THAT WERE DETECTED TO BE DUPLICATED IN FORMAT: (ASCII VALUE, # of reoccurence)");
//Console.WriteLine("" + String.Join(",", dictDuplication));

//VisualSake
Console.WriteLine(); 
Console.WriteLine("BELOW IS TOP 3 VALUES WITH MOST REOCCURENCES IN FORMAT: (ASCII VALUE, # of reoccurence)");       WCK- what if there is a tie; 5 4 3 3 3 3
var sortedDict = (from entry in dictDuplication orderby entry.Value descending select entry)
               .ToDictionary(pair => pair.Key, pair => pair.Value).Take(3);
Console.WriteLine("" + String.Join(",", sortedDict));

//Reversing string

char[] chars = str.ToCharArray();
Array.Reverse(chars);
string str1 = new string(chars);
Console.WriteLine("BELOW IS STRING REVERSED: ");
Console.WriteLine(str1);
