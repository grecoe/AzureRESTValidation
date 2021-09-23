from microsoft.utils import (
    RawRestCredUtil,
    AzCliCredUtil,
    Configuration,
    AzKeyVaultPermissions
)

"""
Load configuration settings to be used
"""
config = Configuration("./configuration.json")

"""
We need a bearer token for the API call. We can retrieve one either through the 
logged in user OR for a provided Service Principal in configuration.json.
"""
bearer_token = None
if config.usePrincipal:
    bearer_token = RawRestCredUtil.get_management_access_key_for_sp(config.servicePrincipal)
else:
    bearer_token = AzCliCredUtil.get_management_access_key_for_user()


# Seed the class with the bearer token and make the call.
azKeyVault = AzKeyVaultPermissions(bearer_token)
action_response = azKeyVault.perform_action(config.keyVaultInformation, config.appointee)
print(action_response)