using Skybrud.Social.TwentyThree.Options.OEmbed;
using Skybrud.Social.TwentyThree.Responses.OEmbed;

namespace Skybrud.Social.TwentyThree.Endpoints {

    /// <summary>
    /// Class representing the implementation of the <strong>OEmbed</strong> endpoint.
    /// </summary>
    /// <see>
    ///     <cref>https://www.twentythree.com/help/manage-oembed</cref>
    /// </see>
    /// <see>
    ///     <cref>https://oembed.com/</cref>
    /// </see>
    public class TwentyThreeOEmbedEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the Twenty Three service.
        /// </summary>
        public TwentyThreeHttpService Service { get; }

        /// <summary>
        /// Gets a reference to the raw <strong>OEmbed</strong> endpoint.
        /// </summary>
        public TwentyThreeOEmbedRawEndpoint Raw => Service.Client.OEmbed;

        #endregion

        #region Constructors

        internal TwentyThreeOEmbedEndpoint(TwentyThreeHttpService service) {
            Service = service;
        }

        #endregion

        #region Member methods
        
        /// <summary>
        /// Returns OEmbed information for the video with the specified <paramref name="videoId"/>..
        /// </summary>
        /// <param name="videoId">The ID of the video.</param>
        /// <returns>An instance of <see cref="TwentyThreeOEmbedResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://www.twentythree.com/help/manage-oembed</cref>
        /// </see>
        public TwentyThreeOEmbedResponse GetOEmbedFromId(string videoId) {
            return new TwentyThreeOEmbedResponse(Raw.GetOEmbedFromId(videoId));
        }

        /// <summary>
        /// Returns OEmbed information for the video with the specified <paramref name="url"/>..
        /// </summary>
        /// <param name="url">The URL of the video.</param>
        /// <returns>An instance of <see cref="TwentyThreeOEmbedResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://www.twentythree.com/help/manage-oembed</cref>
        /// </see>
        public TwentyThreeOEmbedResponse GetOEmbedFromUrl(string url) {
            return new TwentyThreeOEmbedResponse(Raw.GetOEmbedFromUrl(url));
        }
        
        /// <summary>
        /// Returns OEmbed for the video with matching specified <paramref name="options"/>..
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="TwentyThreeOEmbedResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://www.twentythree.com/help/manage-oembed</cref>
        /// </see>
        public TwentyThreeOEmbedResponse GetOEmbed(TwentyThreeOEmbedOptions options) {
            return new TwentyThreeOEmbedResponse(Raw.GetOEmbed(options));
        }

        #endregion

    }

}