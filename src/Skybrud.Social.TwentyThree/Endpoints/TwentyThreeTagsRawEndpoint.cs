using System;
using Skybrud.Essentials.Http;
using Skybrud.Social.TwentyThree.OAuth;
using Skybrud.Social.TwentyThree.Options;
using Skybrud.Social.TwentyThree.Options.Tags;

namespace Skybrud.Social.TwentyThree.Endpoints {

    /// <summary>
    /// Class representing the raw implementation of the <strong>Tags</strong> endpoint.
    /// </summary>
    public class TwentyThreeTagsRawEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the OAuth 1.0a client.
        /// </summary>
        public TwentyThreeOAuthClient Client { get; }

        #endregion

        #region Constructors

        internal TwentyThreeTagsRawEndpoint(TwentyThreeOAuthClient client) {
            Client = client;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Returns a list of tags.
        /// </summary>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://www.twentythree.com/api/tag-list</cref>
        /// </see>
        public IHttpResponse GetList() {
            return GetList(new TwentyThreeGetTagsOptions());
        }

        /// <summary>
        /// Returns a list of tags.
        /// </summary>
        /// <param name="page">The page to be returned.</param>
        /// <param name="size">The maximum amount of tags to be returned on each page.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://www.twentythree.com/api/tag-list</cref>
        /// </see>
        public IHttpResponse GetList(int? page, int size) {
            return GetList(new TwentyThreeGetTagsOptions(page, size));
        }

        /// <summary>
        /// Returns a list of tags.
        /// </summary>
        /// <param name="page">The page to be returned.</param>
        /// <param name="size">The maximum amount of tags to be returned on each page.</param>
        /// <param name="orderBy">The field by which the tags should be sorted.</param>
        /// <param name="order">The order in which the tags should be sorted.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://www.twentythree.com/api/tag-list</cref>
        /// </see>
        public IHttpResponse GetList(int? page, int size, TwentyThreeTagSortField? orderBy, TwentyThreeSortOrder? order) {
            return GetList(new TwentyThreeGetTagsOptions(page, size, orderBy, order));
        }

        /// <summary>
        /// Returns a list of tags.
        /// </summary>
        /// <param name="orderBy">The field by which the tags should be sorted.</param>
        /// <param name="order">The order in which the tags should be sorted.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://www.twentythree.com/api/tag-list</cref>
        /// </see>
        public IHttpResponse GetList(TwentyThreeTagSortField? orderBy, TwentyThreeSortOrder? order) {
            return GetList(new TwentyThreeGetTagsOptions(orderBy, order));
        }

        /// <summary>
        /// Returns a list of tags matching the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://www.twentythree.com/api/tag-list</cref>
        /// </see>
        public IHttpResponse GetList(TwentyThreeGetTagsOptions options) {
            if (options == null) throw new ArgumentNullException(nameof(options));
            return Client.GetResponse(options);
        }

        #endregion

    }

}