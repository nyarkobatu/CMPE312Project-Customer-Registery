using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace CMPE312Project
{
    internal class CustomerContext : DbContext
    {
        public DbSet<CustomerInfo> CustomerInfos { get; set; }
    }
}
