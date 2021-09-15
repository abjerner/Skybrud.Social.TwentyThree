using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Http;
using Skybrud.Social.TwentyThree.Models.OEmbed;

namespace Skybrud.Social.TwentyThree.Responses.OEmbed {

    /// <summary>
    /// Class representing an OEmbed response received from the Twenty Three API.
    /// </summary>
    public class TwentyThreeOEmbedResponse : TwentyThreeResponse<TwentyThreeOEmbed> {

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The instance of <see cref="IHttpResponse"/> representing the raw response.</param>
        public TwentyThreeOEmbedResponse(IHttpResponse response) : base(response) {
            
            // Validate the response
            ValidateResponse(response, out JObject body);

            // Parse the response body
            Body = TwentyThreeOEmbed.Parse(body);

        }

    }

}