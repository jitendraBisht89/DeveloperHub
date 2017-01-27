using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityMapping
{
  public  class DBContextFactory
    {
        private readonly DbContext dbContext;
        public DBContextFactory()
        {
            dbContext = new DB();
        }

        public DbContext GetContext()
        {
            return dbContext;
        }

    }
}
