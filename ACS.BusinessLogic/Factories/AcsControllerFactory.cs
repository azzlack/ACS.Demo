namespace ACS.BusinessLogic.Factories
{
    using System;
    using System.Web.Mvc;
    using System.Web.Routing;

    using ACS.BusinessLogic.Handlers;
    using ACS.Core.Interfaces.Handlers;

    public class AcsControllerFactory : DefaultControllerFactory
    {
        /// <summary>
        /// The action invoker
        /// </summary>
        private readonly AcsControllerActionInvoker actionInvoker;

        public AcsControllerFactory(ICookieToAuthenticationHeaderHandler cookieToAuthorizationHeaderHandler, IAuthenticationHandler authenticationHandler)
        {
            this.actionInvoker = new AcsControllerActionInvoker(cookieToAuthorizationHeaderHandler, authenticationHandler);
        }

        /// <summary>
        /// Retrieves the controller instance for the specified request context and controller type.
        /// </summary>
        /// <param name="requestContext">The context of the HTTP request, which includes the HTTP context and route data.</param>
        /// <param name="controllerType">The type of the controller.</param>
        /// <returns>The controller instance.</returns>
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            var controllerInstance = base.GetControllerInstance(requestContext, controllerType);

            if (controllerInstance != null)
            {
                var typedController = controllerInstance as Controller;

                if (typedController != null)
                {
                    typedController.ActionInvoker = this.actionInvoker;
                }
            }

            return controllerInstance;
        }
    }
}