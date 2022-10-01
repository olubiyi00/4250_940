WCK- The point of the exercise was to think the problem out before coding it. To take time to understand the requirements 
by doing a design, to define test cases and test data, etc.
	I get the feeling from looking at the code that you didn't do the above. Did you just start writing code because it seemed like
	a simple problem???
	I'm pretty sure your solution does not work for. Try MaxInt,MaxInt; Try MaxInt,0; Try MaxInt,1; try 0,0
	
	Seems like you are constraining the inputs to positive integers but I don't see that stated. It is not stated in the problem I gave.
	
You file title implies more than one person worked on this. I asked everyone to enter all the team members names if you did work in a team.
So, who worked on this?

	Perhaps you should try again? You are close but I would rather have seen a design that accounted for everything and some test cases and ZERO code
	than to see code that isn't robust
		
	
feedback inlined below is prefixed WCK-
	
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;           ; WCK- why threading??

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
			WCK- good use of descriptive variable names; eliminates the need for some comments 

			int sum = num1 + num2;                WCK- what if the sum is > maxInt or <-maxInt?
				                              
			int leastSig = sum % 10;

			int length = (int)Math.Floor(Math.Log10(sum) + 1);

			int modNum = 1;
			for(int i = 0; i < length - 1; i++)  WCK- why are you doing this??
			{
				modNum *= 10;
			}

			int otherDigits = sum % modNum;   WCK- I don't think this is going to work. did you test this? shouldn't it be 
				                                       int otherDigits = sum/10;

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
			Console.WriteLine("Enter 1st number: ");    WCK- no guidance as to what kind? Are you constraining the inputs at all? 
				                                         you are constraining to integers at a minimum so include that in the user prompt
			int num1;
			String num = Console.ReadLine();
			while(!num.All(char.IsDigit) || num.Equals(""))   WCK- won't this fail if they have a leading or trailing space when they input a number
			{
				Console.WriteLine("Please enter a number. ");
				num = Console.ReadLine();
			}
			Int32.TryParse(num, out num1);    ; WCK- you don't initialize num1 above; if TryParse fails, num1 remains unchanged (that is, undefined)
				                            You don't check the return value of TryParse to know if you can proceed. you are assuming based on the 
				                            while condition above. Not good practice (unless you state the assumption in the code). If someone
								    changes the while condition, this might fail. 

			Console.WriteLine("Enter 2nd number: ");
			while (!num.All(char.IsDigit) || num.Equals(""))
			{
				Console.WriteLine("Please enter a number. ");
				num = Console.ReadLine();
			}
			int num2;
			num = Console.ReadLine();          WCK- why are you reading the number in again? this time without any constraint checking?
				                                I think this line is misplaced and should appear above the while loop but because you
									are using num in the 2nd while condition it still has the value that passed the 
								 	1st while condition. So, if you test the happy path, everything works but if you
										enter an invalid input for the second number it won't get caught because
										you don't check the output of TryParse below. So, Num2 is undefined in 
										that scenario; could be zero but then maybe not
			Int32.TryParse(num, out num2);

			int res = getDownToSingle(num1, num2);

		}
	}
}
