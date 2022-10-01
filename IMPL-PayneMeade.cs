WCK-  The point of the exercise was to think the problem out before coding it. To take time to understand the requirements 
by doing a design, to define test cases and test data, etc. 
 
It appears that you constrained the problem but I don't see the comments explaining this. Where is the problem definition, the design, the test cases, test data?
YOu don't validate the input to restrict negative numbers but your solution stops if it negative (doesn't it)?
You need more comments explaining what you are doing, why you are doing it

Feedback inlined below prefixed by WCK-

 // Creator: Payne Meade
// Email: Meadepa1@etsu.edu
// Date 9/26/2022
// Definition of Done: All requirements are met, Sufficient amount of testing has taken place, Comments are included and helpful   WCK- Very good

static void  LeastSig(int u1, int u2) //Used to get least signifcant digit
{
 int sum = u1 + u2;                                                     WCK - what if sum > max int? or < -max int?

    int lsDigit = sum / 10; //Calculate Least significant digit         WCK- point of clarification; the remainder is the lsd

    int remainDigit = sum - (lsDigit * 10); //Get remaining                  WCK- could use modulo

    Console.WriteLine("Current least significant digit:" + lsDigit);

    if (lsDigit > 9) // Will check if single digit. Will also stop if it goes negative,   WCK- does this work? if the sum is 12; lsDigit is 1, remainDigit is 2 
                                                                                               and you'll print 1 but the answer is 3
                                                                                               If it doesn't work, try this    if (sum >9)
    {
        LeastSig(lsDigit, remainDigit); //Recursion
    }
    


}
Console.WriteLine("Hello! Enter 2 whole numbers");

int user1 = 0, user2 = 0; //Made to store the user's input



try
{
    user1 = Convert.ToInt32(Console.ReadLine());
}
catch
{
    Console.WriteLine("Please try again. Application will now restart"); //If there is an error, it will show an error message then stop the app
    Environment.Exit(0);                 WCK- does the application restart as the prompt says or does it stop as the comment says?
}

try
{
    user2 = Convert.ToInt32(Console.ReadLine());
}
catch
{
    Console.WriteLine("Please try again. Application will now restart");
    Environment.Exit(0);
}

LeastSig(user1, user2);

