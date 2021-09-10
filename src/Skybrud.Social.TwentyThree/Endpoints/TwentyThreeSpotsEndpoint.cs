using Skybrud.Social.TwentyThree.Options.Spots;
using Skybrud.Social.TwentyThree.Responses.Spots;

namespace Skybrud.Social.TwentyThree.Endpoints {

    /// <summary>
    /// Class representing the implementation of the <strong>Spots</strong> endpoint.
    /// </summary>
    public class TwentyThreeSpotsEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the Twenty Three service.
        /// </summary>
        public TwentyThreeService Service { get; }

        /// <summary>
        /// Gets a reference to the raw <strong>Spots</strong> endpoint.
        /// </summary>
        public TwentyThreeSpotsRawEndpoint Raw => Service.Client.Spots;

        #endregion

        #region Constructors

        internal TwentyThreeSpotsEndpoint(TwentyThreeService service) {
            Service = service;
        }

        #endregion

        #region Member methods
        
        /// <summary>
        /// Returns a list of spots.
        /// </summary>
        /// <returns>An instance of <see cref="TwentyThreeSpotListResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://www.twentythree.com/api/spot-list</cref>
        /// </see>
        public TwentyThreeSpotListResponse GetList() {
            return new TwentyThreeSpotListResponse(Raw.GetList());
        }

        /// <summary>
        /// Returns a list of spots.
        /// </summary>
        /// <returns>An instance of <see cref="TwentyThreeSpotListResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://www.twentythree.com/api/spot-list</cref>
        /// </see>
        public TwentyThreeSpotListResponse GetList(TwentyThreeGetSpotsOptions options) {
            return new TwentyThreeSpotListResponse(Raw.GetList(options));
        }

        #endregion

    }

}