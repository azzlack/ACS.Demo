namespace ACS.BusinessLogic.Handlers
{
    using System.Linq;
    using System.Security.Claims;

    public class ClaimsTransformer : ClaimsAuthenticationManager
    {
        public override ClaimsPrincipal Authenticate(string resourceName, ClaimsPrincipal incomingPrincipal)
        {
            if (!incomingPrincipal.Identity.IsAuthenticated)
            {
                return base.Authenticate(resourceName, incomingPrincipal);
            }

            // Set name identifier claim if it doesn't exist
            if (!incomingPrincipal.HasClaim(x => x.Type == ClaimTypes.NameIdentifier))
            {
                if (incomingPrincipal.HasClaim(x => x.Type == ClaimTypes.Email))
                {
                    incomingPrincipal.Identities.First().AddClaim(new Claim(ClaimTypes.NameIdentifier, incomingPrincipal.Claims.First(x => x.Type == ClaimTypes.Email).Value));
                }
                else if (incomingPrincipal.HasClaim(x => x.Type == "nameid"))
                {
                    incomingPrincipal.Identities.First().AddClaim(new Claim(ClaimTypes.NameIdentifier, incomingPrincipal.Claims.First(x => x.Type == "nameid").Value));
                } 
            }

            // Set identity provider claim if it doesn't exist
            if (!incomingPrincipal.HasClaim(x => x.Type == "http://schemas.microsoft.com/accesscontrolservice/2010/07/claims/identityprovider"))
            {
                if (incomingPrincipal.HasClaim(x => x.Type == "identityprovider"))
                {
                    incomingPrincipal.Identities.First().AddClaim(new Claim("http://schemas.microsoft.com/accesscontrolservice/2010/07/claims/identityprovider", incomingPrincipal.Claims.First(x => x.Type == "identityprovider").Value));
                }   
            }

            // Set name claim if it doesn't exist
            if (!incomingPrincipal.HasClaim(x => x.Type == ClaimTypes.Name))
            {
                if (incomingPrincipal.HasClaim(x => x.Type == ClaimTypes.Email))
                {
                    incomingPrincipal.Identities.First().AddClaim(new Claim(ClaimTypes.Name, incomingPrincipal.Claims.First(x => x.Type == ClaimTypes.Email).Value));
                }
                else if (incomingPrincipal.HasClaim(x => x.Type == "nameid"))
                {
                    incomingPrincipal.Identities.First().AddClaim(new Claim(ClaimTypes.Name, incomingPrincipal.Claims.First(x => x.Type == "nameid").Value));
                }
            }

            return incomingPrincipal;
        }
    }
}