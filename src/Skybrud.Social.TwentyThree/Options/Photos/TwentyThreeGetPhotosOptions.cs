using Skybrud.Essentials.Http;
using Skybrud.Essentials.Http.Collections;
using Skybrud.Essentials.Http.Options;

namespace Skybrud.Social.TwentyThree.Options.Photos {
    
    /// <summary>
    /// Options for getting a list of photos.
    /// </summary>
    /// <see>
    ///     <cref>https://www.twentythree.com/api/photo-list</cref>
    /// </see>
    public class TwentyThreeGetPhotosOptions : IHttpRequestOptions {

        #region Properties

        /// <summary>
        /// Gets or sets the ID of a parent album or channel. If specified, only photos in that album or channel will
        /// be returned. If this parameter is set, <see cref="PhotoId"/> is ignored.
        /// </summary>
        public string AlbumId { get; set; }

        /// <summary>
        /// Gets or sets the ID of a photo. If specified, only the photo or video with this ID is returned. If
        /// <see cref="AlbumId"/> is set, this parameter is ignored.
        /// </summary>
        public string PhotoId { get; set; }

        /// <summary>
        /// Gets or sets the token for a specific video/photo or an album − depending on whether <see cref="AlbumId"/> or
        /// <see cref="PhotoId"/> is set.
        ///
        /// Specifying either an <c>album_id/token</c> or a <c>photo_id/token</c> will give the client access to
        /// information about the <c>video/photo/album/channel</c> irregardless of permission level. When requesting a
        /// single photo object, tokens can be explicitly time-limited.
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// Gets or sets whether videos should be included in the response.
        /// 
        /// Possible values are <see cref="TwentyThreeVideoParameter.OnlyVideos"/> and
        /// <see cref="TwentyThreeVideoParameter.IgnoreVideos"/>.
        /// </summary>
        public TwentyThreeVideoParameter? Video { get; set; }

        /// <summary>
        /// Gets or sets a search term the returned photos or videos should match.
        /// </summary>
        public string Search { get; set; }
        
        /// <summary>
        /// Gets or sets the field by which the albums should be sorted.
        /// </summary>
        public TwentyThreePhotoSortField? OrderBy { get; set; }

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
            
            if (string.IsNullOrWhiteSpace(AlbumId) == false) query.Add("album_id", AlbumId);
            if (string.IsNullOrWhiteSpace(PhotoId) == false) query.Add("photo_id", PhotoId);
            if (string.IsNullOrWhiteSpace(Token) == false) query.Add("token", Token);
            if (string.IsNullOrWhiteSpace(Search) == false) query.Add("search", Search);

            if (Video is not null) query.Add("video_p", TwentyThreeUtils.ToString(Video));
            if (OrderBy is not null) query.Add("orderby", TwentyThreeUtils.ToString(OrderBy));
            if (Order is not null) query.Add("order", TwentyThreeUtils.ToString(Order));

            if (Page is not null) query.Add("p", Page);
            if (Size is not null) query.Add("size", Size);

            // Initialize a new request
            return HttpRequest.Get("/api/photo/list", query);

        }
        
        #endregion

    }

}