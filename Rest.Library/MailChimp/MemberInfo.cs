using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeClip.OpenSource.Integration.Rest.Library.MailChimp
{
    public class MemberInfo
    {
        [JsonProperty("id")]
        public string Id { get; set; } = string.Empty;

        [JsonProperty("email_address")]
        public string EmailAddress { get; set; } = string.Empty;

        [JsonProperty("email_type")]
        public string Email_Type { get; set; } = "html";

        [JsonProperty("status")]
        public string Status { get; set; } = string.Empty;

        [JsonProperty("merge_fields")]
        public MergeFieldInfo Merge_Fields { get; set; }
    }
}
