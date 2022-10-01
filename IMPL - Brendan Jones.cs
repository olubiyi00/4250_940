WCK- Overall good job. The point of the exercise was to think the problem out before coding it. To take time to understand the requirements 
by doing a design, to define test cases and test data, etc. Did you do that? Your solution is good but I don't see the artifacts of a design. AkA Show your work.
	Your comments are very good. 
	You use some descriptive naming (but num1,num2 why not call them firstUserNumber and secondUserNumber? more descriptive)
	You use a brute force string manipulation approach which looks like it will work .
	You constrained the problem to avoid dealing with floats and negatives. IF you think about it a bit more, could you handle those cases too?
	You do some good validation for the inputs.
	Would have been good to restate the problem at the top of the file to give context.
	Not having the test cases laid out is why you probably didn't catch the maxInt issue.
feedback inlined below prefixed by WCK-


//Definition of Done: it is capable of performing its basic intended function(s), 
//and has been tested to ensure functionality.

public class NumberReduction{
	string temp = 0;	//temporary storage variable
	int num1 = 0;	//first user number
	int num2 = 0;	//second user number
	
	public static void Main(){
		//get the first number from the user, make sure it is can be parsed as an int,            WCK- "as an int" but code enforces non-negative int
		//then parse it, looping back around until valid input is recieved
		Console.WriteLine("Enter a positive, non-zero number: ");                        WCK- you don't reprompt if an error? no err msg if not an int.
		while(num1 == 0){
			temp = Console.ReadLine();
			if(Int32.TryParse(temp))
			{
				if(Int32.Parse(temp) > 0)                        
					num1 = Int32.Parse(temp);
				else
					Console.WriteLine("Invalid Input! Enter a positive, non-zero number.");
			}
		}

		//get the second number from the user, make sure it is can be parsed as an int,
		//then parse it, looping back around until valid input is recieved
		Console.WriteLine("Enter another positive, non-zero number: ");
		while(num2 == 0){
			temp = Console.ReadLine();
			if(Int32.TryParse(temp))
			{
				if(Int32.Parse(temp) > 0)
					num2 = Int32.Parse(temp);
				else
					Console.WriteLine("Invalid Input! Enter a positive, non-zero number.");
			}
		}
	
		ReduceNumber(num1 + num2);                     WCK- what if num1 and num2 are both maxInt or sum to > maxInt; 
	}
	
	//A method capable of calling itself to reduce an integer passed as a parameter, 
	//through a specific process, until the end result is a single digit integer.
	public int ReduceNumber(int numberToReduce){                                  WCK- what is the return value for?
		if(numberToReduce.ToString.Length == 1){
			Console.WriteLine($"The final number is: {numberToReduce}");
		}

		//convert the number passed into a string.                        WCK- you use a lot of string conversions; are these expensive?
		string numString = numberToReduce.ToString();
		//get the last digit.
		string numSubstring1 = numString[numString.Length - 1];
		//separate the remainder of the number
		string numSubstring2 = numString.Remove(numString.Length - 1);

		//combine the two numbers for reduction, after parsing them back into integers.
		newNumberToReduce = Int32.Parse(numSubstring1) + Int32.Parse(numSubstring2);
		ReduceNumber(newNumberToReduce);
		return 0;
	}
}
