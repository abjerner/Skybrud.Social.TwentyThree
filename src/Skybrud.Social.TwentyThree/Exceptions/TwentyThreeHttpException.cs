using System.Net;
using Skybrud.Essentials.Http;
using Skybrud.Essentials.Http.Exceptions;
using Skybrud.Social.TwentyThree.Models;

namespace Skybrud.Social.TwentyThree.Exceptions {

    /// <summary>
    /// Class representing an exception based on an error from the TwentyThree API.
    /// </summary>
    public class TwentyThreeHttpException : TwentyThreeException, IHttpException {

        #region Properties

        /// <summary>
        /// Gets a reference to the underlying <see cref="IHttpResponse"/>.
        /// </summary>
        public IHttpResponse Response { get; }

        /// <summary>
        /// Gets the HTTP status code returned by the Twenty Three API.
        /// </summary>
        public HttpStatusCode StatusCode => Response.StatusCode;

        /// <summary>
        /// Gets the <see cref="TwentyThreeError"/> of the exception, if any.
        /// </summary>
        public TwentyThreeError Error { get; }

        /// <summary>
        /// Gets whether the exception has a <see cref="TwentyThreeError"/>.
        /// </summary>
        public bool HasError => Error != null;

        #endregion

        #region Constructors
        
        /// <summary>
        /// Initializes a new exception based on the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The response received from the TwentyThree API.</param>
        public TwentyThreeHttpException(IHttpResponse response) : base($"Invalid response received from the TwentyThree API (status: {(int)response.StatusCode})") {
            Response = response;
        }

        /// <summary>
        /// Initializes a new exception based on the specified <paramref name="response"/> and <paramref name="error"/>.
        /// </summary>
        /// <param name="response">The response received from the TwentyThree API.</param>
        /// <param name="error">The error message.</param>
        public TwentyThreeHttpException(IHttpResponse response, TwentyThreeError error) : base($"Invalid response received from the TwentyThree API (status: {((int)response.StatusCode)})") {
            Response = response;
            Error = error;
        }


        #endregion

    }

}