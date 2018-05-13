using System.Configuration;

namespace OfficeClip.OpenSource.Integration.Rest.Library
{
    public class RestCredentialInfo
    {
        public string AccountId { get; set; }
        public string SecretKey { get; set; }
        public string MailChimpLocation { get; set; }
        public string MailChimpApiKey { get; set; }

        public void ReadFromConfiguration()
        {
            AccountId = ConfigurationManager.AppSettings["AccountId"];
            SecretKey = ConfigurationManager.AppSettings["SecretKey"];
            MailChimpLocation = ConfigurationManager.AppSettings["mailchimp.Location"];
            MailChimpApiKey = ConfigurationManager.AppSettings["mailchimp.ApiKey"];
        }
    }
}
