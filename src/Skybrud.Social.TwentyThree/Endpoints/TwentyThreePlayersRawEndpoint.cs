using System;
using Skybrud.Essentials.Http;
using Skybrud.Social.TwentyThree.OAuth;
using Skybrud.Social.TwentyThree.Options.Players;

namespace Skybrud.Social.TwentyThree.Endpoints {

    /// <summary>
    /// Class representing the raw implementation of the <strong>Players</strong> endpoint.
    /// </summary>
    public class TwentyThreePlayersRawEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the OAuth 1.0a client.
        /// </summary>
        public TwentyThreeOAuthClient Client { get; }

        #endregion

        #region Constructors

        internal TwentyThreePlayersRawEndpoint(TwentyThreeOAuthClient client) {
            Client = client;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Returns a list of players.
        /// </summary>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://www.twentythree.com/api/player-list</cref>
        /// </see>
        public IHttpResponse GetList() {
            return GetList(new TwentyThreeGetPlayersOptions());
        }

        /// <summary>
        /// Returns a list of players.
        /// </summary>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://www.twentythree.com/api/player-list</cref>
        /// </see>
        public IHttpResponse GetList(TwentyThreeGetPlayersOptions options) {
            if (options == null) throw new ArgumentNullException(nameof(options));
            return Client.GetResponse(options);
        }

        #endregion

    }

}