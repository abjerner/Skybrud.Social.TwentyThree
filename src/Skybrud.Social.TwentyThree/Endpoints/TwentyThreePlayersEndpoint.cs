using Skybrud.Social.TwentyThree.Options.Players;
using Skybrud.Social.TwentyThree.Responses.Players;

namespace Skybrud.Social.TwentyThree.Endpoints {

    /// <summary>
    /// Class representing the implementation of the <strong>Players</strong> endpoint.
    /// </summary>
    public class TwentyThreePlayersEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the TwentyThree service.
        /// </summary>
        public TwentyThreeHttpService Service { get; }

        /// <summary>
        /// Gets a reference to the raw <strong>Players</strong> endpoint.
        /// </summary>
        public TwentyThreePlayersRawEndpoint Raw => Service.Client.Players;

        #endregion

        #region Constructors

        internal TwentyThreePlayersEndpoint(TwentyThreeHttpService service) {
            Service = service;
        }

        #endregion

        #region Member methods
        
        /// <summary>
        /// Returns a list of players.
        /// </summary>
        /// <returns>An instance of <see cref="TwentyThreePlayerListResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://www.twentythree.com/api/player-list</cref>
        /// </see>
        public TwentyThreePlayerListResponse GetList() {
            return new TwentyThreePlayerListResponse(Raw.GetList());
        }

        /// <summary>
        /// Returns a list of players.
        /// </summary>
        /// <returns>An instance of <see cref="TwentyThreePlayerListResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://www.twentythree.com/api/player-list</cref>
        /// </see>
        public TwentyThreePlayerListResponse GetList(TwentyThreeGetPlayersOptions options) {
            return new TwentyThreePlayerListResponse(Raw.GetList(options));
        }

        #endregion

    }

}