//Definition of Done: it is capable of performing its basic intended function(s), 
//and has been tested to ensure functionality.

public class NumberReduction{
	string temp = 0;	//temporary storage variable
	int num1 = 0;	//first user number
	int num2 = 0;	//second user number
	
	public static void Main(){
		//get the first number from the user, make sure it is can be parsed as an int,
		//then parse it, looping back around until valid input is recieved
		Console.WriteLine("Enter a positive, non-zero number: ");
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
	
		ReduceNumber(num1 + num2);
	}
	
	//A method capable of calling itself to reduce an integer passed as a parameter, 
	//through a specific process, until the end result is a single digit integer.
	public int ReduceNumber(int numberToReduce){
		if(numberToReduce.ToString.Length == 1){
			Console.WriteLine($"The final number is: {numberToReduce}");
		}

		//convert the number passed into a string.
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