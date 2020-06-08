using System;
using System.Collections.Generic;
using System.Text;

namespace Quiz
{
    public class Question
    {
        public string Prompt { get; set; }
        public Dictionary<string, string> possibleAnswers = new Dictionary<string, string>();
        public string Response { get; set; }

  
        public string CorrectAnswer { get; set; }
        private protected bool isCorrect = false;

        public Question()
        {
        }

        public Question (string prompt, Dictionary<string, string> possibleAnswers, string correctAnswer)
        {
            Prompt = prompt;
            this.possibleAnswers = possibleAnswers;
            CorrectAnswer = correctAnswer;
        }


        public string Display()
        {
            StringBuilder displayString = new StringBuilder();
            displayString.Append(Prompt).Append(":").Append("\n");
            foreach (KeyValuePair<string, string> a in possibleAnswers)
            {
                displayString.Append(a.Key).Append(" - ").Append(a.Value).Append("\n");
            }

            return displayString.ToString();
        }

        public virtual bool Mark()
        {
            if (Equals(CorrectAnswer, Response))
            {
                isCorrect = true;
            }
            return isCorrect;
        }


    }
}
