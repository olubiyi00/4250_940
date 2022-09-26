using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSCI4250Excercise
{
	class Program
	{
		/*
		 * Using Recursion; take two numbers in from the user (a human) and add them together then separate the least 
		 * significant digit and add it to the remaining digits and so on until you have a single digit answer. 

		*/
		public static int getDownToSingle(int num1, int num2)
		{

			int sum = num1 + num2;
			int leastSig = sum % 10;

			int length = (int)Math.Floor(Math.Log10(sum) + 1);

			int modNum = 1;
			for(int i = 0; i < length - 1; i++)
			{
				modNum *= 10;
			}

			int otherDigits = sum % modNum;

			int res = leastSig + otherDigits;
			//base case, if the resulting number is a single digit, we return that number
			if (res < 10)
			{
				return res; 
			}
			else
			{
				return getDownToSingle(leastSig, otherDigits);
			}
		}
		static void Main(string[] args)
		{
			Console.WriteLine("Enter 1st number: ");
			int num1;
			String num = Console.ReadLine();
			while(!num.All(char.IsDigit) || num.Equals(""))
			{
				Console.WriteLine("Please enter a number. ");
				num = Console.ReadLine();
			}
			Int32.TryParse(num, out num1);

			Console.WriteLine("Enter 2nd number: ");
			while (!num.All(char.IsDigit) || num.Equals(""))
			{
				Console.WriteLine("Please enter a number. ");
				num = Console.ReadLine();
			}
			int num2;
			num = Console.ReadLine();
			Int32.TryParse(num, out num2);

			int res = getDownToSingle(num1, num2);

		}
	}
}
