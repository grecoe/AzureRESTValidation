using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace AzureCredentials.Contexts.BaseUtils
{
    class BaseGrantRequest
    {
		
		[JsonProperty("grant_type")]
		public String GrantType { get; private set; }

		[JsonProperty("client_id")]
		public String ApplicationId { get; private set; }

		[JsonProperty("client_secret")]
		public String ApplicationSecret { get; private set; }

		[JsonProperty("resource")]
		public String Resource { get; private set; }

		public BaseGrantRequest(string appid, string appcred, string resource)
        {
			this.GrantType = "client_credentials";
			this.ApplicationId = appid;
			this.ApplicationSecret = appcred;
			this.Resource = resource;
        }

		public string GetFormEncoded()
        {
			string thisstrData = JsonConvert.SerializeObject(this);
			Dictionary<string, string> thisData = JsonConvert.DeserializeObject<Dictionary<string,string>>(thisstrData);

			string return_value = "";
			int count = thisData.Keys.Count;
			int current = 0;

			foreach (string key in thisData.Keys)
			{
				current += 1;
				return_value += String.Format("{0}={1}", key, thisData[key]);

				if (current < count)
				{
					return_value += "&";
				}
			}

			return return_value;

		}

	}
}
