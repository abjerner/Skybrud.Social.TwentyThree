using Skybrud.Social.TwentyThree.Options;
using Skybrud.Social.TwentyThree.Options.Tags;
using Skybrud.Social.TwentyThree.Responses.Tags;

namespace Skybrud.Social.TwentyThree.Endpoints {

    /// <summary>
    /// Class representing the implementation of the <strong>Tags</strong> endpoint.
    /// </summary>
    public class TwentyThreeTagsEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the TwentyThree service.
        /// </summary>
        public TwentyThreeHttpService Service { get; }

        /// <summary>
        /// Gets a reference to the raw <strong>Tags</strong> endpoint.
        /// </summary>
        public TwentyThreeTagsRawEndpoint Raw => Service.Client.Tags;

        #endregion

        #region Constructors

        internal TwentyThreeTagsEndpoint(TwentyThreeHttpService service) {
            Service = service;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Returns a list of tags.
        /// </summary>
        /// <returns>An instance of <see cref="TwentyThreeTagListResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://www.twentythree.com/api/tag-list</cref>
        /// </see>
        public TwentyThreeTagListResponse GetList() {
            return new TwentyThreeTagListResponse(Raw.GetList());
        }

        /// <summary>
        /// Returns a list of tags.
        /// </summary>
        /// <param name="page">The page to be returned.</param>
        /// <param name="size">The maximum amount of tags to be returned on each page.</param>
        /// <returns>An instance of <see cref="TwentyThreeTagListResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://www.twentythree.com/api/tag-list</cref>
        /// </see>
        public TwentyThreeTagListResponse GetList(int? page, int size) {
            return new TwentyThreeTagListResponse(Raw.GetList(page, size));
        }

        /// <summary>
        /// Returns a list of tags.
        /// </summary>
        /// <param name="page">The page to be returned.</param>
        /// <param name="size">The maximum amount of tags to be returned on each page.</param>
        /// <param name="orderBy">The field by which the tags should be sorted.</param>
        /// <param name="order">The order in which the tags should be sorted.</param>
        /// <returns>An instance of <see cref="TwentyThreeTagListResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://www.twentythree.com/api/tag-list</cref>
        /// </see>
        public TwentyThreeTagListResponse GetList(int? page, int size, TwentyThreeTagSortField? orderBy, TwentyThreeSortOrder? order) {
            return new TwentyThreeTagListResponse(Raw.GetList(page, size, orderBy, order));
        }

        /// <summary>
        /// Returns a list of tags.
        /// </summary>
        /// <param name="orderBy">The field by which the tags should be sorted.</param>
        /// <param name="order">The order in which the tags should be sorted.</param>
        /// <returns>An instance of <see cref="TwentyThreeTagListResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://www.twentythree.com/api/tag-list</cref>
        /// </see>
        public TwentyThreeTagListResponse GetList(TwentyThreeTagSortField? orderBy, TwentyThreeSortOrder? order) {
            return new TwentyThreeTagListResponse(Raw.GetList(orderBy, order));
        }

        /// <summary>
        /// Returns a list of tags.
        /// </summary>
        /// <returns>An instance of <see cref="TwentyThreeTagListResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://www.twentythree.com/api/tag-list</cref>
        /// </see>
        public TwentyThreeTagListResponse GetList(TwentyThreeGetTagsOptions options) {
            return new TwentyThreeTagListResponse(Raw.GetList(options));
        }

        #endregion

    }

}