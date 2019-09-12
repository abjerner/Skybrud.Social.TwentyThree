using Skybrud.Social.Http;
using Skybrud.Social.Interfaces.Http;

namespace Skybrud.Social.TwentyThree.Options.Photos {

    public class TwentyThreeGetPhotosOptions : IHttpGetOptions {

        #region Properties

        /// <summary>
        /// Gets or sets the ID of a photo. If specified, only the photo or video with this ID is returned.
        /// </summary>
        public string PhotoId { get; set; }

        /// <summary>
        /// Gets or sets the token for a specific video/photo or an album − depending on whether <c>photo_id</c> or
        /// <c>album_id</c> is set.
        ///
        /// Specifying either an <c>album_id/token</c> or a <c>photo_id/token</c> will give the client access to
        /// information about the <c>video/photo/album/channel</c> irregardless of permission level. When requesting a
        /// single photo object, tokens can be explicitly time-limited.
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// Gets or sets whether videos should be included in the response.
        /// 
        /// Possible values are <see cref="TwentyThreeVideoParameter.All"/>,
        /// <see cref="TwentyThreeVideoParameter.OnlyVideos"/> and
        /// <see cref="TwentyThreeVideoParameter.IgnoreVideos"/>.
        /// </summary>
        public TwentyThreeVideoParameter Video { get; set; }

        public int Page { get; set; }

        public int Size { get; set; }

        #endregion

        #region Member methods
        
        public IHttpQueryString GetQueryString() {

            IHttpQueryString query = new SocialHttpQueryString();

            if (string.IsNullOrWhiteSpace(PhotoId) == false) query.Add("photo_id", PhotoId);
            if (string.IsNullOrWhiteSpace(Token) == false) query.Add("token", Token);

            switch (Video) {
                case TwentyThreeVideoParameter.OnlyVideos:
                    query.Add("video_p", "1");
                    break;
                case TwentyThreeVideoParameter.IgnoreVideos:
                    query.Add("video_p", "0");
                    break;
            }

            if (Page > 0) query.Add("p", Page);
            if (Size > 0) query.Add("size", Size);

            return query;

        }
        
        #endregion

    }

}