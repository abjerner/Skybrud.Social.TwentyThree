using System;
using Skybrud.Essentials.Http;
using Skybrud.Social.TwentyThree.OAuth;
using Skybrud.Social.TwentyThree.Options.Spots;

namespace Skybrud.Social.TwentyThree.Endpoints {

    /// <summary>
    /// Class representing the raw implementation of the <strong>Spots</strong> endpoint.
    /// </summary>
    public class TwentyThreeSpotsRawEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the OAuth 1.0a client.
        /// </summary>
        public TwentyThreeOAuthClient Client { get; }

        #endregion

        #region Constructors

        internal TwentyThreeSpotsRawEndpoint(TwentyThreeOAuthClient client) {
            Client = client;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Returns a list of spots.
        /// </summary>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://www.twentythree.com/api/spot-list</cref>
        /// </see>
        public IHttpResponse GetList() {
            return GetList(new TwentyThreeGetSpotsOptions());
        }

        /// <summary>
        /// Returns a list of spots.
        /// </summary>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://www.twentythree.com/api/spot-list</cref>
        /// </see>
        public IHttpResponse GetList(TwentyThreeGetSpotsOptions options) {
            if (options == null) throw new ArgumentNullException(nameof(options));
            return Client.GetResponse(options);
        }

        #endregion

    }

}