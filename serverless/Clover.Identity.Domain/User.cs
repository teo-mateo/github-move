using Clover.Common;
using Clover.Common.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

namespace Clover.Identity.Domain
{
    public class User : DomainObject<User>
    {
        public string Email { get; private set; }
        public string HashedPassword { get; private set; }
        public bool IsBlocked { get; private set; }

        public User(string email, string hashedPassword) : base(null, DateTimeOffset.Now)
        {
            this.Email = email;
            this.HashedPassword = hashedPassword;
        }

        public User(IUserRepository repository, string email, string hashedPassword, bool isBlocked, DateTimeOffset creationTime) : base(repository, creationTime)
        {
            this.Email = email;
            this.HashedPassword = hashedPassword;
            this.IsBlocked = IsBlocked;
        }

        
        public void Block()
        {
            this.IsBlocked = true;
            base.repository.Save(this);
        }

        public void Register()
        {
            base.repository.Save(this);
        }
    }
}
