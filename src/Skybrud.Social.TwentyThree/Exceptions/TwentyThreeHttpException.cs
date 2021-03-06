﻿using System;
using System.Net;
using Skybrud.Essentials.Http;
using Skybrud.Essentials.Http.Exceptions;
using Skybrud.Social.TwentyThree.Models;

namespace Skybrud.Social.TwentyThree.Exceptions {
    
    public class TwentyThreeHttpException : Exception, IHttpException {

        #region Properties

        /// <summary>
        /// Gets a reference to the underlying <see cref="IHttpResponse"/>.
        /// </summary>
        public IHttpResponse Response { get; }

        /// <summary>
        /// Gets the HTTP status code returned by the Twenty Three API.
        /// </summary>
        public HttpStatusCode StatusCode { get; }

        public TwentyThreeError Error { get; }

        public bool HasError => Error != null;

        #endregion

        #region Constructors

        public TwentyThreeHttpException(IHttpResponse response, TwentyThreeError error) : base("Invalid response received from the Twenty Three API (Status: " + ((int) response.StatusCode) + ")") {
            Response = response;
            StatusCode = response.StatusCode;
            Error = error;
        }

        #endregion

    }

}