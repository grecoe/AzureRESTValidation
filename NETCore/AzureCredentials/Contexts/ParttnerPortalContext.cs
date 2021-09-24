using AzureCredentials.Contexts.BaseUtils;

namespace AzureCredentials.Contexts
{
	class ParttnerPortalContext : BaseContext
	{
		public ParttnerPortalContext(ServicePrincipal principal)
			: base("https://api.partner.microsoft.com", principal)
		{

		}
	}
}
