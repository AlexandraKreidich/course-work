using System;
using JetBrains.Annotations;

namespace WebApi.Models.Card
{
    public class CardWebApiModel
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int FolderId { get; set; }

        [NotNull]
        public string Cue { get; set; }

        [NotNull]
        public string Answer { get; set; }

        public DateTime LearnDate { get; set; }

        public DateTime LastDayRepeatedAt { get; set; }

        public DateTime ShouldRepeatAt { get; set; }
    }
}
