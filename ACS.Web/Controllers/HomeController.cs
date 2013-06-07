namespace ACS.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Web.Mvc;

    using ACS.Core.Models.Claims;

    public class HomeController : Controller
    {
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Api()
        {
            var cookie = this.Request.Cookies["ACS"];

            if (cookie != null)
            {
                var client = new HttpClient() { BaseAddress = new Uri("http://localhost:61411/api/") };
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("ACS", cookie.Value);

                var result = client.GetAsync("claims").Result;
                var claims = result.Content.ReadAsAsync<IEnumerable<SerializableClaim>>().Result;

                return View(claims);
            }

            return RedirectToAction("Index");
        }
    }
}