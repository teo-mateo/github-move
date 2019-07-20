using Clover.Common;
using Clover.Identity.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using Microsoft.WindowsAzure.Storage.Auth;
using Clover.Common.Configuration;
using Clover.Identity.Data.CloudStorage;
using System.Threading.Tasks;
using Clover.Identity.Data.Entities;

namespace Clover.Identity.Data
{
    /// <summary>
    /// repository implementation for the User domain object with Table Storage
    /// </summary>
    public class UserRepository : TableStorageRepository, IUserRepository
    {

        public UserRepository(ICloverConfig config) : base(config, "users")
        {
            
        }

        public async Task<dynamic> Get(string identifier)
        {
            var table = await base.GetCloudTable();
            TableOperation retrieveOperation = TableOperation.Retrieve<UserEntity>("users_" + identifier, identifier);
            var tableResult = await table.ExecuteAsync(retrieveOperation);
            if (tableResult != null)
            {
                return (UserEntity)tableResult.Result;
            }
            else
            {
                throw new Exception("not found");
            }
        }

        public IEnumerable<dynamic> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task Save(User domainObject)
        {
            var table =  await base.GetCloudTable();
            var entity = new UserEntity(domainObject.Email, domainObject.HashedPassword, domainObject.IsBlocked);
            TableOperation insert = TableOperation.InsertOrReplace(entity);
            await table.ExecuteAsync(insert);
        }
    }
}
