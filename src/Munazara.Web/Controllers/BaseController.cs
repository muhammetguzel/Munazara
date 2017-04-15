using System;
using System.Web.Mvc;

namespace Munazara.Web.Controllers
{
    public class BaseController : Controller
    {
        public BaseController()
        {
        }

        public void Error(Exception ex)
        {
            TempData["Error"] = ex.Message;
        }
    }
}