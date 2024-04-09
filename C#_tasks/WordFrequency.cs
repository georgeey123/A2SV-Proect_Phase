using System;
using System.Collections.Generic;

class WordFrequency
{
    static Dictionary<string, int> CalculateWordFrequency(string str)
    {
        Dictionary<string, int> dict = new Dictionary<string, int>();
        string[] words = str.Split(' ');
        foreach (string word in words)
        {
            if (dict.ContainsKey(word))
            {
                dict[word]++;
            }
            else
            {
                dict.Add(word, 1);
            }
        }
        return dict;
    }

    static void Main(string[] args)
    {
        string sentence;
        Console.WriteLine("Enter a sentence: ");
        sentence = Console.ReadLine();

        Dictionary<string, int> dict = CalculateWordFrequency(sentence);

        foreach (KeyValuePair<string, int> kvp in dict)
        {
            Console.WriteLine("Word: {0}, Count: {1}", kvp.Key, kvp.Value);
        }
    }
}
