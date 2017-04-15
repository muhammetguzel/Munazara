using Munazara.Application.DataService.Category;
using Munazara.Application.DataService.Topic;
using Munazara.Application.DataService.Topic.Request;
using Munazara.Web.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace Munazara.Web.Controllers
{
    public class TopicController : BaseController
    {
        private ITopicService topicService;
        private ICategoryService categoryService;

        public TopicController(ITopicService topicService, ICategoryService categoryService)
        {
            this.topicService = topicService;
            this.categoryService = categoryService;
        }

        [HttpGet]
        public ActionResult Detail()
        {
            return View();
        }

        [HttpGet]
        [Authorize]
        public ActionResult Create()
        {
            CreateTopicViewModel model = new CreateTopicViewModel
            {
                Categories = categoryService.GetCategories().Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Name })
            };
            return View(model);
        }

        [HttpPost]
        [Authorize]
        public ActionResult Create(CreateTopicViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Categories = categoryService.GetCategories().Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Name });
                return View(model);
            }
            try
            {
                CreateTopicRequest request = new CreateTopicRequest
                {
                    CategoryId = model.Category,
                    Content = model.Content,
                    MemberId = Convert.ToInt32(User.Identity.Name),
                    Title = model.Title
                };

                var response = topicService.CreateTopic(request);
                return RedirectToAction("Detail", new { Id = response.Id, Slug = response.Slug });
            }
            catch (Exception ex)
            {
                Error(ex);

                model.Categories = categoryService.GetCategories().Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Name, Selected = model.Category == x.Id });
                return View(model);
            }
        }
    }
}