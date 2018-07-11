using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Contract.Models;
using Contract.DAL;

namespace Contract.Controllers
{
    [Authorize]
    public class ContractController : Controller
    {
        private IRepository _repo;

        public ContractController()
        {
            _repo = new ContractRepository(new ContractContext());
        }

        // GET: /Contract/
        public ActionResult Index()
        {
            return View(_repo.GetAllContracts());
        }

        // GET: /Contract/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contract.Models.Contract contract = _repo.GetContractByID(id);
            if (contract == null)
            {
                return HttpNotFound();
            }
            return View(contract);
        }

        // GET: /Contract/Create
        public ActionResult Create()
        {
            ViewBag.StatusID = new SelectList( (new ContractContext()).Status, "StatusId", "StatusDesc");
            return View();
        }

        // POST: /Contract/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,FirstName,LastName,Email,Phone,StatusID")] Contract.Models.Contract contract)
        {
            if (ModelState.IsValid)
            {
                int result = _repo.AddContract(contract);
                if (result > 0)
                {
                    return RedirectToAction("Index", "Contract");
                }
                else
                {
                    TempData["Failed"] = "Failed";
                    return RedirectToAction("Create", "Contract");
                }
            }
            return View();
        }

        // GET: /Contract/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contract.Models.Contract contract = _repo.GetContractByID(id);
            if (contract == null)
            {
                return HttpNotFound();
            }
            ViewBag.StatusID = new SelectList((new ContractContext()).Status, "StatusId", "StatusDesc", contract.StatusID);
            return View(contract);
        }

        // POST: /Contract/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,FirstName,LastName,Email,Phone,StatusID")] Contract.Models.Contract contract)
        {
            if (ModelState.IsValid)
            {
                int result = _repo.UpdateContract(contract);
                if (result > 0)
                {
                    return RedirectToAction("Index", "Contract");
                }
                else
                {
                    TempData["Failed"] = "Failed";
                    return RedirectToAction("Edit", "Contract");
                }
            }
            return View();
        }

        // GET: /Contract/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contract.Models.Contract contract = _repo.GetContractByID(id);
            if (contract == null)
            {
                return HttpNotFound();
            }
            return View(contract);
        }

        // POST: /Contract/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (id != null)
            {
                _repo.DeleteContract(id);
            }
            else {
                TempData["Failed"] = "Failed";
            }
            return RedirectToAction("Index");
        }
    }
}
