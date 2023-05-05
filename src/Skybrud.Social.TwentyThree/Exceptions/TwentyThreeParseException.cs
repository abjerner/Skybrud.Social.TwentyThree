using System;

namespace Skybrud.Social.TwentyThree.Exceptions {

    /// <summary>
    /// Class representing an exception for when parsing something failed.
    /// </summary>
    /// <see cref="TwentyThreeJsonParseException"/>
    public class TwentyThreeParseException : TwentyThreeException {

        /// <summary>
        /// Initializes a new instance with the specified <paramref name="message"/> and <paramref name="innerException"/>.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="innerException">The inner exception, if any.</param>
        public TwentyThreeParseException(string message, Exception? innerException) : base(message, innerException) { }

    }

}