using System;
using System.Linq;

class PalindromeCheck
{
    static string reversedString;

    static bool isPalindrome(string word)
    {
        reversedString = new string(word.Reverse().ToArray());
        return word == reversedString;
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Enter a string to check if it is a palindrome:");
        string word = Console.ReadLine();
        bool palindrome = isPalindrome(word);
        Console.WriteLine(palindrome ? "It is a palindrome." : "It is not a palindrome.");
    }
}
