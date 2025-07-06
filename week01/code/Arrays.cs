public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  
    /// For example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  
    /// Assume that length is a positive integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // Step 1: Create an array to hold the multiples.
        double[] multiples = new double[length];

        // Step 2: Use a loop to calculate the multiples of the number.
        for (int i = 0; i < length; i++)
        {
            // Each multiple is the starting number multiplied by (i + 1).
            multiples[i] = number * (i + 1);
        }

        // Step 3: Return the array of multiples.
        return multiples;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  
    /// For example, if the data is List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after 
    /// the function runs should be List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  
    /// The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // Step 1: Handle the case where the amount is greater than the size of the list
        amount = amount % data.Count;  // This ensures that the rotation stays within the bounds of the list

        // Step 2: Slice the list into two parts: 
        // The last 'amount' elements, and the remaining elements at the beginning
        var part1 = data.GetRange(data.Count - amount, amount); // last 'amount' elements
        var part2 = data.GetRange(0, data.Count - amount); // remaining elements

        // Step 3: Clear the list and reassemble it with the rotated parts
        data.Clear(); // clear the original list

        // Step 4: Add the parts in the new order (part1 followed by part2)
        data.AddRange(part1);
        data.AddRange(part2);
    }
}