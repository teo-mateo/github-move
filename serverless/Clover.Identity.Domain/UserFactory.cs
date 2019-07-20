using Clover.Common.Domain;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Clover.Identity.Domain
{
    public class UserFactory 
    {
        private IUserRepository repository;

        public UserFactory(IUserRepository repository)
        {
            this.repository = repository;
        }

        public async Task<User> Load(string email)
        {
            dynamic userData = await repository.Get(email);
            return new User(repository, userData.Email, userData.HashedPassword, userData.IsBlocked, userData.CreationTime);
        }

        public async Task<User> Create(string email, string clearPassword)
        {
            SHA256 sha = SHA256.Create();
            byte[] hashedBytes = sha.ComputeHash(Encoding.ASCII.GetBytes(clearPassword));
            StringBuilder sb = new StringBuilder();
            foreach (var b in hashedBytes)
            {
                sb.Append(String.Format("{0:x2}", b));
            }
            
            var user = new User(repository, email, sb.ToString(), false, DateTimeOffset.Now);
            await repository.Save(user);
            return user;
        }
    }
}
