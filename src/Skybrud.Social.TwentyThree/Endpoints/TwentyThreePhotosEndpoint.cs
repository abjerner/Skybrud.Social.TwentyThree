using Skybrud.Social.TwentyThree.Options.Photos;
using Skybrud.Social.TwentyThree.Responses.Photos;

namespace Skybrud.Social.TwentyThree.Endpoints {

    /// <summary>
    /// Class representing the implementation of the <strong>Photos</strong> endpoint.
    /// </summary>
    public class TwentyThreePhotosEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the Twenty Three service.
        /// </summary>
        public TwentyThreeHttpService Service { get; }

        /// <summary>
        /// Gets a reference to the raw <strong>Photos</strong> endpoint.
        /// </summary>
        public TwentyThreePhotosRawEndpoint Raw => Service.Client.Photos;

        #endregion

        #region Constructors

        internal TwentyThreePhotosEndpoint(TwentyThreeHttpService service) {
            Service = service;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Returns a list of photos or videos.
        /// </summary>
        /// <returns>An instance of <see cref="TwentyThreePhotoListResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://www.twentythree.net/api/photo-list</cref>
        /// </see>
        public TwentyThreePhotoListResponse GetList() {
            return new TwentyThreePhotoListResponse(Raw.GetList());
        }

        /// <summary>
        /// Returns a list of photos or videos.
        /// </summary>
        /// <returns>An instance of <see cref="TwentyThreePhotoListResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://www.twentythree.net/api/photo-list</cref>
        /// </see>
        public TwentyThreePhotoListResponse GetList(TwentyThreeGetPhotosOptions options) {
            return new TwentyThreePhotoListResponse(Raw.GetList(options));
        }

        #endregion

    }

}