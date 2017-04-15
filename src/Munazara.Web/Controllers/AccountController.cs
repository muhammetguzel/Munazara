using Munazara.Application.DataService.Member;
using Munazara.Application.DataService.Member.Request;
using Munazara.Web.Models;
using System;
using System.Web.Mvc;
using System.Web.Security;

namespace Munazara.Web.Controllers
{
    public class AccountController : BaseController
    {
        private IMemberService memberService;

        public AccountController(IMemberService memberService)
        {
            this.memberService = memberService;
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            try
            {
                var password = FormsAuthentication.HashPasswordForStoringInConfigFile(model.Password, "sha1");
                var member = memberService.Login(new LoginRequest { UserName = model.UserName, Password = password });
                if (member == null)
                {
                    ModelState.AddModelError("", "Hatalı giriş bilgileri");
                    return View(model);
                }
                else
                {
                    FormsAuthentication.SetAuthCookie(member.Id.ToString(), true);
                    return Redirect("/");
                }
            }
            catch (Exception ex)
            {
                Error(ex);
                return View(model);
            }
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            try
            {
                var password = FormsAuthentication.HashPasswordForStoringInConfigFile(model.Password, "sha1");
                var member = memberService.Register(new RegisterRequest { UserName = model.UserName, Password = password, Email = model.Email });
                if (member == null)
                {
                    ModelState.AddModelError("", "Bu kullanıcı adı ya da E-Posta ile daha önce kayıt yapılmış");
                    return View(model);
                }
                else
                {
                    FormsAuthentication.SetAuthCookie(member.Id.ToString(), true);
                    return Redirect("/");
                }
            }
            catch (Exception ex)
            {
                Error(ex);
                return View(model);
            }
        }

        [HttpPost]
        public ActionResult CheckUserName(string UserName)
        {
            try
            {
                return Json(!memberService.IsUserNameUsed(UserName));
            }
            catch
            {
                return Json(false);
            }
        }

        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();

            return Redirect("/");
        }
    }
}