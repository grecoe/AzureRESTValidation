namespace AzureCredentials.Contexts.BaseUtils
{
    class ServicePrincipal
    {
        public string Tenet { get; set; }
        public string ApplicationId { get; set; }
        public string Credential{ get; set; }

        public ServicePrincipal()
        {

        }

        public ServicePrincipal(string tenent, string appid, string cred)
        {
            this.Tenet = tenent;
            this.ApplicationId = appid;
            this.Credential = cred;
        }

    }
}
