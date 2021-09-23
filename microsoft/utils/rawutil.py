import requests

class RawRestCredUtil:

    @staticmethod 
    def get_management_access_key_for_sp(creds):
        """
        Create a Auth Client for interacting with azure managment API's

        Option 2 with the AzureCliCredential but doesn't seem to work. 
        working_credential = AzureCliCredential()
        token_obj = working_credential.get_token("https://graph.microsoft.com/.default")
        header_bearer = token_obj.token
        """
        endpoint = "https://management.core.windows.net/"
        return RawRestCredUtil._get_access_key(endpoint, creds)

    @staticmethod
    def _get_access_key(resource: str, creds: dict):

        url = "https://login.microsoftonline.com/%s/oauth2/token" % creds.tenent
        headers = {"content-type": "application/x-www-form-urlencoded"}
        data = {
            "grant_type": "client_credentials", 
            "client_id": creds.application, 
            "client_secret": creds.credential, 
            "resource": resource}

        response = requests.post(url=url, data=data, headers=headers)
        if response.status_code != 200:
            raise ConnectionRefusedError("Unable to create Azure Active Directory access token")
        return response.json()["access_token"]

