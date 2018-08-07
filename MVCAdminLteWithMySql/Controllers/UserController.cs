using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCAdminLteWithMySql.Models;

namespace MVCAdminLteWithMySql.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            List<Models.user> userList = new List<Models.user>();
            using (DBModels dbModels = new DBModels())
            {
                userList = dbModels.users.ToList<Models.user>();
            }
            return View(userList);
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            Models.user userModel = new user();
            using (DBModels dbModels = new DBModels())
            {
                userModel = dbModels.users.Where(x => x.UserID == id).FirstOrDefault();
            }
            return View(userModel);
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(user userModel)
        {
            using (DBModels dbModels = new DBModels())
            {
                dbModels.users.Add(userModel);
                dbModels.SaveChanges();
            }

            return RedirectToAction("index");
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            Models.user userModel = new user();
            using (DBModels dbModels = new DBModels())
            {
                userModel = dbModels.users.Where(x => x.UserID == id).FirstOrDefault();
            }
            return View(userModel);
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(user userModel)
        {
            using (DBModels dbModels = new DBModels())
            {
                dbModels.Entry(userModel).State = System.Data.Entity.EntityState.Modified;
                dbModels.SaveChanges();
            }

            return RedirectToAction("index");
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            Models.user userModel = new user();
            using (DBModels dbModels = new DBModels())
            {
                userModel = dbModels.users.Where(x => x.UserID == id).FirstOrDefault();
            }
            return View(userModel);
        }

        // POST: User/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            using (DBModels dbModels = new DBModels())
            {
                user userModel = dbModels.users.Where(x => x.UserID == id).FirstOrDefault();
                dbModels.users.Remove(userModel);

                dbModels.SaveChanges();
            }

            return RedirectToAction("index");
        }
    }
}
