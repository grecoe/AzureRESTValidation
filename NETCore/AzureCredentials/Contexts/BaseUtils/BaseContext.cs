using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AzureCredentials.Contexts.BaseUtils
{
    class BaseContext
    {
		public string ServiceResource { get; private set; }
		public ServicePrincipal Principal { get; private set; }

		public BaseContext(string serviceResource, ServicePrincipal principal)
		{
			this.ServiceResource = serviceResource;
			this.Principal = principal;
		}

		public async Task<string> GetServiceToken()
		{
			string ticket = string.Empty;
			var httpClient = new HttpClient
			{
				BaseAddress = new Uri("https://login.microsoftonline.com"),
				Timeout = TimeSpan.FromMinutes(2)
			};

			// Update client credential and tenant id here for different account
			using (var request = new HttpRequestMessage(HttpMethod.Post, $"/{this.Principal.Tenet}/oauth2/token"))
			{
				BaseGrantRequest baseGrantRequest = new BaseGrantRequest(
					this.Principal.ApplicationId,
					this.Principal.Credential,
					this.ServiceResource
					);

				request.Content = new StringContent(
					baseGrantRequest.GetFormEncoded(),
					Encoding.UTF8,
					"application/x-www-form-urlencoded"
					);

				using (HttpResponseMessage response = await httpClient.SendAsync(request))
				{
					if (response.IsSuccessStatusCode)
					{
						var responseContent = await response.Content.ReadAsStringAsync();
						dynamic result = JsonConvert.DeserializeObject(responseContent, typeof(Dictionary<string, string>));
						ticket = result["access_token"];
					}
					else
					{
						throw new HttpRequestException("Fail to get AAD token for " + this.ServiceResource);
					}
				}
			}

			return ticket;
		}
	}
}
