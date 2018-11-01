using System;
using System.Net;
using Skybrud.Social.Http;
using Skybrud.Social.TwentyThree.Models;

namespace Skybrud.Social.TwentyThree.Exceptions {
    
    public class TwentyThreeHttpException : Exception {

        #region Properties

        /// <summary>
        /// Gets a reference to the underlying <see cref="SocialHttpResponse"/>.
        /// </summary>
        public SocialHttpResponse Response { get; }

        /// <summary>
        /// Gets the HTTP status code returned by the Twenty Three API.
        /// </summary>
        public HttpStatusCode StatusCode { get; }

        public TwentyThreeError Error { get; }

        public bool HasError => Error != null;

        #endregion

        #region Constructors

        public TwentyThreeHttpException(SocialHttpResponse response, TwentyThreeError error) : base("Invalid response received from the Twenty Three API (Status: " + ((int) response.StatusCode) + ")") {
            Response = response;
            StatusCode = response.StatusCode;
            Error = error;
        }

        #endregion

    }

}