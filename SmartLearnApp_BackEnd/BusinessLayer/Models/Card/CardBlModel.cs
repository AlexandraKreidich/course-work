﻿using System;
using JetBrains.Annotations;

namespace BusinessLayer.Models.Card
{
    public class CardBlModel
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

        public CardBlModel(
            int id,
            int userId,
            int folderId,
            [NotNull] string cue,
            [NotNull] string answer,
            DateTime learnDate,
            DateTime lastDayRepeatedAt,
            DateTime shouldRepeatAt
        )
        {
            Id = id;
            UserId = userId;
            FolderId = folderId;
            Cue = cue;
            Answer = answer;
            LearnDate = learnDate;
            LastDayRepeatedAt = lastDayRepeatedAt;
            ShouldRepeatAt = shouldRepeatAt;
        }
    }
}
