
from azure.identity import AzureCliCredential

class AzCliCredUtil:
    @staticmethod 
    def get_management_access_key_for_user():
        """
        Create a Auth Client for interacting with azure managment API's

        This is determined by the scope of managment.core.windows.net, other scopes
        are used for other purposes. 
        """
        working_credential = AzureCliCredential()
        token_obj = working_credential.get_token("https://management.core.windows.net/")
        # token_obj = working_credential.get_token("https://graph.microsoft.com/.default")
        return token_obj.token

