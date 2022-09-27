// Creator: Payne Meade
// Email: Meadepa1@etsu.edu
// Date 9/26/2022
// Definition of Done: All requirements are met, Sufficient amount of testing has taken place, Comments are included and helpful

static void  LeastSig(int u1, int u2) //Used to get least signifcant digit
{
 int sum = u1 + u2;

    int lsDigit = sum / 10; //Calculate Least significant digit

    int remainDigit = sum - (lsDigit * 10); //Get remaining

    Console.WriteLine("Current least significant digit:" + lsDigit);

    if (lsDigit > 9) // Will check if single digit. Will also stop if it goes negative,
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
    Environment.Exit(0);
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

