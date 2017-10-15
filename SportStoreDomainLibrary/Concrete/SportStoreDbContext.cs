using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using SportStoreDomainLibrary.Entities;

namespace SportStoreDomainLibrary.Concrete
{
    public class SportStoreDbContext : DbContext
    {
        public SportStoreDbContext() : base("SportStoreConnection") { }
        public DbSet<Product> Products { get; set; }
    }

}
