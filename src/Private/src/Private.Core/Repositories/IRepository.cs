using Private.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Private.Core.Repositories
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> Query();

        T Get();

        void Insert();

        void Update();

        void Remove();
    }
}
