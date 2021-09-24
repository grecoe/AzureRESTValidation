
using AzureCredentials.Contexts.BaseUtils;

namespace AzureCredentials.Contexts
{
    class ActiveDirectoryContext : BaseContext
    {
        public ActiveDirectoryContext(ServicePrincipal principal)
            : base("https://graph.microsoft.com/", principal)
        {

        }
    }

}
