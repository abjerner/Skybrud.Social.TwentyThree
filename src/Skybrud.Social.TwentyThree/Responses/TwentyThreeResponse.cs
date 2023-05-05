using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Http;
using Skybrud.Essentials.Json.Newtonsoft;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Social.TwentyThree.Exceptions;
using Skybrud.Social.TwentyThree.Models;

namespace Skybrud.Social.TwentyThree.Responses {

    /// <summary>
    /// Class representing a response from the TwentyThree API.
    /// </summary>
    public class TwentyThreeResponse : HttpResponseBase {

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The instance of <see cref="IHttpResponse"/> representing the raw response.</param>
        protected TwentyThreeResponse(IHttpResponse response) : base(response) { }

        #endregion

        #region Static methods

        /// <summary>
        /// Validates the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The response to be validated.</param>
        /// <param name="body">An instacne of <see cref="JObject"/> representing the response body.</param>
        public static void ValidateResponse(IHttpResponse response, out JObject body) {

            // The API always returns a 200 status code - even for errors

            // Parse the response body
            body = JsonUtils.ParseJsonObject(response.Body);

            if (body.GetString("status") == "ok") return;

            // Throw the exception
            throw new TwentyThreeHttpException(response, TwentyThreeError.Parse(body));

        }

        #endregion

    }

    /// <summary>
    /// Class representing a response from the TwentyThree API.
    /// </summary>
    public class TwentyThreeResponse<T> : TwentyThreeResponse {

        #region Properties

        /// <summary>
        /// Gets the body of the response.
        /// </summary>
        public T Body { get; protected set; } = default!;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The instance of <see cref="IHttpResponse"/> representing the raw response.</param>
        protected TwentyThreeResponse(IHttpResponse response) : base(response) { }

        #endregion

    }

}