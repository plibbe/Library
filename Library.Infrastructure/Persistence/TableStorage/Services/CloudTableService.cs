using Microsoft.Azure.Cosmos.Table;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Library.Infrastructure.Persistence.TableStorage.Services
{
    internal class CloudTableService
    {
        public static async Task<CloudTable> GetTable(string tableName)
        {
            var connectionString = Environment.GetEnvironmentVariable("AzureTableConnectionString");
            // Retrieve storage account information from connection string.
            CloudStorageAccount storageAccount = StorageAccountService.GetStorageAccountFromConnectionString(connectionString);

            // Create a table client for interacting with the table service
            CloudTableClient tableClient = storageAccount.CreateCloudTableClient(new TableClientConfiguration());

            // Create a table client for interacting with the table service 
            return tableClient.GetTableReference(tableName);

        }
    }
}
