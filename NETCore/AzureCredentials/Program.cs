using System;
using AzureCredentials.Contexts;
using AzureCredentials.Contexts.BaseUtils;


namespace AzureCredentials
{
    class Program
    {
        // Internally we use two different SP's this one is for partner portal applications
        private static string AMA_SP_TENANT_ID = "TENENT_ID";
        private static string AMA_SP_CLIENT_ID = "APPLICATION_ID";
        private static string AMA_SP_CLIENT_SECRET = "APPLICATION_SECRET";

        // This SP is what can get me into management and aad resources
        private static string MGT_SP_TENANT_ID = "TENENT_ID";
        private static string MGT_SP_CLIENT_ID = "APPLICATION_ID";
        private static string MGT_SP_CLIENT_SECRET = "APPLICATION_SECRET";

        static void Main(string[] args)
        {
            ServicePrincipal amaPrincipal = new ServicePrincipal(
                Program.AMA_SP_TENANT_ID, 
                Program.AMA_SP_CLIENT_ID, 
                Program.AMA_SP_CLIENT_SECRET);

            ServicePrincipal mgtPrincipal = new ServicePrincipal(
                Program.MGT_SP_TENANT_ID,
                Program.MGT_SP_CLIENT_ID,
                Program.MGT_SP_CLIENT_SECRET);

            ParttnerPortalContext amaContext = new ParttnerPortalContext(amaPrincipal);
            ManagementContext mgtContext = new ManagementContext(mgtPrincipal);
            ActiveDirectoryContext aadContext = new ActiveDirectoryContext(mgtPrincipal);
            AzureCliContext cliContext = new AzureCliContext();

            string cli_cred = cliContext.GetServiceToken().Result;
            Console.WriteLine("CLI Token");
            Console.WriteLine(cli_cred);


            string management_cred = (string)mgtContext.GetServiceToken().Result;
            Console.WriteLine("Management Token");
            Console.WriteLine(management_cred);

            string aad_cred = (string)aadContext.GetServiceToken().Result;
            Console.WriteLine("Active Directory Token");
            Console.WriteLine(aad_cred);

            string partner_portal_cred = (string)amaContext.GetServiceToken().Result;
            Console.WriteLine("Partner Portal Token");
            Console.WriteLine(partner_portal_cred);
        }
    }
}
