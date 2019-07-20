using Clover.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clover.Identity.Domain
{
    public interface IUserRepository : IRepository<User>
    {
        IEnumerable<dynamic> GetAll();
    }
}
