using System;

namespace Skybrud.Social.TwentyThree.Exceptions {

    /// <summary>
    /// Class representing an exception related to this package.
    /// </summary>
    public class TwentyThreeException : Exception {

        /// <summary>
        /// Initializes a new exception with the specified <paramref name="message"/>.
        /// </summary>
        /// <param name="message">The message of the exception.</param>
        public TwentyThreeException(string message) : base(message) { }

        /// <summary>
        /// Initializes a new exception with the specified <paramref name="message"/> and <paramref name="innerException"/>.
        /// </summary>
        /// <param name="message">The message of the exception.</param>
        /// <param name="innerException">The inner exception.</param>
        public TwentyThreeException(string message, Exception innerException) : base(message, innerException) { }

    }

}