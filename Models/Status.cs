using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Contract.Models
{
    public class Status
    {
        public Status()
        {
            this.Contracts = new HashSet<Contract>();
        }
        public int StatusId { get; set; }
        public string StatusDesc { get; set; }
        public virtual ICollection<Contract> Contracts { get; set; }
    }
}