using Munazara.Application.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Munazara.Web.Controllers
{
    public class HomeController : Controller
    {
        ITopicService topicService;
        public HomeController(ITopicService topicService)
        {
            this.topicService = topicService;
        }
        public ActionResult Index()
        {
          var model=  topicService.GetLastTopics();
            
            return View(model);
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