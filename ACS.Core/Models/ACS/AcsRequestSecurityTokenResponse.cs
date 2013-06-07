namespace ACS.Core.Models.ACS
{
    using System;
    using System.Collections.Generic;

    public class AcsRequestSecurityTokenResponse
    {
        /// <summary>
        /// Gets or sets the token creation date.
        /// </summary>
        /// <value>The token creation date.</value>
        public DateTime Created { get; set; }

        /// <summary>
        /// Gets or sets the token expiry date.
        /// </summary>
        /// <value>The token expiry date.</value>
        public DateTime Expires { get; set; }

        /// <summary>
        /// Gets or sets the realms the token applies to.
        /// </summary>
        /// <value>The realms the token applies to.</value>
        public IEnumerable<string> AppliesTo { get; set; }

        /// <summary>
        /// Gets or sets the security token in binary format.
        /// </summary>
        /// <value>The security token in binary format.</value>
        public byte[] BinarySecurityToken { get; set; }

        /// <summary>
        /// Gets or sets the security token.
        /// </summary>
        /// <value>The security token.</value>
        public string SecurityToken { get; set; }

        /// <summary>
        /// Gets or sets the token type.
        /// </summary>
        /// <value>The token type.</value>
        public string TokenType { get; set; }

        /// <summary>
        /// Gets or sets the request type.
        /// </summary>
        /// <value>The request type.</value>
        public string RequestType { get; set; }

        /// <summary>
        /// Gets or sets the key type.
        /// </summary>
        /// <value>The key type.</value>
        public string KeyType { get; set; } 
    }
}