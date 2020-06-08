using System;
using System.Collections.Generic;
using System.Text;

namespace Quiz
{
    public class MultipleChoice : Question
    {
        public MultipleChoice() { }
        public MultipleChoice(string prompt, Dictionary<string, string> possibleAnswers, string correctAnswer) : base(prompt, possibleAnswers, correctAnswer)
        {
        }
    }
}
