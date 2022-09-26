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


// THIS PROGRAM WAS NOT FINISHED TOO MY LIKING BECAUSE I HAD TO LEAVE EARLY DUE TO DRIVING TO NEXT CLASS UNIX

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
//ASCII VALIDATION - Makes sure all values in string are ASCII, if not replace with empty.
str = Regex.Replace(str, @"[^\u0000-\u007F]+", string.Empty);


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
//Detecting Duplicate values
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
Console.WriteLine("BELOW IS TOP 3 VALUES WITH MOST REOCCURENCES IN FORMAT: (ASCII VALUE, # of reoccurence)");
var sortedDict = (from entry in dictDuplication orderby entry.Value descending select entry)
               .ToDictionary(pair => pair.Key, pair => pair.Value).Take(3);
Console.WriteLine("" + String.Join(",", sortedDict));

//Reversing string

char[] chars = str.ToCharArray();
Array.Reverse(chars);
string str1 = new string(chars);
Console.WriteLine("BELOW IS STRING REVERSED: ");
Console.WriteLine(str1);
