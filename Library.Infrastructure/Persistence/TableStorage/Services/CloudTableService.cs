using Microsoft.Azure.Cosmos.Table;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Library.Infrastructure.Persistence.TableStorage.Services
{
    internal class CloudTableService
    {
        public static CloudTable GetTable(string tableName)
        {
            CloudStorageAccount storageAccount = StorageAccountService.GetStorageAccountFromConnectionString(Environment.GetEnvironmentVariable("AzureTableConnectionString"));

            CloudTableClient tableClient = storageAccount.CreateCloudTableClient(new TableClientConfiguration());

            return tableClient.GetTableReference(tableName);

        }
    }
}
