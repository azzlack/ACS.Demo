namespace ACS.API
{
    using System.Web.Http;

    using ACS.BusinessLogic.Handlers;

    using Thinktecture.IdentityModel.Http.Cors;
    using Thinktecture.IdentityModel.Http.Cors.WebApi;
    using Thinktecture.IdentityModel.Tokens.Http;

    using AuthenticationHandler = Thinktecture.IdentityModel.Tokens.Http.AuthenticationHandler;

    public class SecurityConfig
    {
        public static void ConfigureOAuth(HttpConfiguration config)
        {
            // Set up CORS configuration
            var corsConfig = new CorsConfiguration();
            corsConfig.AllowAll();

            var corsHandler = new CorsMessageHandler(corsConfig, config);

            config.MessageHandlers.Add(corsHandler);

            // Set up ACS token configuration
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

            config.MessageHandlers.Add(new AuthenticationHandler(authenticationConfiguration));
        } 
    }
}