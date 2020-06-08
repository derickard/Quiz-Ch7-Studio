using System;
using System.Collections.Generic;
using System.Text;

namespace Quiz
{
    public class Quiz
    {
        public List<Question> questions = new List<Question>();

        public void AddQuestion(Question newQuestion)
        {
            questions.Add(newQuestion);
        }
        public void AddQuestion()
        {
            Question newQuestion = new Question();
            do
            {
                int userSelection;
                string userInput;
                Console.Write("What type of question to add:\n 1 - Multiple Choice\n 2 - Checkbox\n 3 - True/False\n> ");
                while (!int.TryParse(Console.ReadLine(), out userSelection))
                {
                    Console.Write("Invalid entry, choose question type by number: ");
                }
                if (userSelection == 1)
                {
                    newQuestion = new MultipleChoice();
                } else if(userSelection == 2)
                {
                    newQuestion = new Checkbox();
                } else if(userSelection == 3)
                {
                    newQuestion = new TrueFalse();
                }

                do
                {
                    Console.WriteLine("Enter the question prompt: ");
                    userInput = Console.ReadLine();
                    Console.Write($"\tYou entered the question prompt:\n\t{userInput}\n\tIs that correct (y/n)?: ");
                } while (!Equals(Console.ReadLine().ToLower(), "y"));
                newQuestion.Prompt = userInput;

                if(!newQuestion.GetType().Equals(typeof(TrueFalse)))
                {
                    do
                    {
                        Console.WriteLine("Enter the possible answers:\n(Hit \"Enter\" when done)");
                        userInput = Console.ReadLine();
                        char choice = 'a';
                        while (!Equals(userInput.ToLower(), ""))
                        {
                            newQuestion.possibleAnswers[choice.ToString()] = userInput;
                            choice++;
                            userInput = Console.ReadLine();
                        }
                        Console.WriteLine("\tYou entered the possible answers: ");
                        foreach (KeyValuePair<string, string> a in newQuestion.possibleAnswers)
                        {
                            Console.WriteLine($"\t{a.Key} - {a.Value}");
                        }
                        Console.Write("\tIs that correct(y / n) ? ");

                    } while (!Equals(Console.ReadLine().ToLower(), "y"));

                } else
                {
                    Console.WriteLine("\tPossible answers: ");
                    newQuestion.possibleAnswers["a"] = "true";
                    newQuestion.possibleAnswers["b"] = "false";
                    foreach (KeyValuePair<string, string> a in newQuestion.possibleAnswers)
                    {
                        Console.WriteLine($"\t{a.Key} - {a.Value}");
                    }
                }

                do
                {
                    Console.WriteLine("Enter the letters that correspond to the correct choice(s)");
                    userInput = Console.ReadLine();
                    char[] userArr = userInput.ToCharArray();
                    Array.Sort(userArr);
                    newQuestion.CorrectAnswer = new string(userArr);
                    Console.WriteLine("\tYou entered the correct answer(s) as: {0}", newQuestion.CorrectAnswer);
                    Console.Write("\tIs that correct(y / n) ? ");
                } while (!Equals(Console.ReadLine().ToLower(), "y"));
                Console.Clear();
                Console.Write($"Your {newQuestion.GetType()} question will appear as follows:\n\n{newQuestion.Display()}\nWith correct answer(s) marked as: {newQuestion.CorrectAnswer}\n\nIs that correct (y to accept, n to start over): ");
            } while (!Equals(Console.ReadLine().ToLower(), "y"));
            questions.Add(newQuestion);
        }




        public void RunQuiz()
        {
            int i = 0;
            foreach(Question q in questions)
            {
                Console.WriteLine($"Question number {i+1} of {questions.Count}");
                Console.WriteLine(q.Display());
                Console.Write("Enter your answer: ");
                q.Response = Console.ReadLine();
                if(q is ShortAnswer qsa)
                {
                    while(!qsa.ValidateLength())
                    {
                        Console.WriteLine("Your response must be less than 80 characters!");
                        Console.WriteLine(q.Display());
                        Console.Write("Enter your answer (less than 80 characters): ");
                        qsa.Response = Console.ReadLine();
                    }
                }
                i++;
                Console.Clear();
            }
            Console.WriteLine("Quiz Completed.");
        }

        public double GradeQuiz()
        {
            double grade = 0;
            int correct = 0;
            foreach(Question q in questions)
            {
                if(q.Mark())
                {
                    correct++;
                }
            }

            grade = (double)correct/questions.Count;
            return grade;
        }

    }
}
