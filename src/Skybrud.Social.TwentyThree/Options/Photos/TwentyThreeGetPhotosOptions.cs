using System.Collections.Generic;
using System.Linq;
using Skybrud.Essentials.Http;
using Skybrud.Essentials.Http.Collections;
using Skybrud.Essentials.Http.Options;
using Skybrud.Essentials.Strings.Extensions;

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
        public string? AlbumId { get; set; }

        /// <summary>
        /// Gets or sets the ID of a photo. If specified, only the photo or video with this ID is returned. If
        /// <see cref="AlbumId"/> is set, this parameter is ignored.
        /// </summary>
        public string? PhotoId { get; set; }

        /// <summary>
        /// Gets or sets the token for a specific video/photo or an album − depending on whether <see cref="AlbumId"/> or
        /// <see cref="PhotoId"/> is set.
        ///
        /// Specifying either an <c>album_id/token</c> or a <c>photo_id/token</c> will give the client access to
        /// information about the <c>video/photo/album/channel</c> irregardless of permission level. When requesting a
        /// single photo object, tokens can be explicitly time-limited.
        /// </summary>
        public string? Token { get; set; }

        /// <summary>
        /// Gets or sets a user ID. If specified, the returned results will be photos uploaded by the user with the
        /// specified user ID.
        /// </summary>
        public string? UserId { get; set; }

        /// <summary>
        /// Gets or sets the identifier for a video player. Including the parameter will allow contextualization of the
        /// content for the specific player; for example by fitting the playflow (preroll, postroll, after text etc)
        /// based on the player.
        /// </summary>
        public string? PlayerId { get; set; }

        /// <summary>
        /// Gets or sets a list of tags that the returned photos should match. Use in combination with <see cref="TagMode"/>.
        /// </summary>
        public List<string> Tags { get; set; } = new();

        /// <summary>
        /// Gets or sets the tag mode to be used. <see cref="TwentyThreePhotoTagMode.And"/> indicates that all of the
        /// specified tags should be matched, while <see cref="TwentyThreePhotoTagMode.Or"/> indicates that at least
        /// one of the specified tags should be matched. Default is <see cref="TwentyThreePhotoTagMode.And"/>.
        /// </summary>
        public TwentyThreePhotoTagMode? TagMode { get; set; }

        /// <summary>
        /// Gets or sets a search term the returned photos or videos should match.
        /// </summary>
        public string? Search { get; set; }

        /// <summary>
        /// Only include content from a specific year in the response.
        /// </summary>
        public int? Year { get; set; }

        /// <summary>
        /// Only include content from a specific month in the response. Requires <see cref="Year"/> to be set.
        /// </summary>
        public int? Month { get; set; }

        /// <summary>
        /// Only include content from a specific day in the response. Requires <see cref="Year"/> and
        /// <see cref="Month"/> to be set.
        /// </summary>
        public int? Day { get; set; }

        /// <summary>
        /// Gets or sets whether videos should be included in the response.
        ///
        /// Possible values are <see cref="TwentyThreeVideoParameter.OnlyVideos"/> and
        /// <see cref="TwentyThreeVideoParameter.IgnoreVideos"/>.
        /// </summary>
        public TwentyThreeVideoParameter? Video { get; set; }

        /// <summary>
        /// Gets or sets whether to include unpublished videos or photos in the response. Defaults to
        /// <see langword="false"/> if not specified.
        /// </summary>
        public bool? IncludeUnpublished { get; set; }

        /// <summary>
        /// Gets or sets the field by which the albums should be sorted.
        /// </summary>
        public TwentyThreePhotoSortField? OrderBy { get; set; }

        /// <summary>
        /// Gets or sets the order by which the albums should be sorted.
        /// </summary>
        public TwentyThreeSortOrder? Order { get; set; }

        /// <summary>
        /// Gets or sets whether to only include videos which are promoted. If <see langword="true"/>, only promoted
        /// videos will be included, and if <see langword="false"/>, only videos that are not promoted will be
        /// included. Default is <see langword="null"/> in which case both promoted and not promoted videos will be
        /// included.
        /// </summary>
        public bool? Promoted { get; set; }

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
        public virtual IHttpRequest GetRequest() {

            IHttpQueryString query = new HttpQueryString();

            if (string.IsNullOrWhiteSpace(AlbumId) == false) query.Add("album_id", AlbumId!);
            if (string.IsNullOrWhiteSpace(PhotoId) == false) query.Add("photo_id", PhotoId!);
            if (string.IsNullOrWhiteSpace(Token) == false) query.Add("token", Token!);
            if (string.IsNullOrWhiteSpace(UserId) == false) query.Add("user_id", UserId!);
            if (string.IsNullOrWhiteSpace(PlayerId) == false) query.Add("player_id", PlayerId!);

            if (Tags is { Count: > 0 }) query.Add("tags", string.Join(" ", from tag in Tags select EncodeTag(tag)));
            if (TagMode is not null) query.Add("tag_mode", TagMode.ToLower());

            if (string.IsNullOrWhiteSpace(Search) == false) query.Add("search", Search!);

            if (Year is not null) query.Add("year", Year);
            if (Month is not null) query.Add("month", Month);
            if (Day is not null) query.Add("day", Day);

            if (Video is not null) query.Add("video_p", TwentyThreeUtils.ToString(Video)!);
            if (IncludeUnpublished is not null) query.Add("include_unpublished_p", IncludeUnpublished.Value ? 1 : 0);

            if (OrderBy is not null) query.Add("orderby", TwentyThreeUtils.ToString(OrderBy)!);
            if (Order is not null) query.Add("order", TwentyThreeUtils.ToString(Order)!);

            if (Promoted is not null) query.Add("promoted_p", Promoted.Value ? 1 : 0);

            if (Page is not null) query.Add("p", Page);
            if (Size is not null) query.Add("size", Size);

            // Initialize a new request
            return HttpRequest.Get("/api/photo/list", query);

        }

        private string EncodeTag(string tagName) {
            // TODO: Can tag names contain quotes?
            return tagName.IndexOf(' ') >= 0 ? $"\"{tagName}\"" : tagName;

        }

        #endregion

    }

}