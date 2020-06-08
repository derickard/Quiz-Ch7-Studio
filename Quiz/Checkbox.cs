using System;
using System.Collections.Generic;
using System.Text;

namespace Quiz
{
    public class Checkbox : Question
    {
        public Checkbox() { }

        public Checkbox(string prompt, Dictionary<string, string> possibleAnswers, string correctAnswer) : base(prompt, possibleAnswers, correctAnswer)
        {
        }

        public override bool Mark()
        {
            char[] resArr = Response.ToCharArray();
            Array.Sort(resArr);
            Response = new string(resArr);

            if (Equals(CorrectAnswer, Response))
            {
                isCorrect = true;
            }
            return isCorrect;
        }
    }
}
