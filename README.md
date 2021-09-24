# AzureRESTValidation
<sub>Dan Grecoe is a Microsoft Employee</sub>


Examples on how to validate with Azure Resource Manager (Python/.NET Core) and Azure Partner Portal and Azure Active Directory (.NET Core) REST API's 

The main goal of this example is to show how to obtain a bearer token to perform tasks with different Auzre Services. 

## Python
The python example (testapp.py and ./microsoft/) contain the python source to work with the Azure Management service with an example on how to work with Azure Key Vault to provide an Azure Active Directory user/group GET access to the vault secrets. 


### Obtain token using the Azure CLI logged in user.
This uses the azure.identity package (which is why you need a conda environment) to obtain the currently logged in user and obtain a token from there.

> ./microsoft/cliutil.py

### Obtain token using a service principal 
This uses a rest call to the management layer in Azure to obtain a token for a given service principal. 

You have to identify the principal in the confugration.json file and set the usePrincipal flag to true. 

> ./microsoft/rawutil.py

## .NET Core
Under the NETCore/ folder is an example of obtaining a service token for the following services.

Unlike with Python, it is not extended to provide any real working example, just how to obtain the token itself. 

- Azure Management 
- Azure Active Directory
- Microsoft Partner Portal