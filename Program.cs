using System;
using System.Text.RegularExpressions;
using System.Globalization;

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter a string:");
        string input = Console.ReadLine();
        
        
        string pattern = @"\b(0[1-9]|1[0-2])(0[1-9]|[12][0-9]|3[01])\d{4}\b";
        MatchCollection matches = Regex.Matches(input, pattern);
        if (matches.Count > 0)
        {
            foreach (Match match in matches)
            {
                string dateStr = match.Value;
                if (DateTime.TryParseExact(dateStr, "MMddyyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime validDate))
                {
                    Console.WriteLine("Valid Date: " + validDate.ToString("MM/dd/yyyy"));
                }
            }
        }
        else
        {
            Console.WriteLine("No valid dates found.");
        }
    }
}