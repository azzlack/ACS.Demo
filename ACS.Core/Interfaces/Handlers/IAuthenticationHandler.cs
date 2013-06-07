namespace ACS.Core.Interfaces.Handlers
{
    using System.Web;

    public interface IAuthenticationHandler
    {
        void Process(HttpRequestBase request);
    }
}