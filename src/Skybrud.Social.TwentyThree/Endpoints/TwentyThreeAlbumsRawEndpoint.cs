using System;
using Skybrud.Essentials.Http;
using Skybrud.Social.TwentyThree.OAuth;
using Skybrud.Social.TwentyThree.Options.Albums;

namespace Skybrud.Social.TwentyThree.Endpoints {

    /// <summary>
    /// Class representing the raw implementation of the <strong>Albums</strong> endpoint.
    /// </summary>
    public class TwentyThreeAlbumsRawEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the OAuth 1.0a client.
        /// </summary>
        public TwentyThreeOAuthClient Client { get; }

        #endregion

        #region Constructors

        internal TwentyThreeAlbumsRawEndpoint(TwentyThreeOAuthClient client) {
            Client = client;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Returns a list of albums.
        /// </summary>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://www.twentythree.com/api/album-list</cref>
        /// </see>
        public IHttpResponse GetList() {
            return GetList(new TwentyThreeGetAlbumsOptions());
        }

        /// <summary>
        /// Returns a list of albums.
        /// </summary>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://www.twentythree.com/api/album-list</cref>
        /// </see>
        public IHttpResponse GetList(TwentyThreeGetAlbumsOptions options) {
            if (options == null) throw new ArgumentNullException(nameof(options));
            return Client.GetResponse(options);
        }

        #endregion

    }

}