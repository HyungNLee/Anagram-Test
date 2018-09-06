using System;
using System.Collections.Generic;

namespace Anagram.Models
{
  public class Anagram
  {
    private string _originalWord = "";
    private List<char> _originalWordChar = new List<char> {};
    private List<string> _potentialAnagrams = new List<string> {};
    private List<string> _returnAnagrams = new List<string> {};

    public Anagram (string originalWord)
    {
      originalWord = originalWord.ToLower();
      _originalWord = originalWord;
      char[] charArray = originalWord.ToCharArray();
      Array.Sort(charArray);
      string sortedWord = new string(charArray);
      foreach (char A in sortedWord)
      {
        _originalWordChar.Add(A);
      }
    }

    public void SetOriginalWord(string newWord)
    {
      newWord = newWord.ToLower();
      _originalWord = newWord;
      _originalWordChar.Clear();
      char[] charArray = newWord.ToCharArray();
      Array.Sort(charArray);
      string sortedWord = new string(charArray);
      foreach (char A in sortedWord)
      {
        _originalWordChar.Add(A);
      }
    }

    public string GetOriginalWord()
    {
      return _originalWord;
    }

    public List<char> GetOriginalCharList()
    {
      return _originalWordChar;
    }

    public void AddPotentialWord(string potentialWord)
    {
      potentialWord = potentialWord.ToLower();
      _potentialAnagrams.Add(potentialWord);
    }

    public List<string> GetAllWords()
    {
      return _potentialAnagrams;
    }

    public List<string> GetAllAnagrams()
    {
      return _returnAnagrams;
    }

    public bool CompareChars(string potentialAnagram)
    {
      List<char> potentialChar = new List<char> {};
      char[] charArray = potentialAnagram.ToCharArray();
      Array.Sort(charArray);
      string sortedWord = new string(charArray);
      foreach (char A in sortedWord)
      {
        potentialChar.Add(A);
      }
      // if (originalChar == potentialChar)
      // {
      //   return true;
      // }
      // else
      // {
      //   return false;
      // }
      bool countTrueFalse = potentialChar.Count == _originalWordChar.Count;
      bool isEqual = true;
      if (countTrueFalse)
      {
        for (int i = 0; i < potentialChar.Count; i++)
        {
          if (_originalWordChar[i] != potentialChar[i])
          {
            isEqual = false;
          }
        }
      }
      return (isEqual) ? true : false;
    }

    public List<string> returnAnagramWords()
    {
      foreach (string word in _potentialAnagrams)
      {
        if (CompareChars(word))
        {
          _returnAnagrams.Add(word);
        }
      }
      return _returnAnagrams;
    }
  }

  class Program
  {
    // static void Main()
    // {
    //   Console.WriteLine("Welcome to the Anagram Checker program.");
    //   Flow();
    // }

    static void Main()
    {
      Console.WriteLine("Welcome to the Anagram Checker program.");

      //Main word input
      Console.WriteLine("Please enter a word.");
      string input = Console.ReadLine();
      while (input == null)
      {
        Console.WriteLine("Please enter a word.");
        input = Console.ReadLine();
      }

      Anagram newAnagram = new Anagram(input);

      //Potential anagram input
      Console.WriteLine("Please enter a potential anagram word. Leave blank if you are done adding words.");
      string anagramInput = Console.ReadLine();
      while (anagramInput != "")
      {
        newAnagram.AddPotentialWord(anagramInput);

        Console.WriteLine("Please enter a potential anagram word. Leave blank if you are done adding words.");
        anagramInput = Console.ReadLine();
      }

      //Shows all anagrams
      List<string> filterList = newAnagram.returnAnagramWords();
      int number = 1;
      Console.WriteLine("*These are the words that are anagrams to " + newAnagram.GetOriginalWord() + ".*");
      foreach (string word in filterList)
      {
        Console.WriteLine(number + ". " + word);
        number++;
      }
    }

    // public static void Flow()
    // {
    //   EnterWord();
    //   AddPotentialWords();
    // }

    // public static void EnterWord()
    // {
    //   Console.WriteLine("Please enter a word.");
    //   string input = Console.ReadLine();
    //   if (input != null)
    //   {
    //     Anagram newAnagram = new Anagram(input);
    //   }
    //   else
    //   {
    //     EnterWord();
    //   }
    // }

    // public static void AddPotentialWords()
    // {
    //   Console.WriteLine("Please enter a potential anagram word. Leave blank if you are done adding words.");
    //   string input = Console.ReadLine();
    //   if (input != null)
    //   {
    //     newAnagram.AddPotentialWord(input);
    //     AddPotentialWords();
    //   }
    //   Console.WriteLine(newAnagram.GetAllWords());
    // }
  }
}