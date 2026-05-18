using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
namespace Lab9.White
{
 public class Task3 : White
 {
     private string _output;
     private string[,] _codeTable;

     public string Output => _output;

     public Task3(string text, string[,] codeTable) : base(text)
     {
         _output = text ?? string.Empty;
         _codeTable = codeTable;
     }

     public override void Review()
     {
         string text = Input;
         if (string.IsNullOrEmpty(text) || _codeTable == null || _codeTable.GetLength(0) == 0)
         {
             _output = text ?? string.Empty;
             return;
         }

         Dictionary<string, string> replacements = new Dictionary<string, string>();
         for (int i = 0; i < _codeTable.GetLength(0); i++)
         {
             string word = _codeTable[i, 0];
             string code = _codeTable[i, 1];
             if (!string.IsNullOrEmpty(word))
                 replacements[word] = code ?? string.Empty;
         }

         StringBuilder result = new StringBuilder();
         StringBuilder currentWord = new StringBuilder();

         for (int i = 0; i < text.Length; i++)
         {
             char c = text[i];
             bool isLetterOrHyphenOrApostrophe = Char.IsLetter(c) || c == '-' || c == '`';

             if (isLetterOrHyphenOrApostrophe)
             {
                 currentWord.Append(c);
             }
             else
             {
                 if (currentWord.Length > 0)
                 {
                     string word = currentWord.ToString();
                     result.Append(replacements.ContainsKey(word) ? replacements[word] : word);
                     currentWord.Clear();
                 }
                 result.Append(c);
             }
         }
         if (currentWord.Length > 0)
         {
             string word = currentWord.ToString();
             result.Append(replacements.ContainsKey(word) ? replacements[word] : word);
         }

         _output = result.ToString();
     }

     public override string ToString()
     {
         return _output ?? string.Empty;
     }
 } 
}
