using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        string regexPattern = @"^(?=.*SP)(?=.*[A-Z])(?=.*[!@#$%^&*()_+{}|:""<>?~\-=[\]\\;',./]{2})(?=.*[awais]{4}).{1,12}$";
        Regex regex = new Regex(regexPattern);

        // Test strings
        string[] testStrings = {
            "SP@#awais",       // Valid
            "SPA@#wais",      // Valid
            "SP@#AwaIs",       // Valid
            "SP@#awa",        // Invalid (less than 4 lowercase letters from "awais")
            "SP@#awaiss",      // Invalid (more than 12 characters)
            "SP@#awa1s",       // Invalid (contains a digit)
            "SP@#awa@s",       // Invalid (only one special character in order)
            "SP@#awa@sA",      // Valid
            "SP@#awa@sAa",     // Invalid (more than 12 characters)
            "SP@#awa@sAa1"    // Invalid (contains a digit)
        };

        foreach (var testString in testStrings)
        {
            bool isValid = regex.IsMatch(testString);
            Console.WriteLine($"\"{testString}\" is {(isValid ? "valid" : "invalid")}");
        }
    }
}
