using Munazara.Application.DataService.Topic;
using System.Web.Mvc;

namespace Munazara.Web.Controllers
{
    public class HomeController : BaseController
    {
        private ITopicService topicService;

        public HomeController(ITopicService topicService)
        {
            this.topicService = topicService;
        }

        public ActionResult Index()
        {
            var model = topicService.GetLastTopics();

            return View(model);
        }
    }
}