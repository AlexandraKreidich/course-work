using System;
using Common;

namespace WebApi.Models.Card
{
    public class CardAnswerRequestWebApiModel
    {
        public int Id { get; set; }

        public AnswerResult Result { get; set; }

        public DateTime LearnDate { get; set; }

        public DateTime LastDayRepeatedAt { get; set; }

        public DateTime ShouldRepeatAt { get; set; }
    }
}
