using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Http;
using Skybrud.Social.TwentyThree.Models.Tags;

namespace Skybrud.Social.TwentyThree.Responses.Tags {

    /// <summary>
    /// Class representing the response of a request to the TwentyThree API for getting information a list of tags.
    /// </summary>
    public class TwentyThreeTagListResponse : TwentyThreeResponse<TwentyThreeTagList> {

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The instance of <see cref="IHttpResponse"/> representing the raw response.</param>
        public TwentyThreeTagListResponse(IHttpResponse response) : base(response) {

            // Validate the response
            ValidateResponse(response, out JObject body);

            // Parse the response body
            Body = TwentyThreeTagList.Parse(body)!;

        }

    }

}