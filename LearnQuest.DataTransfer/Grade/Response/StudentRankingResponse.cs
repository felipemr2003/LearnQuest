using System;

namespace LearnQuest.DataTransfer.Grade.Response
{
    public class StudentRankingResponse
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public decimal TotalScore { get; set; }
        public int Rank { get; set; }
    }
}
