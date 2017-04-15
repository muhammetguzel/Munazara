using Munazara.Application.Data;
using Munazara.Application.Data.Requests;
using Munazara.Web.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace Munazara.Web.Controllers
{
 
    public class TopicController :BaseController
    {
        private ITopicService topicService;
        private ICategoryService categoryService;

        public TopicController(ITopicService topicService, ICategoryService categoryService)
        {
            this.topicService = topicService;
            this.categoryService = categoryService;
        }

        [HttpGet]       
        public ActionResult Create()
        {
            CreateTopicViewModel model = new CreateTopicViewModel
            {
                Categories = categoryService.GetCategories().Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Name })
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(CreateTopicViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    CreateTopicRequest reques = new CreateTopicRequest
                    {
                        CategoryId = viewModel.Category,
                        Content = viewModel.Content,
                        MemberId =1,// Convert.ToInt32(User.Identity.Name),
                        Title = viewModel.Title
                    };

                    var topicId = topicService.CreateTopic(reques);
                    TempData["Success"] = "Başarılı";
                    return RedirectToAction("Index", new { Id = topicId });
                }
                catch(Exception ex)
                {
                    Error(ex);
                    viewModel.Categories = categoryService.GetCategories().Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Name, Selected = viewModel.Category == x.Id });
                    return View(viewModel);
                }
            }
            else
            {
                viewModel.Categories = categoryService.GetCategories().Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Name});
                return View(viewModel);
            }
        }
    }
}