using BARINAK_OTOMASYON.DAL;
using BARINAK_OTOMASYON.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Mvc;
using System.Web.Security;

namespace BARINAK_OTOMASYON.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        [AllowAnonymous]
        public ActionResult Login()
        {
            if (String.IsNullOrEmpty(HttpContext.User.Identity.Name))
            {
                FormsAuthentication.SignOut();
                return View();
            }
            return Redirect("/Admin/Login/Login");


        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(Login model, string returnurl)
        {


            if (ModelState.IsValid)
            {
                using (BarinakContext bc = new BarinakContext())
                {
                    {
                        var prs = bc.Kullanicilar.Where(a => a.Username == model.Username && a.Password == model.Password);
                        if (prs.Count() > 0)
                        {
                            FormsAuthentication.SetAuthCookie(model.Username, true);
                            return Redirect("/Hayvan/Index");
                        }
                        else
                        {
                            ModelState.AddModelError("", "Kullanıcı Adı veya Şifre Hatalı!");
                        }

                    }

                }
            }



            return View(model);
        }
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Login");
        }
    }
}