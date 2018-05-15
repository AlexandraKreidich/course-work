using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Models.DataTransferObjects
{
    public class CardRescheduleDalModel
    {
        public int Id { get; set; }

        public DateTime LearnDate { get; set; }

        public DateTime LastDayRepeatedAt { get; set; }

        public DateTime ShouldRepeatAt { get; set; }

        public CardRescheduleDalModel(
            int id,
            DateTime learnDate,
            DateTime lastDayRepeatedAt,
            DateTime shouldRepeatAt
        )
        {
            Id = id;
            LearnDate = learnDate;
            LastDayRepeatedAt = lastDayRepeatedAt;
            ShouldRepeatAt = shouldRepeatAt;
        }
    }
}
