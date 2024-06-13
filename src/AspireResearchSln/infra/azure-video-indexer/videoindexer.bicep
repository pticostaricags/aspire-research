param location string = resourceGroup().location
param storageAccountName string
param videoIndexerAccountName string

resource storageAccount 'Microsoft.Storage/storageAccounts@2021-06-01' = {
  name: storageAccountName
  location: location
  sku: {
    name: 'Standard_LRS'
  }
  kind: 'StorageV2'
  properties: {
    accessTier: 'Hot'
  }
}

resource videoIndexer 'Microsoft.VideoIndexer/accounts@2024-01-01' = {
    name: videoIndexerAccountName
    location: location
    identity: {
        type: 'SystemAssigned'
    }

    properties: {
        storageServices : {
            resourceId : storageAccount.id
        }
    }
}

output servicePrincipalObjectId string = videoIndexer.identity.principalId
output selectedstorageAccountName string = storageAccountName