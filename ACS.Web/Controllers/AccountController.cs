namespace ACS.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Security.Claims;
    using System.Web;
    using System.Web.Mvc;

    using ACS.BusinessLogic.Factories;
    using ACS.Core.Interfaces.Factories;
    using ACS.Core.Models.Claims;

    [Authorize]
    public class AccountController : Controller
    {
        private readonly IAcsRequestSecurityTokenResponseFactory acsRequestSecurityTokenResponseFactory;

        public AccountController()
        {
            this.acsRequestSecurityTokenResponseFactory = new AcsRequestSecurityTokenResponseFactory();
        }

        //
        // GET: /Account/Login

        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;

            return View();
        }

        //
        // POST: /Account/ACS

        [HttpPost]
        [AllowAnonymous]
        [ValidateInput(false)]
        public ActionResult ACS(string wa, string wresult)
        {
            var token = this.acsRequestSecurityTokenResponseFactory.Create(wresult);

            // Add ACS token to cookie collection
            Response.Cookies.Add(new HttpCookie("ACS", token.SecurityToken));

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Error(string ErrorDetails)
        {
            throw new HttpException(500, Request.Form["ErrorDetails"]);
        }

        //
        // POST: /Account/LogOff

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            if (Request.Cookies["ACS"] != null)
            {
                var c = new HttpCookie("ACS") { Expires = DateTime.Now.AddDays(-1) };
                Response.Cookies.Add(c);
            }

            return RedirectToAction("Index", "Home");
        }

        //
        // GET: /Account/Manage

        public ActionResult Manage()
        {
            var claims = ClaimsPrincipal.Current.Claims.Select(x => new SerializableClaim() { Type = x.Type, Value = x.Value });

            return View(claims);
        }
    }
}