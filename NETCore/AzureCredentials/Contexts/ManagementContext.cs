using AzureCredentials.Contexts.BaseUtils;

namespace AzureCredentials.Contexts
{
	class ManagementContext: BaseContext
    {
		public ManagementContext(ServicePrincipal principal)
			:base("https://management.core.windows.net/", principal)
        {

        }
    }
}
