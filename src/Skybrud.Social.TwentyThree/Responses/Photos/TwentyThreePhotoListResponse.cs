using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Http;
using Skybrud.Social.TwentyThree.Models.Photos;

namespace Skybrud.Social.TwentyThree.Responses.Photos {

    /// <summary>
    /// Class representing the response of a request to the Twenty Three API for getting information a list of photos/videos.
    /// </summary>
    public class TwentyThreePhotoListResponse : TwentyThreeResponse<TwentyThreePhotoList> {

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The instance of <see cref="IHttpResponse"/> representing the raw response.</param>
        public TwentyThreePhotoListResponse(IHttpResponse response) : base(response) {
            
            // Validate the response
            ValidateResponse(response, out JObject body);

            // Parse the response body
            Body = TwentyThreePhotoList.Parse(body);

        }

    }

}