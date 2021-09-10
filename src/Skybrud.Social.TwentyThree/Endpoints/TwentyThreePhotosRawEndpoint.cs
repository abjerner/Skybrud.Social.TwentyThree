using System;
using Skybrud.Essentials.Http;
using Skybrud.Social.TwentyThree.OAuth;
using Skybrud.Social.TwentyThree.Options.Photos;

namespace Skybrud.Social.TwentyThree.Endpoints {

    /// <summary>
    /// Class representing the raw implementation of the <strong>Photos</strong> endpoint.
    /// </summary>
    public class TwentyThreePhotosRawEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the OAuth 1.0a client.
        /// </summary>
        public TwentyThreeOAuthClient Client { get; }

        #endregion

        #region Constructors

        internal TwentyThreePhotosRawEndpoint(TwentyThreeOAuthClient client) {
            Client = client;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Returns a list of photos or videos.
        /// </summary>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://www.twentythree.net/api/photo-list</cref>
        /// </see>
        public IHttpResponse GetList() {
            return GetList(new TwentyThreeGetPhotosOptions());
        }

        /// <summary>
        /// Returns a list of photos or videos.
        /// </summary>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://www.twentythree.net/api/photo-list</cref>
        /// </see>
        public IHttpResponse GetList(TwentyThreeGetPhotosOptions options) {
            if (options == null) throw new ArgumentNullException(nameof(options));
            return Client.GetResponse(options);
        }

        #endregion

    }

}