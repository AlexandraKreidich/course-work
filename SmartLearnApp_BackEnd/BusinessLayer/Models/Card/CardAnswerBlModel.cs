using System;
using Common;

namespace BusinessLayer.Models.Card
{
    public class CardAnswerBlModel
    {
        public int Id { get; set; }

        public AnswerResult Result { get; set; }

        public DateTime LearnDate { get; set; }

        public DateTime LastDayRepeatedAt { get; set; }

        public DateTime ShouldRepeatAt { get; set; }

        public CardAnswerBlModel(
            int id,
            AnswerResult result,
            DateTime learnDate,
            DateTime lastDayRepeatedAt,
            DateTime shouldRepeatAt
        )
        {
            Id = id;
            Result = result;
            LearnDate = learnDate;
            LastDayRepeatedAt = lastDayRepeatedAt;
            ShouldRepeatAt = shouldRepeatAt;
        }
    }
}
