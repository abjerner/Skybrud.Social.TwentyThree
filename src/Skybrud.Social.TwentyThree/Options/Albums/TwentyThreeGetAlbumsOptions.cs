using Skybrud.Essentials.Http;
using Skybrud.Essentials.Http.Collections;
using Skybrud.Essentials.Http.Options;

namespace Skybrud.Social.TwentyThree.Options.Albums {

    /// <summary>
    /// Options for getting a list of albums.
    /// </summary>
    /// <see>
    ///     <cref>https://www.twentythree.com/api/album-list</cref>
    /// </see>
    public class TwentyThreeGetAlbumsOptions : IHttpRequestOptions {

        #region Properties

        /// <summary>
        /// Limit to a single album or channel.
        /// </summary>
        public string? AlbumId { get; set; }

        /// <summary>
        /// Albums or channels created by a specific user.
        /// </summary>
        public string? UserId { get; set; }

        /// <summary>
        /// List albums or channels from a specific video or photo.
        /// </summary>
        public string? PhotoId { get; set; }

        /// <summary>
        /// Gets or sets a search term the returned albums should match.
        /// </summary>
        public string? Search { get; set; }

        /// <summary>
        /// Gets or sets the field by which the albums should be sorted. Default is <see cref="TwentyThreeAlbumSortField.CreationDate"/>.
        /// </summary>
        public TwentyThreeAlbumSortField? OrderBy { get; set; }

        /// <summary>
        /// Gets or sets the order by which the albums should be sorted.
        /// </summary>
        public TwentyThreeSortOrder? Order { get; set; }

        /// <summary>
        /// Gets or sets the page offset of the request.
        /// </summary>
        public int? Page { get; set; }

        /// <summary>
        /// Gets or sets the maximum amount of photos to returned per page.
        /// </summary>
        public int? Size { get; set; }

        #endregion

        #region Member methods

        /// <inheritdoc />
        public IHttpRequest GetRequest() {

            IHttpQueryString query = new HttpQueryString();

            if (string.IsNullOrWhiteSpace(AlbumId) == false) query.Add("album_id", AlbumId!);
            if (string.IsNullOrWhiteSpace(UserId) == false) query.Add("user_id", UserId!);
            if (string.IsNullOrWhiteSpace(PhotoId) == false) query.Add("photo_id", PhotoId!);
            if (string.IsNullOrWhiteSpace(Search) == false) query.Add("search", Search!);

            if (OrderBy is not null) query.Add("orderby", TwentyThreeUtils.ToString(OrderBy)!);
            if (Order is not null) query.Add("order", TwentyThreeUtils.ToString(Order)!);

            if (Page is not null) query.Add("p", Page);
            if (Size is not null) query.Add("size", Size);

            // Initialize a new request
            return HttpRequest.Get("/api/album/list", query);

        }

        #endregion

    }

}