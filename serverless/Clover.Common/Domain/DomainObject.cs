using System;
using System.Collections.Generic;
using System.Text;

namespace Clover.Common.Domain
{
    public class DomainObject<T>
    {
        public DateTimeOffset CreationTime { get; protected set; }

        protected IRepository<T> repository;

        public DomainObject(IRepository<T> repository, DateTimeOffset creationTime)
        {
            this.repository = repository;
            this.CreationTime = creationTime;
        }
    }
}
