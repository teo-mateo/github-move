using Clover.Common.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Clover.Identity.Data.CloudStorage
{
    public abstract class TableStorageRepository
    {
        private Func<Task<CloudTable>> tableInit;

        private CloudTable table;
        protected async Task<CloudTable> GetCloudTable()
        {
            if (table == null)
            {
                table = await tableInit();
            }
            return table;
        }
        
        public TableStorageRepository(ICloverConfig config, string tableName)
        {
            tableInit = new Func<Task<CloudTable>>( async () => {
                var storageCredentials = new StorageCredentials(
                    config.Get(CloverConfigEnum.CLOVER_STORAGE_ACCOUNT),
                    config.Get(CloverConfigEnum.CLOVER_STORAGE_KEY)
                    );

                CloudStorageAccount storageAccount = new CloudStorageAccount(storageCredentials, true);
                CloudTableClient tableClient = storageAccount.CreateCloudTableClient();
                CloudTable table = tableClient.GetTableReference(tableName);

                await table.CreateIfNotExistsAsync();
                return table;
            });
        }
        
        public async Task<bool> CloudTableExists()
        {
            var table = await GetCloudTable();
            return await table.ExistsAsync();
        }
    }
}
