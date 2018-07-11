using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Contract.DAL
{
    public class ContractDBInitializer : DropCreateDatabaseAlways<ContractContext>
    {
        protected override void Seed(ContractContext context)
        {
            IList<Contract.Models.Contract> defaultRecord = new List<Contract.Models.Contract>();
            defaultRecord.Add(new Contract.Models.Contract()
            {
                Id = 1,
                FirstName = "Jay",
                LastName = "Parekh",
                Email = "Jay@abc.in",
                Phone = "7722075018",
                Status = new Models.Status() { StatusId = 1, StatusDesc = "Active" },
                StatusID = 1
            });
            defaultRecord.Add(new Contract.Models.Contract()
            {
                Id = 2,
                FirstName = "AJay",
                LastName = "Mak",
                Email = "AJay@pqr.in",
                Phone = "9898985018",
                Status = new Models.Status() { StatusId = 2, StatusDesc = "Inactive" },
                StatusID = 2
            });
            context.Contracts.AddRange(defaultRecord);
            base.Seed(context);
        }
    }
}