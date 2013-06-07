namespace ACS.BusinessLogic.Factories
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Xml;

    using ACS.Core.Interfaces;
    using ACS.Core.Interfaces.Factories;
    using ACS.Core.Models.ACS;

    public class AcsRequestSecurityTokenResponseFactory : IAcsRequestSecurityTokenResponseFactory
    {
        /// <summary>
        /// Creates an <see cref="AcsRequestSecurityTokenResponse" /> from the specified xml.
        /// </summary>
        /// <param name="xml">The XML.</param>
        /// <returns>An ACS RequestSecurityTokenResponse.</returns>
        public AcsRequestSecurityTokenResponse Create(string xml)
        {
            var document = new XmlDocument();
            document.LoadXml(xml);

            var namespaceManager = new XmlNamespaceManager(new NameTable());
            namespaceManager.AddNamespace("t", "http://schemas.xmlsoap.org/ws/2005/02/trust");
            namespaceManager.AddNamespace("wsu", "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd");
            namespaceManager.AddNamespace("wsp", "http://schemas.xmlsoap.org/ws/2004/09/policy");
            namespaceManager.AddNamespace("wsse", "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd");

            var created = document.SelectSingleNode("/t:RequestSecurityTokenResponse/t:Lifetime/wsu:Created", namespaceManager);
            var expires = document.SelectSingleNode("/t:RequestSecurityTokenResponse/t:Lifetime/wsu:Expires", namespaceManager);
            var appliesTo = document.SelectSingleNode("/t:RequestSecurityTokenResponse/wsp:AppliesTo", namespaceManager);
            var binarySecurityToken = document.SelectSingleNode("/t:RequestSecurityTokenResponse/t:RequestedSecurityToken/wsse:BinarySecurityToken", namespaceManager);
            var tokenType = document.SelectSingleNode("/t:RequestSecurityTokenResponse/t:TokenType", namespaceManager);
            var requestType = document.SelectSingleNode("/t:RequestSecurityTokenResponse/t:TokenType", namespaceManager);
            var keyType = document.SelectSingleNode("/t:RequestSecurityTokenResponse/t:TokenType", namespaceManager);

            var result = new AcsRequestSecurityTokenResponse();

            if (created != null)
            {
                result.Created = DateTime.Parse(created.InnerText);
            }

            if (expires != null)
            {
                result.Expires = DateTime.Parse(expires.InnerText);
            }

            if (appliesTo != null)
            {
                var addresses = (from XmlNode endpoint in appliesTo.ChildNodes from XmlNode address in appliesTo.ChildNodes select address.InnerText).ToList();

                result.AppliesTo = addresses;
            }

            if (binarySecurityToken != null)
            {
                result.BinarySecurityToken = Convert.FromBase64String(binarySecurityToken.InnerText);
                result.SecurityToken = Encoding.UTF8.GetString(result.BinarySecurityToken);
            }

            if (tokenType != null)
            {
                result.TokenType = tokenType.InnerText;
            }

            if (requestType != null)
            {
                result.RequestType = requestType.InnerText;
            }

            if (keyType != null)
            {
                result.KeyType = keyType.InnerText;
            }

            return result;
        }
    }
}