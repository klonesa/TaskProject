using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Web;
using System.Web.Mvc;
using TaskProject.Entities.Models;
using TaskProject.Interfaces;

namespace TaskProject.MvcUI.Controllers
{
    public class CompanyController : Controller
    {
        ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        public ActionResult Index()
        {
           
            var list = _companyService.GetAll();
            return View(list);
        }

        public ActionResult Create()
        {
            return PartialView();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CompanyName,TaxNumber,Phone,Address")] Company company)
        {
            if (ModelState.IsValid)
            {
                string CompanyName = Request.Form["CompanyName"];
                string TaxNumber = Request.Form["TaxNumber"];
                string Phone = Request.Form["Phone"];
                string Address = Request.Form["Address"];
                Dictionary<string, string> details = new Dictionary<string, string>();
                details.Add("CompanyName", CompanyName);
                details.Add("TaxNumber", TaxNumber);
                details.Add("Phone", Phone);
                details.Add("Address", Address);
                string jsonString = JsonSerializer.Serialize(details);
                company.CompanyDetail = jsonString;
                var result = _companyService.Add(company);
                return Json(result);
            }
            return Json("Create error");
        }


        //GET: MyEntities/Edit/5
        public ActionResult Edit(int id)
        {

            var kontrol = _companyService.Get(id);
            if (kontrol == null)
            {
                return HttpNotFound();
            }
            return PartialView(kontrol);
        }

        //POST: MyEntities/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CompanyName,TaxNumber,Phone,Address")] Company company)
        {
            if (ModelState.IsValid)
            {
                string CompanyName = Request.Form["CompanyName"];
                string TaxNumber = Request.Form["TaxNumber"];
                string Phone = Request.Form["Phone"];
                string Address = Request.Form["Address"];
                Dictionary<string, string> details = new Dictionary<string, string>();
                details.Add("CompanyName", CompanyName);
                details.Add("TaxNumber", TaxNumber);
                details.Add("Phone", Phone);
                details.Add("Address", Address);
                string jsonString = JsonSerializer.Serialize(details);
                company.CompanyDetail = jsonString;
                var update = _companyService.Update(company);
                return Json(update);
            }
            return Json("Edit error");
        }

        //GET: MyEntities/Delete/5
        public ActionResult Delete(int id)
        {

            var result = _companyService.Get(id);
            if (result == null)
            {
                return HttpNotFound();
            }
            return PartialView(result);
        }

        //POST: MyEntities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var result = _companyService.Remove(id);

            return Json(result);
        }
    }
}