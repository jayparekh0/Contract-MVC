using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Contract.DAL
{
    public class ContractRepository:IRepository
    {
        private ContractContext _context;

        public ContractRepository(ContractContext context)
        {
            _context = context;
        }

        public IEnumerable<Models.Contract> GetAllContracts()
        {
            return _context.Contracts.Include(foo=>foo.Status).ToList();
        }

        public Models.Contract GetContractByID(int contractIdId)
        {
            return GetAllContracts().Where(f => f.Id == contractIdId).FirstOrDefault();
        }

        public int AddContract(Models.Contract contractIdEntity)
        {
            int result = -1;
            if (contractIdEntity != null)
            {
                _context.Contracts.Add(contractIdEntity);
                _context.SaveChanges();
                result = contractIdEntity.Id;
            }
            return result;
        }

        public int UpdateContract(Models.Contract contractEntity)
        {
            int result = -1;
            if (contractEntity != null)
            {
                _context.Entry(contractEntity).State = EntityState.Modified;
                _context.SaveChanges();
                result = contractEntity.Id;
            }
            return result;
        }

        public void DeleteContract(int contractId)
        {
            Contract.Models.Contract contractEntity = _context.Contracts.Find(contractId);
            _context.Contracts.Remove(contractEntity);
            _context.SaveChanges();
        }
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}