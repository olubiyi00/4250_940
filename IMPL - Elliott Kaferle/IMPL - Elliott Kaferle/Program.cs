using System;
using System.Collections.Generic;

namespace IMPL___Elliott_Kaferle
{
    class Program
    {
        static List<int> Digit = new List<int>();
        String Numbers;
        static void Main(string[] args)
        {
            HumanInput();
            LeastSum(Digit);
            Console.WriteLine(Digit[0]);
        }

        static void HumanInput()
        {
            String Input1;
            String Input2;
            int Num1;
            int Num2;
            Console.WriteLine("Please input two numbers: ");    //accepting input from the user.
            Input1 = Console.ReadLine();
            Input2 = Console.ReadLine();

            Num1 = Int16.Parse(Input1);
            Num2 = Int16.Parse(Input2);

            Digit.Add(Num1);
            Digit.Add(Num2);
        }

        static void LeastSum(List<int> list)
        {
            int sum = 0;

            for (int i = 0; i < list.Count; i++)
            {
                sum = sum + list[i];
            } //taking the list and going through it and adding each index to the sum.


            String number = sum.ToString();
            var charArray = number.ToCharArray(); //separating the sum into digits through a CharArray
            sum = 0;
            for (int i = 0; i < charArray.Length - 1; i++)
            {
                sum = sum + (int)Char.GetNumericValue(charArray[i]);
            }

            number = sum.ToString();
            charArray = number.ToCharArray();
            sum = 0;
            foreach (var c in charArray)
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
