# Using Recursion; take two numbers in from the user (a human) and add them together 
# then separate the least significant digit and add it the remaining digits and so on 
# until you have a single digit answer.
#
# Must accept two numbers as user input
# Must use recursion to reach single digit answer
#
# Tests
# Non-integer/float inputs (Unhappy paths)
# num1 = foo, num2 = 10             Result: Error message displayed after num1 is entered
# num1 = 10, num2 = foo             Result: Error message displayed after num2 is entered
# num1 = "", num2 = 10              Result: Error message displayed after num1 is entered
# num1 = 10, num2 = ""              Result: Error message displayed after num2 is entered
# Negative inputs
# num1 = -123, num2 = -456          Expected: -3         Result: -3
# num1 = -123, num2 = 456           Expected: 9          Result: 9
# num1 = 0, num2 = -39              Expected: -3         Result: -3 
# Zero as sum
# num1 = 0, num2 = 0                Expected: 0          Result: 0
# Float inputs
# num1 = 1.23, num2 = 4.56          Expected: 3          Result: 3
# num1 = 1.3999, num2 = 3.1         Expected: 8          Result: 8
# Integer inputs
# num1 = 123, num2 = 456            Expected: 3          Result: 3
# Mixed inputs
# num1 = 1.23, num2 = 456           Expected: 3          Result: 3
# num1 = 123, num2 = 4.56           Expected: 3          Result: 3
# num1 = -1.23, num2 = 456          Expected: 9          Result: 9
# num1 = -123, 4.56                 Expected: 9          Result: 9
#
# Done: Calculates single digit answer given 2 numbers and gracefully ends execution.
#       Notifies the user if any error occurs or if a single digit answer is not calculated.
#       Gracefully ends execution if an error occurs.

from math import floor, log10
import sys

# Recursively calls until a single digit number is found given an integer sum
def addLeastSignificantDigitInt(sum):
    if(getNumDigitsInt(sum) == 1):
        return sum
    return addLeastSignificantDigitInt((sum%10)+(floor(sum/10)))

# Recursively calls until a single digit number is found given a float sum
# which is passed in as a string to be correctly parsed
def addLeastSignificantDigitFloat(sum):
    if(getNumDigitsFloat(str(sum)) == 1):
        # We've found a single digit answer, let's return and display it to the user
        return sum
    # Cast the new value as a string since we are mainly using string manipulation
    # to parse the correct values from floats
    if(float(sum) > 0):
        digit = int(sum[-1])
    else:
        digit = int(sum[-1]) * -1
    return addLeastSignificantDigitFloat(str(digit + int(sum[:-1].replace('.',''))))

# Returns the number of decimal places in a number passed in as a string
# to be correctly parsed
def getNumDecimalPlaces(num):
    return len(num.split('.')[1])

# Returns the number of digits in an integer
def getNumDigitsInt(num):
    try:
        if(num == 0):
            return 1
        if(num < 0):
            # Make negative number positive for log10 bounds
            num = num * -1
        return floor(log10(num) + 1)
    except ValueError:
        # Bad value for num passed = 0 digits
        return 0

# Returns the number of digits in a float passed in as a string to be
# correctly parsed
def getNumDigitsFloat(num):
    try:
        # We need to account for the fact that negative symbol could be included
        # since the method used to get the number of digits is counting characters
        return len(num) if '-' not in num else len(num)-1
    except ValueError:
        # Bad value for num passed = 0 digits
        return 0

# Main execution below

# Accept input from the user
num1 = input('Enter number 1: ')
if '.' in num1:
    # If we have a decimal in an input, user may have given a float, try to parse it
    try:
        num1 = float(num1)
        decimalsInNumOne = getNumDecimalPlaces(str(num1))
    except ValueError:
        # String was passed instead of a float. Notify the user and exit
        print('Program only accepts number inputs. Please try again.')
        sys.exit()
else:
    # No float passed, let's see if the user entered an integer instead
    try:
        num1 = int(num1)
        decimalsInNumOne = 0
    except ValueError:
        # String was passed instead of an integer. Notify the user and exit
        print('Program only accepts number inputs. Please try again.')
        sys.exit()

num2 = input('Enter number 2: ')
if '.' in num2:
    # If we have a decimal in an input, user may have given a float, try to parse it
    try:
        num2 = float(num2)
        decimalsInNumTwo = getNumDecimalPlaces(str(num2))
    except ValueError:
        # String was passed instead of a float. Notify the user and exit
        print('Program only accepts number inputs. Please try again.')
        sys.exit()
else:
    # No float passed, let's see if the user entered an integer instead
    try:
        num2 = int(num2)
        decimalsInNumTwo = 0
    except ValueError:
        # String was passed instead of an integer. Notify the user and exit
        print('Program only accepts number inputs. Please try again.')
        sys.exit()


if(decimalsInNumOne > decimalsInNumTwo):
    roundNumber = decimalsInNumOne
else:
    roundNumber = decimalsInNumTwo
# Calculate the sum and round to whichever has the larger amount
# of digits after the decimal, if a float is given by the user
sum = round(num1 + num2, roundNumber)
# Call the recursive function depending on whether or not the calculated sum
# is an integer or float and print the answer
if(type(sum) == float):
    print(f'The calculated single digit answer is: {int(addLeastSignificantDigitFloat(str(sum)))}')
else:
    print(f'The calculated single digit answer is: {addLeastSignificantDigitInt(sum)}')
# End execution
sys.exit()