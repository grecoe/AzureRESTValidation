# AzureRESTValidation
Examples on how to validate with Azure Resource Manager REST API's 

The main goal of this example is to show how to obtain a bearer token to perform tasks in the Auzre Resource Manager layer. 

Scope to accomplish this: https://management.core.windows.net/

Additional Scopes can be found here:
https://docs.microsoft.com/en-us/azure/active-directory/develop/msal-v1-app-scopes


## Obtain token using the Azure CLI logged in user.
This uses the azure.identity package (which is why you need a conda environment) to obtain the currently logged in user and obtain a token from there.

> ./microsoft/cliutil.py

## Obtain token using a service principal 
This uses a rest call to the management layer in Azure to obtain a token for a given service principal. 

You have to identify the principal in the confugration.json file and set the usePrincipal flag to true. 

> ./microsoft/rawutil.py

# Application Purpose
Using either an Azure CLI credential or a service principal, make a call to an Azure Key vault to allow a group/user in your AAD to have GET permission on the vaults secrets. 

Open configuration.json and set up the appropriate settings to test. 