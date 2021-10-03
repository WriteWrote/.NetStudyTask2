using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Task2
{
  class Program
  {
    private static String EraseNonValuableSymbols(String text)
    {
      text = text.Replace("\t", " ");
      text = text.Replace("\n", " ");
      text = text.Replace("\r", " ");
      return text;
    }

    private static void WriteAllResults(String finalText, Dictionary<String, int> dictWordCount,
      Dictionary<int, int> dictLettersCount)
    {
      String path = "result.txt";
      finalText = finalText.Trim();
      File.Create(path).Close();

      finalText = "Formatted text: \n" + finalText + "\n \nWord statistic: \n";
      foreach (var entry in dictWordCount)
      {
        finalText = finalText + entry.Key + " - " + entry.Value.ToString() + " шт \n";
      }

      finalText = finalText + "\nLetters statistic: \n";
      foreach (var entry in dictLettersCount)
      {
        finalText = finalText + entry.Key.ToString() + " букв в слове - " + entry.Value.ToString() + " шт \n";
      }


      File.WriteAllText(Path.Combine(path), finalText);
    }

    static void Main(string[] args)
    {
      Console.WriteLine("Мишн комплишн!");
      String file = "";
      file = File.ReadAllText("D:\\XXX\\WorkingFiles\\C#_2021\\Task2\\Task2\\resources\\text2.txt");

      file = EraseNonValuableSymbols(file);


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
      
      WriteAllResults(finalText, dictWordCount, dictLettersCount);
    }
  }
}
