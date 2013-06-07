namespace ACS.BusinessLogic.Handlers
{
    using System;
    using System.Web.Mvc;

    using ACS.Core.Interfaces.Handlers;

    public class AcsControllerActionInvoker : ControllerActionInvoker
    {
        private readonly ICookieToAuthenticationHeaderHandler cookieToAuthorizationHeaderHandler;

        private readonly IAuthenticationHandler authenticationHandler;

        public AcsControllerActionInvoker(ICookieToAuthenticationHeaderHandler cookieToAuthorizationHeaderHandler, IAuthenticationHandler authenticationHandler)
        {
            this.cookieToAuthorizationHeaderHandler = cookieToAuthorizationHeaderHandler;
            this.authenticationHandler = authenticationHandler;
        }

        public override bool InvokeAction(ControllerContext controllerContext, string actionName)
        {
            // Convert cookie to authorization header
            this.cookieToAuthorizationHeaderHandler.Process(controllerContext.HttpContext.Request);

            // Authenticate header
            this.authenticationHandler.Process(controllerContext.HttpContext.Request);

            // Invoke default action
            return base.InvokeAction(controllerContext, actionName);
        }
    }
}