using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Web;
using System.Web.Mvc;
using TaskProject.Entities.Models;
using TaskProject.Interfaces;

namespace TaskProject.MvcUI.Controllers
{
    public class UserController : Controller
    {
        IUserService _userService;
        ICompanyService _companyService;
        IRoleService _roleService;

        public UserController(IUserService userService, ICompanyService companyService, IRoleService roleService)
        {
            _userService = userService;
            _companyService = companyService;
            _roleService = roleService;
        }

        // GET: User
        public ActionResult Index()
        {
            var list = _userService.GetAll();
                 
            return View(list);
        }

        public ActionResult Create()
        {
            var roles = _roleService.GetAll();
            var company = _companyService.GetAll();
            List<SelectListItem> items = new List<SelectListItem>();
           
            foreach (var item in company)
            {
                List<string> itemsCompany = JsonSerializer.Deserialize<List<string>>(item.CompanyDetail);
            }
            foreach (var role in roles)
            {
                items.Add(new SelectListItem { Text = role.RoleName,  Value = role.Id.ToString() });
            }
            ViewBag.RoleType = items;

            return PartialView();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RoleId,CompanyId,UserName,Eposta")] User user)
        {
            if (ModelState.IsValid)
            {

                string UserName = Request.Form["UserName"];
                string Eposta = Request.Form["Eposta"];
                Dictionary<string, string> details = new Dictionary<string, string>();
                details.Add("UserName", UserName);
                details.Add("Eposta", Eposta);
                string jsonString = JsonSerializer.Serialize(details);
                user.UserDetail = jsonString;
                var result = _userService.Add(user);
                return Json(result);
            }
            return Json("Create error");
        }


        //GET: MyEntities/Edit/5
        public ActionResult Edit(int id)
        {

            var kontrol = _userService.Get(id);
            if (kontrol == null)
            {
                return HttpNotFound();
            }
            return PartialView(kontrol);
        }

        //POST: MyEntities/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,RoleId,CompanyId,UserName,Eposta")] User user)
        {
            if (ModelState.IsValid)
            {
                string UserName = Request.Form["UserName"];
                string Eposta = Request.Form["Eposta"];
                Dictionary<string, string> details = new Dictionary<string, string>();
                details.Add("UserName", UserName);
                details.Add("Eposta", Eposta);
                string jsonString = JsonSerializer.Serialize(details);
                user.UserDetail = jsonString;
                var update = _userService.Update(user);
                return Json(update);
            }
            return Json("Edit error");
        }

        //GET: MyEntities/Delete/5
        public ActionResult Delete(int id)
        {

            var result = _userService.Get(id);
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
            var result = _userService.Remove(id);

            return Json(result);
        }


    }
}