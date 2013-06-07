namespace ACS.Core.Models.Claims
{
    using System.Security.Claims;

    public class SerializableClaim
    {
        public string Type { get; set; }

        public string Value { get; set; }

        public SerializableClaim()
        {
        }

        public SerializableClaim(Claim claim)
        {
            this.Type = claim.Type;
            this.Value = claim.Value;
        }
    }
}