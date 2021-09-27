using System;
using System.Collections.Generic;
using System.Text;
using AzureCredentials.Contexts.BaseUtils;
using Azure.Identity;
using System.Threading.Tasks;

namespace AzureCredentials.Contexts
{
    class AzureCliContext : BaseContext
    {
        public AzureCliContext()
            :base("https://management.core.windows.net/", null)
        {

        }

        public override async Task<string> GetServiceToken()
        {
            var tokenRequestContext = new Azure.Core.TokenRequestContext(new[] { this.ServiceResource });
            var tokenRequestResult = await new DefaultAzureCredential().GetTokenAsync(tokenRequestContext);
            return tokenRequestResult.Token;
        }
    }
}
