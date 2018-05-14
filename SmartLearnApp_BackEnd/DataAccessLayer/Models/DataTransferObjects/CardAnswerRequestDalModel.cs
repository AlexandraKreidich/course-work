using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Models.DataTransferObjects
{
    public class CardAnswerRequestDalModel
    {
        public int Id { get; set; }

        public DateTime LearnDate { get; set; }

        public DateTime LastDayRepeatedAt { get; set; }

        public DateTime ShouldRepeatAt { get; set; }

        public CardAnswerRequestDalModel(
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
