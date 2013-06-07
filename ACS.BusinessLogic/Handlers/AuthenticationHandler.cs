namespace ACS.BusinessLogic.Handlers
{
    using System;
    using System.Security.Claims;
    using System.Threading;
    using System.Web;

    using ACS.Core.Interfaces.Factories;
    using ACS.Core.Interfaces.Handlers;

    using Thinktecture.IdentityModel.Tokens.Http;

    public class AuthenticationHandler : IAuthenticationHandler
    {
        private readonly HttpAuthentication authenticationHandler;

        private readonly IHttpRequestMessageFactory httpRequestMessageFactory;

        public AuthenticationHandler(AuthenticationConfiguration configuration, IHttpRequestMessageFactory httpRequestMessageFactory)
        {
            this.authenticationHandler = new HttpAuthentication(configuration);
            this.httpRequestMessageFactory = httpRequestMessageFactory;
        }

        public void Process(HttpRequestBase request)
        {
            // Check SSL requirement
            if (this.authenticationHandler.Configuration.RequireSsl && !request.IsSecureConnection)
            {
                // TODO: Throw exception
            }

            // Set default credentials
            this.SetPrincipal(request, ClaimsPrincipal.Current);

            // Start authenticating
            ClaimsPrincipal principal;

            var requestMessage = this.httpRequestMessageFactory.Create(request);

            try
            {
                // try to authenticate
                // returns an anonymous principal if no credential was found
                principal = this.authenticationHandler.Authenticate(requestMessage);

                if (principal == null)
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                return;
            }

            // Credential was found *and* authentication was successful
            if (principal.Identity.IsAuthenticated)
            {
                this.SetPrincipal(request, principal);
            }
        }

        protected virtual void SetPrincipal(HttpRequestBase request, ClaimsPrincipal principal)
        {
            Thread.CurrentPrincipal = principal;

            if (HttpContext.Current != null)
            {
                HttpContext.Current.User = principal;
            }
        }
    }
}