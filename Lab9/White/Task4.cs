using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
namespace Lab9.White
{
    public class Task4 : White
    {
        private int _output;

        public int Output => _output;

        public Task4(string text) : base(text)
        {
            _output = 0;
        }

        public override void Review()
        {
            string text = Input;
            if (string.IsNullOrEmpty(text))
            {
                _output = 0;
                return;
            }

            int sum = 0;
            foreach (char c in text)
            {
                if (c >= '0' && c <= '9')
                    sum += (c - '0');
            }
            _output = sum;
        }

        public override string ToString()
        {
            return _output.ToString();
        }
    }
}
