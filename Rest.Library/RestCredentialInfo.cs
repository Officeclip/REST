using System.Configuration;
using System.Xml;

namespace OfficeClip.OpenSource.Integration.Rest.Library
{
    public class RestCredentialInfo
    {
        public string AccountId { get; set; }
        public string SecretKey { get; set; }
        public string MailChimpLocation { get; set; }
        public string MailChimpApiKey { get; set; }

        public void ReadFromConfiguration(string filePath = "")
        {
            AccountId = GetValueFromConfig("AccountId", filePath);
            SecretKey = GetValueFromConfig("SecretKey", filePath);
            MailChimpLocation = GetValueFromConfig("mailchimp.Location", filePath);
            MailChimpApiKey = GetValueFromConfig("mailchimp.ApiKey", filePath);
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
