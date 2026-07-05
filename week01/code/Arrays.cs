using System.ComponentModel;

public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.
        
        // How I will solve this problem:
        // 1. Create a new array where I'll store the multiples
        // 2. Create a variable I'll use to multiply my initial number by
        // 3. Iterate on the number of multiples (e.g if # of multiples = 3 then the for loop will run 3 times)
        // 3. On each iteration I need to mutiple the initial number by my multiplier variable and then increase the multipler each time
        // 4. Save the mutiples and return new array
        var multipler = 1;
        var multiplesOfArray = new double[length];
        for (int i = 0; i < length; i++)
        {
            multiplesOfArray[i] = number * multipler++;
        }
        return multiplesOfArray; // replace this return statement with your own
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // How I will solve this problem...
        // 1. I need a new empty list where I will store the new rotated list
        // 2. I need a cut index that I'll be using to slice my list
        // 3. I'll need to store the 2 parts of my list into vars
        // 4. Join 2 parts by using AddRange
        // 5. Clear original list and set the new one as the value
        
        List<int> rotatedList = [];
        var cut = data.Count - amount;
        var part1 = data.GetRange(cut, amount);
        var part2 = data.GetRange(0, cut);
        rotatedList.AddRange(part1);
        rotatedList.AddRange(part2);
        data.Clear();
        data.AddRange(rotatedList);
    }
}
