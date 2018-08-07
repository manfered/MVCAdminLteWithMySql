using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCAdminLteWithMySql.Models;

namespace MVCAdminLteWithMySql.Controllers
{
    public class TopicController : Controller
    {
        // GET: Topic
        public ActionResult Index()
        {
            List<topic> topicList = new List<topic>();
            using (DBModels dbModels = new DBModels())
            {
                topicList = dbModels.topics.ToList<topic>();
            }
            return View(topicList);
        }

        // GET: Topic/Details/5
        public ActionResult Details(int id)
        {
            topic topicModel = new topic();
            using (DBModels dbModels = new DBModels())
            {
                topicModel = dbModels.topics.Where(x => x.TopicID == id).FirstOrDefault();
            }
            return View(topicModel);
        }

        // GET: Topic/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Topic/Create
        [HttpPost]
        public ActionResult Create(topic topicModel)
        {
            using (DBModels dbModels = new DBModels())
            {
                dbModels.topics.Add(topicModel);
                dbModels.SaveChanges();
            }
            return RedirectToAction("index");
        }

        // GET: Topic/Edit/5
        public ActionResult Edit(int id)
        {
            topic topicModel = new topic();
            using (DBModels dbModels = new DBModels())
            {
                topicModel = dbModels.topics.Where(x => x.TopicID == id).FirstOrDefault();
            }
            return View(topicModel);
        }

        // POST: Topic/Edit/5
        [HttpPost]
        public ActionResult Edit(topic topicModel)
        {
            using (DBModels dbModels = new DBModels())
            {
                dbModels.Entry(topicModel).State = System.Data.Entity.EntityState.Modified;
                dbModels.SaveChanges();
            }
            return RedirectToAction("index");
        }

        // GET: Topic/Delete/5
        public ActionResult Delete(int id)
        {
            topic topicModel = new topic();
            using (DBModels dbModels = new DBModels())
            {
                topicModel = dbModels.topics.Where(x => x.TopicID == id).FirstOrDefault();
            }
            return View(topicModel);
        }

        // POST: Topic/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            using (DBModels dbModel = new DBModels())
            {
                topic topicModel = dbModel.topics.Where(x => x.TopicID == id).FirstOrDefault();
                dbModel.topics.Remove(topicModel);

                dbModel.SaveChanges();
            }

            return RedirectToAction("index");
        }
    }
}
