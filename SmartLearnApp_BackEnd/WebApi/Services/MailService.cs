using System.Collections.Generic;
using System.Linq;
using BusinessLayer.Contracts;
using BusinessLayer.Models.User;
using FluentScheduler;
using JetBrains.Annotations;
using MailKit.Net.Smtp;
using MailKit;
using MimeKit;

namespace WebApi.Services
{
    public class MailService : IJob
    {
        private readonly IUserService _userService;

        public MailService(IUserService userService)
        {
            _userService = userService;
        }

        private MimeMessage GenerateMesssage(UserBlModel user)
        {
            MimeMessage message = new MimeMessage();
            message.From.Add(new MailboxAddress("Smart Learn App", "kreidichalexandra@gmail.com"));
            message.To.Add(new MailboxAddress(user.FirstName, user.Email));
            message.Subject = "How are you doin?";

            return message;
        }

        private MimeMessage CreateMessageForUserHaveCardsToRepeat(UserBlModel user)
        {
            MimeMessage msg = GenerateMesssage(user);

            msg.Body = new TextPart("plain")
            {
                Text =
                    @"Hey " + user.FirstName + " I just wanted to let you know that you have cards to repeat today"
            };

            return msg;
        }

        private MimeMessage CreateMessageForUserHaveMissedCards(UserBlModel user)
        {
            MimeMessage msg = GenerateMesssage(user);

            msg.Body = new TextPart("plain")
            {
                Text =
                    @"Hey " + user.FirstName + "I just wanted to let you know that you have missed cards"
            };

            return msg;
        }

        private void SendMessages(IEnumerable<MimeMessage> messages)
        {
            using (var client = new SmtpClient())
            {
                client.Connect("smtp.gmail.com", 587);
                client.AuthenticationMechanisms.Remove("XOAUTH2");
                client.Authenticate("kreidichalexandra@gmail.com", "bibzfpnysdyphufe");
                foreach (MimeMessage msg in messages)
                {
                    client.Send(msg);
                }
                client.Disconnect(true);
            }
        }

        public async void Execute()
        {
            IEnumerable<UserBlModel> usersWithMissingCards
                = await _userService.GetUsersWithMissingCards();
            IEnumerable<UserBlModel> usersHaveCardsToRepeat
                = await _userService.GetUsersHaveCardsToRepeat();

            List<MimeMessage> messages = new List<MimeMessage>();

            foreach (UserBlModel user in usersHaveCardsToRepeat)
            {
                messages.Add(CreateMessageForUserHaveCardsToRepeat(user));
            }

            foreach (UserBlModel user in usersWithMissingCards)
            {
                messages.Add(CreateMessageForUserHaveMissedCards(user));
            }

            SendMessages(messages);
        }
    }

    [UsedImplicitly]
    public class BackgroundJobsRegistry : Registry
    {
        public BackgroundJobsRegistry(IUserService userService)
        {
            Schedule(() => new MailService(userService)).ToRunNow().AndEvery(1).Days().At(10, 00);
        }
    }
}
