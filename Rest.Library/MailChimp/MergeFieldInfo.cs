using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeClip.OpenSource.Integration.Rest.Library.MailChimp
{
    public class MergeFieldInfo
    {
        [JsonProperty("FNAME")]
        public string FName { get; set; } = string.Empty;

        [JsonProperty("LNAME")]
        public string LName { get; set; } = string.Empty;

        [JsonProperty("EDITION")]
        public string Edition { get; set; } = string.Empty;

        [JsonProperty("VERSION")]
        public string Version { get; set; } = string.Empty;

        [JsonProperty("NOTE")]
        public string Note { get; set; } = string.Empty;

        [JsonProperty("CREATED")]
        public DateTime Created { get; set; } = DateTime.MinValue;

        [JsonProperty("STATUS")]
        public string Status { get; set; } = string.Empty;

        [JsonProperty("ID")]
        public string Id { get; set; } = string.Empty;
    }
}
