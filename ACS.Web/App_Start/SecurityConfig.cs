namespace ACS.Web
{
    using System.Web.Mvc;

    using ACS.BusinessLogic.Factories;
    using ACS.BusinessLogic.Handlers;

    using Thinktecture.IdentityModel.Tokens.Http;

    using AuthenticationHandler = ACS.BusinessLogic.Handlers.AuthenticationHandler;

    public class SecurityConfig
    {
        public static void ConfigureOAuth()
        {
            // Create ACS OAuth filter
            var authenticationConfiguration = new AuthenticationConfiguration
            {
                RequireSsl = false,
                ClaimsAuthenticationManager = new ClaimsTransformer()
            };

            authenticationConfiguration.AddJsonWebToken(
                issuer: "https://eyecatch.accesscontrol.windows.net/",
                audience: "http://localhost:61390/",
                signingKey: "vZhjuby4hTmoaKnptAXe1MPAMiI+63obW20+fVaFAYM=",
                scheme: "ACS");

            ControllerBuilder.Current.SetControllerFactory(
                new AcsControllerFactory(
                    new CookieToAuthenticationHeaderHandler("ACS"),
                    new AuthenticationHandler(authenticationConfiguration, new HttpRequestMessageFactory())));
        }
    }
}