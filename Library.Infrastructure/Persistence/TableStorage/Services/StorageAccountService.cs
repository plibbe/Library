using Microsoft.Azure.Cosmos.Table;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Infrastructure.Persistence.TableStorage.Services
{
    public class StorageAccountService
    {
        internal static CloudStorageAccount GetStorageAccountFromConnectionString(string connectionString) => CloudStorageAccount.Parse(connectionString);
    }
}
