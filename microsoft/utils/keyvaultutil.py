"""
For this example we will set the "GET" access for a specific user to an 
Azure Key Vault. 
"""
import requests
from .config import GenericObject

class AzKeyVaultPermissions:
    MANAGEMENT_URI = "https://management.azure.com/subscriptions/{subscription}/resourceGroups/{resourceGroup}/providers/Microsoft.KeyVault/vaults/{vaultName}/accessPolicies/{operation}?api-version={version}"
    OPERATION_PAYLOAD = {
        "add" : {
            "properties": {
                "accessPolicies": [
                {
                    "tenantId": "{appointee_attendee}",
                    "objectId": "{appointee_objectid}",
                    "permissions": {
                        "secrets": [
                            "get"
                        ]}
                }]
            }
        }
    }

    def __init__(self, auth_token:str):
        self.auth_token = auth_token

    def perform_action(self, key_vault_info:GenericObject, appointee_info:GenericObject):

        if not self.auth_token:
            raise Exception("No token....")

        if key_vault_info.keyVaultOperation not in AzKeyVaultPermissions.OPERATION_PAYLOAD:
            raise Exception("Unexpected action")

        target_uri = AzKeyVaultPermissions.MANAGEMENT_URI.format(
            subscription = key_vault_info.subscription,
            resourceGroup = key_vault_info.resourceGroup,
            vaultName = key_vault_info.keyVaultName,
            operation = key_vault_info.keyVaultOperation,
            version = key_vault_info.keyVaultApiVersion
        )

        op_payload = AzKeyVaultPermissions.OPERATION_PAYLOAD[key_vault_info.keyVaultOperation]

        if "add" == key_vault_info.keyVaultOperation:
            op_payload["properties"]["accessPolicies"][0]["tenantId"] = appointee_info.tenent
            op_payload["properties"]["accessPolicies"][0]["objectId"] = appointee_info.object

        headers = {
            "Authorization": "Bearer {}".format(self.auth_token),
            "Content-Type" : "application/json" 
        }

        return requests.put(target_uri, json=op_payload, headers=headers)

        