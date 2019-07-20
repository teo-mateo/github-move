using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clover.Identity.Data.Entities
{
    public class UserEntity : TableEntity
    {
        public string Email { get { return this.RowKey; } }
        public string HashedPassword { get; set; }
        public bool IsBlocked { get; set; }

        public UserEntity() { }

        public UserEntity (string email, string hashedPassword, bool isBlocked)
        {
            this.PartitionKey = "users_" + email;
            this.RowKey = email;
            this.HashedPassword = hashedPassword;
            this.IsBlocked = isBlocked;
        }
    }
}
