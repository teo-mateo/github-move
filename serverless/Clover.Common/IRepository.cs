using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Clover.Common
{
    public interface IRepository<T>
    {
        Task<dynamic> Get(string identifier);
        Task Save(T domainObject);
    }
}
