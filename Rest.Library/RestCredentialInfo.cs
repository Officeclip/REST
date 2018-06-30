using System.Configuration;

namespace OfficeClip.OpenSource.Integration.Rest.Library
{
    public class RestCredentialInfo
    {
        public string TwilioAccountId { get; set; }
        public string TwilioSecretKey { get; set; }
        public string MailChimpLocation { get; set; }
        public string MailChimpApiKey { get; set; }

        public void ReadFromConfiguration()
        {
            TwilioAccountId = ConfigurationManager.AppSettings["twilio.AccountId"];
            TwilioSecretKey = ConfigurationManager.AppSettings["twilio.SecretKey"];
            MailChimpLocation = ConfigurationManager.AppSettings["mailchimp.Location"];
            MailChimpApiKey = ConfigurationManager.AppSettings["mailchimp.ApiKey"];
        }
    }
}
