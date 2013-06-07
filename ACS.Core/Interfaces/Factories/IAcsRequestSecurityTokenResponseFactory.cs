namespace ACS.Core.Interfaces.Factories
{
    using ACS.Core.Models.ACS;

    public interface IAcsRequestSecurityTokenResponseFactory
    {
        /// <summary>
        /// Creates an <see cref="AcsRequestSecurityTokenResponse" /> from the specified xml.
        /// </summary>
        /// <param name="xml">The XML.</param>
        /// <returns>An ACS RequestSecurityTokenResponse.</returns>
        AcsRequestSecurityTokenResponse Create(string xml);
    }
}