using System;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Http;
using Skybrud.Social.TwentyThree.Models.Photos;

namespace Skybrud.Social.TwentyThree.Responses.Photos {

    /// <summary>
    /// Class representing the response of a request to the Twenty Three API for getting information a list of photos/videos.
    /// </summary>
    public class TwentyThreeGetPhotosResponse : TwentyThreeResponse<TwentyThreePhotoList> {

        #region Constructors

        private TwentyThreeGetPhotosResponse(IHttpResponse response) : base(response) {
            
            // Validate the response
            ValidateResponse(response, out JObject body);

            // Parse the response body
            Body = TwentyThreePhotoList.Parse(body);

        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="response"/> into an instance of <see cref="TwentyThreeGetPhotosResponse"/>.
        /// </summary>
        /// <param name="response">The response to be parsed.</param>
        /// <returns>An instance of <see cref="TwentyThreeGetPhotosResponse"/> representing the response.</returns>
        public static TwentyThreeGetPhotosResponse ParseResponse(IHttpResponse response) {
            if (response == null) throw new ArgumentNullException(nameof(response));
            return new TwentyThreeGetPhotosResponse(response);
        }

        #endregion

    }

}