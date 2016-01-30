using Private.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Private.Core.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly PrivateContext _context;

        public Repository(PrivateContext context)
        {
            _context = context;
        }

        public T Get()
        {
            throw new NotImplementedException();
        }

        public void Insert()
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> Query()
        {
            return _context.Set<T>().AsQueryable<T>();
        }

        public void Remove()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
