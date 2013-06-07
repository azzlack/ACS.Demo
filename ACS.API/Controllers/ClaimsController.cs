namespace ACS.API.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using System.Web.Http;

    using ACS.Core.Models.Claims;

    [Authorize]
    public class ClaimsController : ApiController
    {
        // GET api/claims
        public IEnumerable<SerializableClaim> Get()
        {
            return ClaimsPrincipal.Current.Claims.Select(x => new SerializableClaim(x));
        }
    }
}