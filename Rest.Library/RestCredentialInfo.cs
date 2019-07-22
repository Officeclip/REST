using System.Configuration;
using System.Xml;

namespace OfficeClip.OpenSource.Integration.Rest.Library
{
    public class RestCredentialInfo
    {
        public string TwilioAccountId { get; set; }
        public string TwilioSecretKey { get; set; }
        public string MailChimpLocation { get; set; }
        public string MailChimpApiKey { get; set; }
        public string SlackWebHookUrl { get; set; }

        public void ReadFromConfiguration(string filePath = "")
        {
            TwilioAccountId = GetValueFromConfig("twilio.AccountId", filePath);
            TwilioSecretKey = GetValueFromConfig("twilio.SecretKey", filePath);
            MailChimpLocation = GetValueFromConfig("mailchimp.Location", filePath);
            MailChimpApiKey = GetValueFromConfig("mailchimp.ApiKey", filePath);
            SlackWebHookUrl = GetValueFromConfig("slack.WebHookUrl", filePath);
        }

        private string GetValueFromConfig(string key, string filePath = "")
        {
            if (filePath == "")
            {
                return ConfigurationManager.AppSettings[key];
            }
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(filePath);

            XmlNode selectedNode =
                xmlDocument.SelectSingleNode(
                                             $"/appSettings/add[@key='{key}']");

            return selectedNode.Attributes["value"].Value;
        }
    }
}
