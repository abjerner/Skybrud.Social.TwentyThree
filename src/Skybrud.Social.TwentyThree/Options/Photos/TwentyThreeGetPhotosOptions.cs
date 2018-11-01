using System;
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

            if (String.IsNullOrWhiteSpace(PhotoId) == false) query.Add("photo_id", PhotoId);

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