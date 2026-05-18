using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
namespace Lab9.White{

public class Task2 : White
{
    private int[,] _output;

    public int[,] Output => _output;

    public Task2(string text) : base(text)
    {
        _output = new int[0, 2];
    }

    public override void Review()
    {
        string text = Input;
        if (string.IsNullOrEmpty(text))
        {
            _output = new int[0, 2];
            return;
        }

        HashSet<char> vowels = new HashSet<char>
        {
            'а', 'е', 'ё', 'и', 'о', 'у', 'ы', 'э', 'ю', 'я',
            'А', 'Е', 'Ё', 'И', 'О', 'У', 'Ы', 'Э', 'Ю', 'Я',
            'a', 'e', 'i', 'o', 'u', 'y',
            'A', 'E', 'I', 'O', 'U', 'Y'
        };

        List<string> words = new List<string>();
        StringBuilder currentWord = new StringBuilder();

        for (int i = 0; i < text.Length; i++)
        {
            char c = text[i];
            bool isSeparator = Char.IsSeparator(c) && c != '\u2028' && c != '\u2029';
            if (isSeparator)
            {
                if (currentWord.Length > 0)
                {
                    words.Add(currentWord.ToString());
                    currentWord.Clear();
                }
            }
            else if (Char.IsLetter(c) || c == '-' || c == '`')
            {
                currentWord.Append(c);
            }
            else
            {
                if (currentWord.Length > 0)
                {
                    words.Add(currentWord.ToString());
                    currentWord.Clear();
                }
            }
        }
        if (currentWord.Length > 0)
            words.Add(currentWord.ToString());

        Dictionary<int, int> syllableCounts = new Dictionary<int, int>();
        foreach (string word in words)
        {
            int vowelCount = 0;
            foreach (char ch in word)
            {
                if (vowels.Contains(ch))
                    vowelCount++;
            }
            int syllables = (vowelCount == 0) ? 1 : vowelCount;
            if (syllableCounts.ContainsKey(syllables))
                syllableCounts[syllables]++;
            else
                syllableCounts[syllables] = 1;
        }

        var sorted = syllableCounts.OrderBy(kvp => kvp.Key).ToList();
        _output = new int[sorted.Count, 2];
        for (int i = 0; i < sorted.Count; i++)
        {
            _output[i, 0] = sorted[i].Key;
            _output[i, 1] = sorted[i].Value;
        }
    }

    public override string ToString()
    {
        if (_output == null || _output.GetLength(0) == 0)
            return string.Empty;
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < _output.GetLength(0); i++)
        {
            sb.Append($"{_output[i, 0]}:{_output[i, 1]}");
            if (i < _output.GetLength(0) - 1)
                sb.AppendLine();
        }
        return sb.ToString();
    }
}

    }
