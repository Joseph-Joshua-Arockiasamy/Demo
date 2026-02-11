namespace DemoApp.Helpers;

/// <summary>
/// Helper class for input validation - demonstrates static methods and validation
/// </summary>
public static class InputHelper
{
    public static int GetValidInteger(string prompt, int min = int.MinValue, int max = int.MaxValue)
    {
        int result;
        
        // Demonstrates while loop and input validation
        while (true)
        {
            Console.Write(prompt);
            string? input = Console.ReadLine();

            if (int.TryParse(input, out result) && result >= min && result <= max)
            {
                return result;
            }

           // Console.WriteLine($"Please enter a valid number between {min} and {max}.");
        }
    }

    public static string GetNonEmptyString(string prompt)
    {
        // Demonstrates do-while loop
        string? input;
        do
        {
            Console.Write(prompt);
            input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Input cannot be empty. Please try again.");
            }
        } while (string.IsNullOrWhiteSpace(input));

        return input;
    }
}
