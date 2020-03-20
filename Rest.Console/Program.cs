using System.Threading.Tasks;
using OfficeClip.OpenSource.Integration.Rest.Library.Sms;
using OfficeClip.OpenSource.Integration.Rest.Library;
using OfficeClip.OpenSource.Integration.Rest.Library.MailChimp;
using System;
using OfficeClip.OpenSource.Integration.Rest.Library.Slack;
using System.Net.Http;

namespace Rest.Console
{
    public class Program
    {
        static TwilioMessage message;
        public static void Main(string[] args)
        {
            //SendMessage().Wait();
            //GetMessageInfo().Wait();
            //GetMailChimpLists().Wait();
            //AddChimpMember().Wait();
            //SendSlackMessage("This is a test").Wait();
            //SendSlackMessage("This is a test", SlackFormattedMessage).Wait();
            SendSlackMessage("Timesheet Approved by Rao, Narsimha", SlackFormattedMessageOneLiner).Wait();
        }

        private static string SlackFormattedMessageOneLiner
        {
            get
            {
                return @"
                [
		                {
			                ""type"": ""section"",
			                ""text"": {
				                ""type"": ""mrkdwn"",
				                ""text"": ""*Rao, Narsimha*  _Approved_ a <fakelink.ToMoreTimes.com|Timesheet Mar 09, 2020 (Sudhakar Gundu)> to _Gundu, Sudhakar_""
			                }
		                },
		                {
			                ""type"": ""divider""
		                },
		                {
			                ""type"": ""section"",
			                ""text"": {
				                ""type"": ""mrkdwn"",
				                ""text"": ""*<fakelink.ToMoreTimes.com|Change history notification settings>*""
			                }
		                }
	                ]";
            }
        }

        private static string SlackFormattedMessage
        {
            get
            {
                return @"
                [
		                {
			                ""type"": ""section"",
			                ""fields"": [
				                {
					                ""type"": ""mrkdwn"",
					                ""text"": "":hamburger: Notes: *Added*\n       <google.com|Testing 10.8.3>\n""
				                },
				                {
					                ""type"": ""mrkdwn"",
					                ""text"": ""by <google.com|Nagesh, Kulkarni>\n 10 Sep at 10:44 PM""
				                }
			                ]
		                },
		                {
			                ""type"": ""section"",
			                ""text"": {
				                ""type"": ""mrkdwn"",
				                ""text"": ""for Contact: <google.com|Nagesh, Kulkarni>""
			                }
		                },
		                {
			                ""type"": ""divider""
		                }
	                ]";
            }
        }

        public static async Task<HttpResponseMessage> SendSlackMessage(string message, string blocks)
        {
            var credential = new RestCredentialInfo();
            credential.ReadFromConfiguration();
            var response = await SlackClient.SendMessageAsync(credential, message, blocks);
            return response;
        }

        public static MemberInfo PopulateMember
        {
            get
            {
                return
                    new MemberInfo()
                    {
                        EmailAddress = "sales@everestconsulting.us",
                        Status = "subscribed",
                        Merge_Fields = new MergeFieldInfo()
                        {
                            FName = "SK",
                            LName = "Dutta",
                            Edition = "Enterprise",
                            Version = "Installed",
                            Created = DateTime.Now,
                            Note = "Testing mailchimp",
                            Status = "0",
                            Id = "55"
                        }
                    };
            }
        }

        public static string GetListId(string listName)
        {
            var lists = GetMailChimpLists().Result;
            foreach (ListInfo listInfo in lists.Lists)
            {
                if (listInfo.Name == listName)
                {
                    return listInfo.Id;
                }
            }
            return null;
        }

        public static async Task<string> AddChimpMember()
        {
            var credential = new RestCredentialInfo();
            credential.ReadFromConfiguration();
            var listId = GetListId("Site Registration");
            var response = await Member.PostAsync(credential, listId, PopulateMember);
            return response;
        }

        public static async Task<ListsInfo> GetMailChimpLists()
        {
            var credential = new RestCredentialInfo();
            credential.ReadFromConfiguration();
            var lists = await Lists.GetLists(credential);
            return lists;
        }

        public static async Task<TwilioMessage> GetMessageInfo()
        {
            var smsInfo = new RestCredentialInfo();
            smsInfo.ReadFromConfiguration();
            var twilioMessage = await Twilio.GetMessage(smsInfo, "SM1e8208f4b4e44720bafc9ea0334eb72d");
            return twilioMessage;
        }

        public static async Task SendMessage()
        {
            var twilioMessage = new TwilioMessage();
            twilioMessage.ReadFromConfiguration();
            twilioMessage.Message = "All in the game";
            var smsInfo = new RestCredentialInfo();
            smsInfo.ReadFromConfiguration();
            message = await Twilio.SendMessage(smsInfo, twilioMessage);
        }
    }
}
