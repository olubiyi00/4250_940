# Using Recursion; take two numbers in from the user (a human) and add them together 
# then separate the least significant digit and add it the remaining digits and so on 
# until you have a single digit answer.

# Tests: non-integer inputs, negative integer inputs, non-single digit answer

# Done: Calculates single digit answer given 2 user inputs and gracefully ends execution.
#       Notifies the user if any error occurs or if a single digit answer is not calculated.
#       Gracefully ends execution if an error occurs.

from math import floor, log10
import sys

# Returns the least significant digit until no digits are left for num1 and num2.
def addLeastSignificantDigit(num1, num2):
    while(num1 > 0):
        # Return least significant digit of num1 (num1 % 10) and recursively call to add next digit of num1.
        return num1 % 10 + addLeastSignificantDigit(floor(num1/10), num2)
    while(num2 > 0):
        # Return least significant digit of num2 (num2 % 10) and recursively call to add next digit of num2.
        return num2 % 10 + addLeastSignificantDigit(num1, floor(num2/10))
    return 0

# Returns the number of digits in num
def getNumDigits(num):
    try:
        if(num < 0):
            # Get number of "digits" of negative number by making it positive
            num = num * -1
        return floor(log10(num) + 1)
    except ValueError:
        # Bad value for num passed = 0 digits
        return 0

# Try statement to ensure proper user input before performing calculations.
try:
    # Accept input (2 integers) from the user.
    num1 = int(input('Enter integer 1: '))
    num2 = int(input('Enter integer 2: '))
    # 1. Add the 2 numbers given.
    # 2. Call addLeastSignificantDigit to add each digit of num1 and num2 to the sum from step 1.
    answer = num1 + num2 + addLeastSignificantDigit(num1, num2)
    if(getNumDigits(answer) != 1):
        # Non-single digit final answer. Notify the user and exit.
        print('Final answer is not a single digit. Please try again with different inputs.')
        sys.exit()
    else:
        # Single digit final answer. Print the answer and exit.
        print(f'Final answer is {answer}.')
        sys.exit()
except ValueError:
    # If we enter here, user entered a string or float in place of integers num1 or num2.
    # Notify the user and exit.
    print('Program only accepts integer inputs. Please try again.')
    sys.exit()
