using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Contract.DAL
{
    public class ContractContext:DbContext
    {
        public ContractContext()
            : base("DefaultConnection")
        {
            Database.SetInitializer(new ContractDBInitializer());
        }
        public virtual DbSet<Contract.Models.Contract> Contracts { get; set; }
        public virtual DbSet<Contract.Models.Status> Status { get; set; }
    }
}