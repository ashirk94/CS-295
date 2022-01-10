using System;
using Xunit;
using AlanShirkInformationalSite.Models;

namespace InfoSiteTests
{
    public class QuizTest
    {

        [Fact]
        public void WrongAnswerTest()
        {
            QuizState quiz = new QuizState();
            quiz.Answer1 = "A";
            quiz.NumWrong = 0;

            Assert.NotEqual("D", quiz.Answer1);

            quiz.NumWrong++;
            Assert.Equal(1, quiz.NumWrong);
        }
        [Fact]
        public void RightAnswerTest()
        {
            QuizState quiz = new QuizState();
            quiz.Answer1 = "D";
            quiz.Score = 0;

            Assert.Equal("D", quiz.Answer1);

            quiz.Score++;
            Assert.Equal(1, quiz.Score);
        }
        [Fact]
        public void NumCorrectTest()
        {
            QuizState quiz = new QuizState();
            quiz.Answer1 = "D";
            quiz.Answer2 = "D";
            quiz.Answer3 = "D";

            int test = quiz.NumCorrect();

            Assert.Equal(1, test);
            Assert.Equal(2, quiz.NumWrong);
        }
    }
}
