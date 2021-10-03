using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Task2
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Hello World!");
      String file = "";
      file = File.ReadAllText("D:\\XXX\\WorkingFiles\\C#_2021\\Task2\\Task2\\resources\\text2.txt");

      string[] words = file.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
      Dictionary<String, int> dictWordCount = new Dictionary<string, int>();
      Dictionary<int, int> dictLettersCount = new Dictionary<int, int>();

      String finalText = "";

      foreach (var word in words)
      {
        if (dictWordCount.ContainsKey(word))
        {
          dictWordCount[word]++;
        }
        else
        {
          dictWordCount.Add(word, 1);
        }

        int lettersCount = word.Length;
        if (dictLettersCount.ContainsKey(lettersCount)) 
        {
          dictLettersCount[lettersCount]++;
        }
        else
        {
          dictLettersCount.Add(lettersCount, 1);
        }

        finalText = finalText + word + " ";
      }
      
      
    }
  }
}
