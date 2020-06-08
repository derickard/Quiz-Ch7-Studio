using System;
using System.Collections.Generic;
using System.Text;

namespace Quiz
{
    class ShortAnswer : Question
    {
        public ShortAnswer()
        {
        }

        public ShortAnswer(string prompt) : base(prompt, new Dictionary<string, string> { { "Short", "Answer" } }, "")
        {
        }

        public override bool Mark()
        {
            return true;
        }

        public bool ValidateLength()
        {
            return Response.Length < 80;
        }
    }
}
