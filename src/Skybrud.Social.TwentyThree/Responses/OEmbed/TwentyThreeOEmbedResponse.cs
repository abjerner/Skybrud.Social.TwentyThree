﻿using System.Net;
using Skybrud.Essentials.Http;
using Skybrud.Essentials.Json.Newtonsoft;
using Skybrud.Social.TwentyThree.Exceptions;
using Skybrud.Social.TwentyThree.Models.OEmbed;

namespace Skybrud.Social.TwentyThree.Responses.OEmbed {

    /// <summary>
    /// Class representing an OEmbed response received from the TwentyThree API.
    /// </summary>
    public class TwentyThreeOEmbedResponse : TwentyThreeResponse<TwentyThreeOEmbed> {

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The instance of <see cref="IHttpResponse"/> representing the raw response.</param>
        public TwentyThreeOEmbedResponse(IHttpResponse response) : base(response) {
            Body = response.StatusCode switch {
                HttpStatusCode.OK => JsonUtils.ParseJsonObject(response.Body, TwentyThreeOEmbed.Parse)!,
                _ => throw new TwentyThreeHttpException(response)
            };
        }

    }

}