using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCAdminLteWithMySql.Models;

namespace MVCAdminLteWithMySql.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            AdminHomeModel adminHomeModel = new AdminHomeModel();
            using (DBModels dbModels = new DBModels())
            {
                adminHomeModel.UsersCount = dbModels.users.Count<user>();
                adminHomeModel.TopicsCount = dbModels.topics.Count<topic>();
                adminHomeModel.CommentsCount = 0;
            }
            return View(adminHomeModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}