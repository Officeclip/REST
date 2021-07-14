using System;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace Twilio.Library.Test
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Find your Account Sid and Auth Token at twilio.com/console
            const string accountSid = "xxx";
            const string authToken = "yyy";
            TwilioClient.Init(accountSid, authToken);

            var to = new PhoneNumber("xxx");
            var message = MessageResource.Create(
                                                to,
                                                from: new PhoneNumber("yyy"),
                                                body: "All in the game, yo");

            Console.WriteLine(message.Sid);
        }
    }
}
