using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Http;
using Skybrud.Social.TwentyThree.Models.Albums;

namespace Skybrud.Social.TwentyThree.Responses.Albums {

    /// <summary>
    /// Class representing the response of a request to the TwentyThree API for getting information a list of albums.
    /// </summary>
    public class TwentyThreeAlbumListResponse : TwentyThreeResponse<TwentyThreeAlbumList> {

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The instance of <see cref="IHttpResponse"/> representing the raw response.</param>
        public TwentyThreeAlbumListResponse(IHttpResponse response) : base(response) {
            
            // Validate the response
            ValidateResponse(response, out JObject body);

            // Parse the response body
            Body = TwentyThreeAlbumList.Parse(body);

        }

    }

}