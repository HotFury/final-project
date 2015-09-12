using Periodical.Web.Models.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Periodical.Web.Providers;
using Periodical.BusinessLogic.Repositories;

namespace Periodical.Web.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        //
        // GET: /Account/
        private AccountRepository accountRepository = new AccountRepository();
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LogInModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (accountRepository.UserIsActive(model.Nick))
                {
                    if (Membership.ValidateUser(model.Nick, model.Password))
                    {
                        FormsAuthentication.SetAuthCookie(model.Nick, model.RememberMe);
                        {
                            if (Url.IsLocalUrl(returnUrl))
                            {
                                return Redirect(returnUrl);
                            }
                            else
                            {
                                return RedirectToAction("Index", "Home");
                            }
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Неправильный ник или пароль");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Вас заблокировали");
                }
            }
            return View(model);
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                if (accountRepository.NickCanUse(model.Nick))
                {
                    if (accountRepository.EmailCanUse(model.Email))
                    {
                        MembershipUser membershipUser = ((CustomMembershipProvider)Membership.Provider).CreateUser(model.Nick.ToLower(), model.Password, model.Email);
                        if (membershipUser != null)
                        {
                            FormsAuthentication.SetAuthCookie(model.Nick.ToLower(), false);
                            return RedirectToAction("Index", "Home");
                        }
                        else
                        {
                            ModelState.AddModelError("", "Ошибка при регистрации");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "E-mail занят");
                    }
                }
                else {
                    ModelState.AddModelError("", "Ник занят");
                }
                
            }
            return View(model);
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}
