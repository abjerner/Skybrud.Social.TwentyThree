using System;
using Newtonsoft.Json.Linq;

namespace Skybrud.Social.TwentyThree.Exceptions {

    /// <summary>
    /// Class representing an exception for when parsing a <see cref="JToken"/> failed.
    /// </summary>
    public class TwentyThreeJsonParseException : TwentyThreeParseException {

        /// <summary>
        /// Gets the <see cref="JToken"/> that triggered the exception.
        /// </summary>
        public JToken Token { get; }

        /// <summary>
        /// Initializes a new instance with the specified <paramref name="message"/>, <paramref name="token"/> and <paramref name="innerException"/>.
        /// </summary>
        /// <param name="message">The exception message.</param>
        /// <param name="token">The <see cref="JToken"/> that triggered the exception.</param>
        /// <param name="innerException">The inner exception, if any.</param>
        public TwentyThreeJsonParseException(string message, JToken token, Exception innerException) : base(message, innerException) {
            Token = token;
        }

    }

}