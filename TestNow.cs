using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter a string: ");
        string input = Console.ReadLine();

        string encodedString = EncodeString(input);
        Console.WriteLine("Encoded string: " + encodedString);
    }

    static string EncodeString(string input)
    {
        string sentence = "The quick and brown fox jumps over the Lazy Dog";
        string[] words = sentence.Split(' ');

        Dictionary<char, string> charCodeMap = new Dictionary<char, string>();

        for (int i = 0; i < words.Length; i++)
        {
            for (int j = 0; j < words[i].Length; j++)
            {
                char c = words[i][j];
                if (!charCodeMap.ContainsKey(c))
                {
                    charCodeMap[c] = i.ToString() + (j + 1).ToString();
                }
            }
        }

        string[] inputWords = input.Split(' ');
        string encodedString = "";

        for (int i = 0; i < inputWords.Length; i++)
        {
            string word = inputWords[i];
            for (int j = 0; j < word.Length; j++)
            {
                char c = word[j];
                if (charCodeMap.ContainsKey(char.ToLower(c)))
                {
                    encodedString += charCodeMap[char.ToLower(c)];
                }
                else
                {
                    encodedString += c;
                }
            }

            if (i < inputWords.Length - 1)
            {
                encodedString += "-";
            }
        }

        return encodedString;
    }
}
