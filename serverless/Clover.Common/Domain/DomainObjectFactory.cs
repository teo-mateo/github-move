using System;
using System.Collections.Generic;
using System.Text;

namespace Clover.Common.Domain
{
    public interface IDomainObjectFactory<TDomainObject>
    {
        TDomainObject Create();
    }
}
