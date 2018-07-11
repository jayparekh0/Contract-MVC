using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contract.Models;

namespace Contract.DAL
{
    interface IRepository
    {
        IEnumerable<Contract.Models.Contract> GetAllContracts();
        Contract.Models.Contract GetContractByID(int contractIdId);
        int AddContract(Contract.Models.Contract contractIdEntity);
        int UpdateContract(Contract.Models.Contract contractEntity);
        void DeleteContract(int contractId);
    }
}
