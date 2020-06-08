using System;
using System.Collections.Generic;

namespace Quiz
{
    class Program
    {
        static void Main(string[] args)
        {
            Quiz myQuiz = new Quiz();
            string userInput;

            MultipleChoice myQuestion = new MultipleChoice("MC 1", new Dictionary<string, string> { { "a", "wrong" }, { "b", "correct" }, { "c", "wrong" }, { "d", "wrong" } }, "b");
            MultipleChoice myQuestion2 = new MultipleChoice("MC 2", new Dictionary<string, string> { { "a", "wrong" }, { "b", "wrong" }, { "c", "correct" }, { "d", "wrong" } }, "c");
            TrueFalse myQuestion3 = new TrueFalse("TF 1", new Dictionary<string, string> { { "a", "true" }, { "b", "false" } }, "a");
            Checkbox myQuestion4 = new Checkbox("CB 1", new Dictionary<string, string> { { "a", "correct" }, { "b", "correct" }, { "c", "wrong" }, { "d", "correct" } }, "abd");
            ShortAnswer myQuestion5 = new ShortAnswer("SA 1");


            myQuiz.AddQuestion(myQuestion);
            myQuiz.AddQuestion(myQuestion2);
            myQuiz.AddQuestion(myQuestion3);
            myQuiz.AddQuestion(myQuestion4);
            myQuiz.AddQuestion(myQuestion5);

            while (true)
            {
                Console.WriteLine("1 - Add questions\n2 - Run quiz\n3 - Grade the quiz");
                userInput = Console.ReadLine();
                if(Equals(userInput,"1"))
                {
                    myQuiz.AddQuestion();
                } else if(Equals(userInput, "2"))
                {
                    myQuiz.RunQuiz();
                } else if(Equals(userInput, "3"))
                {
                    Console.WriteLine($"\nYou answered {myQuiz.GradeQuiz():P1} correctly.\n");
                }


            }





            

        }
    }
}
