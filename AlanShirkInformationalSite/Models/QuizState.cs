using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlanShirkInformationalSite.Models
{
    public class QuizState
    {
        public string Answer1 { get; set; }

        public string Answer2 { get; set; }

        public string Answer3 { get; set; }

        public int Score { get; set; }

        public int NumWrong { get; set; }

        public int NumCorrect()
        {
            //start from 0 and check all answers
            Score = 0;
            NumWrong = 0;
            if (Answer1 == "D")
            {
                Score++;
            }
            else
            {
                NumWrong++;
            }
            if (Answer2 == "B")
            {
                Score++;
            }
            else
            {
                NumWrong++;
            }
            if (Answer3 == "A")
            {
                Score++;
            }
            else
            {
                NumWrong++;
            }
            return Score;
        }
    }
}
