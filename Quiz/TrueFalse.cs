using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace Quiz
{
    public class TrueFalse : Question
    {
        public TrueFalse() { }
        public TrueFalse(string prompt, Dictionary<string, string> possibleAnswers, string correctAnswer) : base(prompt, possibleAnswers, correctAnswer)
        {
        }

    }
}
