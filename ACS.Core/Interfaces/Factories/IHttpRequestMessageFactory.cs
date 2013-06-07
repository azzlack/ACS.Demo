namespace ACS.Core.Interfaces.Factories
{
    using System.Net.Http;
    using System.Web;

    public interface IHttpRequestMessageFactory
    {
        HttpRequestMessage Create(HttpRequestBase request);
    }
}