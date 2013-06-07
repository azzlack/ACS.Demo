namespace ACS.Core.Interfaces.Handlers
{
    using System.Web;

    public interface ICookieToAuthenticationHeaderHandler
    {
        void Process(HttpRequestBase request);
    }
}