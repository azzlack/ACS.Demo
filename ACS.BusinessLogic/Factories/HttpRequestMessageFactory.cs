namespace ACS.BusinessLogic.Factories
{
    using System.Net.Http;
    using System.Web;

    using ACS.BusinessLogic.Extensions;
    using ACS.Core.Interfaces.Factories;

    public class HttpRequestMessageFactory : IHttpRequestMessageFactory
    {
        public HttpRequestMessage Create(HttpRequestBase request)
        {
            var message = new HttpRequestMessage(new HttpMethod(request.HttpMethod), request.Url);

            // Set content
            if (request.Form != null)
            {
                // Avoid a request message that will try to read the request stream twice for already parsed data.
                message.Content = new FormUrlEncodedContent(request.Unvalidated.Form.AsKeyValuePairs());
            }
            else if (request.InputStream != null)
            {
                message.Content = new StreamContent(request.InputStream);
            }

            // Set headers
            foreach (string headerName in request.Headers)
            {
                var headerValues = request.Headers.GetValues(headerName);
                if (!message.Headers.TryAddWithoutValidation(headerName, headerValues))
                {
                    message.Content.Headers.TryAddWithoutValidation(headerName, headerValues);
                }
            }

            return message;
        }
    }
}