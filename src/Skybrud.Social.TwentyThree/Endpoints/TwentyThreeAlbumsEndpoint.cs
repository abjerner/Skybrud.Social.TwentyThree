using Skybrud.Social.TwentyThree.Options.Albums;
using Skybrud.Social.TwentyThree.Responses.Albums;

namespace Skybrud.Social.TwentyThree.Endpoints {

    /// <summary>
    /// Class representing the implementation of the <strong>Albums</strong> endpoint.
    /// </summary>
    public class TwentyThreeAlbumsEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the Twenty Three service.
        /// </summary>
        public TwentyThreeHttpService Service { get; }

        /// <summary>
        /// Gets a reference to the raw <strong>Albums</strong> endpoint.
        /// </summary>
        public TwentyThreeAlbumsRawEndpoint Raw => Service.Client.Albums;

        #endregion

        #region Constructors

        internal TwentyThreeAlbumsEndpoint(TwentyThreeHttpService service) {
            Service = service;
        }

        #endregion

        #region Member methods
        
        /// <summary>
        /// Returns a list of albums.
        /// </summary>
        /// <returns>An instance of <see cref="TwentyThreeAlbumListResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://www.twentythree.com/api/album-list</cref>
        /// </see>
        public TwentyThreeAlbumListResponse GetList() {
            return new TwentyThreeAlbumListResponse(Raw.GetList());
        }

        /// <summary>
        /// Returns a list of albums.
        /// </summary>
        /// <returns>An instance of <see cref="TwentyThreeAlbumListResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://www.twentythree.com/api/album-list</cref>
        /// </see>
        public TwentyThreeAlbumListResponse GetList(TwentyThreeGetAlbumsOptions options) {
            return new TwentyThreeAlbumListResponse(Raw.GetList(options));
        }

        #endregion

    }

}