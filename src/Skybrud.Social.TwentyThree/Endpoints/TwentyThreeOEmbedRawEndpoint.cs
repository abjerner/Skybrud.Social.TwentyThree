using System;
using Skybrud.Essentials.Common;
using Skybrud.Essentials.Http;
using Skybrud.Social.TwentyThree.OAuth;
using Skybrud.Social.TwentyThree.Options.OEmbed;

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
    public class TwentyThreeOEmbedRawEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the OAuth 1.0a client.
        /// </summary>
        public TwentyThreeOAuthClient Client { get; }

        #endregion

        #region Constructors

        internal TwentyThreeOEmbedRawEndpoint(TwentyThreeOAuthClient client) {
            Client = client;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Returns OEmbed information for the video with the specified <paramref name="videoId"/>..
        /// </summary>
        /// <param name="videoId">The ID of the video.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://www.twentythree.com/help/manage-oembed</cref>
        /// </see>
        public IHttpResponse GetOEmbedFromId(string videoId) {
            
            if (string.IsNullOrWhiteSpace(videoId)) throw new ArgumentNullException(nameof(videoId));
            if (string.IsNullOrWhiteSpace(Client.HostName)) throw new PropertyNotSetException(nameof(Client.HostName));

            string url = $"https://{Client.HostName}/manage/video/{videoId}";
            
            return GetOEmbed(new TwentyThreeOEmbedOptions(url));

        }

        /// <summary>
        /// Returns OEmbed information for the video with the specified <paramref name="url"/>..
        /// </summary>
        /// <param name="url">The URL of the video.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://www.twentythree.com/help/manage-oembed</cref>
        /// </see>
        public IHttpResponse GetOEmbedFromUrl(string url) {
            if (string.IsNullOrWhiteSpace(url)) throw new ArgumentNullException(nameof(url));
            return GetOEmbed(new TwentyThreeOEmbedOptions(url));
        }
        
        /// <summary>
        /// Returns OEmbed for the video with matching specified <paramref name="options"/>..
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://www.twentythree.com/help/manage-oembed</cref>
        /// </see>
        public IHttpResponse GetOEmbed(TwentyThreeOEmbedOptions options) {
            if (options == null) throw new ArgumentNullException(nameof(options));
            return Client.GetResponse(options);
        }

        #endregion

    }

}