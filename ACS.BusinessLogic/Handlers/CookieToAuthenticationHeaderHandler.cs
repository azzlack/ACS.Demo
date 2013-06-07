namespace ACS.BusinessLogic.Handlers
{
    using System.Web;

    using ACS.Core.Interfaces.Handlers;

    public class CookieToAuthenticationHeaderHandler : ICookieToAuthenticationHeaderHandler
    {
        private readonly string cookieName;

        public CookieToAuthenticationHeaderHandler(string cookieName)
        {
            this.cookieName = cookieName;
        }

        public void Process(HttpRequestBase request)
        {
            var cookie = request.Cookies.Get(this.cookieName);

            if (cookie != null && request.Headers.Get("Authorization") == null)
            {
                request.Headers.Add("Authorization", string.Format("{0} {1}", this.cookieName, cookie.Value));
            }
        }
    }
}