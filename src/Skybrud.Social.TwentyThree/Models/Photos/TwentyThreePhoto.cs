using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Essentials.Strings;
using Skybrud.Essentials.Time;
using Skybrud.Social.TwentyThree.Exceptions;
using Skybrud.Social.TwentyThree.Extensions;

// ReSharper disable InconsistentNaming
#pragma warning disable CS1591

namespace Skybrud.Social.TwentyThree.Models.Photos {

    /// <summary>
    /// Class representing a TwentyThree photo (or video, really).
    /// </summary>
    public class TwentyThreePhoto : TwentyThreeObject {

        #region Properties

        public string PhotoId { get; }

        public string Title { get; }

        public string Token { get; }

        public bool IsPublished { get; }

        public TimeSpan VideoLength { get; }

        public string AbsoluteUrl { get; }

        public EssentialsTime PublishDate { get; }

        public EssentialsTime CreationDate { get; }

        public TwentyThreeThumbnail Original { get; }

        public TwentyThreeThumbnail Quad16 { get; }

        public TwentyThreeThumbnail Quad50 { get; }

        public TwentyThreeThumbnail Quad75 { get; }

        public TwentyThreeThumbnail Quad100 { get; }

        public TwentyThreeThumbnail Medium { get; }

        public TwentyThreeThumbnail Portrait { get; }

        public TwentyThreeThumbnail Standard { get; }

        public TwentyThreeThumbnail Large { get; }

        public IReadOnlyList<TwentyThreeThumbnail> Thumbnails { get; }

        public TwentyThreeVideoFormat VideoMedium { get; }

        public TwentyThreeVideoFormat VideoHd { get; }

        public TwentyThreeVideoFormat Video1080p { get; }

        public TwentyThreeVideoFormat Video4K { get; }

        public TwentyThreeVideoFormat VideoMobileH263Amr { get; }

        public TwentyThreeVideoFormat VideoMobileH263Aac { get; }

        public TwentyThreeVideoFormat VideoMobileMpeg4Amr { get; }

        public TwentyThreeVideoFormat VideoMobileHigh { get; }

        public IReadOnlyList<TwentyThreeVideoFormat> VideoFormats { get; }

        public long ViewCount { get; }

        public string Content { get; }

        public string ContentText { get; }

        public IReadOnlyList<string> Tags { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of <see cref="TwentyThreePhoto"/> parsed from the specified <paramref name="json"/> object.
        /// </summary>
        /// <param name="json">The <see cref="JObject"/> to be parsed.</param>
        protected TwentyThreePhoto(JObject json) : base(json) {
            try {
                PhotoId = json.GetString("photo_id");
                Title = json.GetString("title");
                Token = json.GetString("token");
                IsPublished = json.GetString("published_p", StringUtils.ParseBoolean);
                PublishDate = json.GetTimestamp("publish_date_epoch");
                CreationDate = json.GetTimestamp("creation_date_epoch");
                ViewCount = json.GetInt64("view_count");
                AbsoluteUrl = json.GetString("absolute_url");
                VideoLength = json.GetDouble("video_length", TimeSpan.FromSeconds);
                Original = TwentyThreeThumbnail.Parse(json, "original");
                Quad16 = TwentyThreeThumbnail.Parse(json, "quad16");
                Quad50 = TwentyThreeThumbnail.Parse(json, "quad50");
                Quad75 = TwentyThreeThumbnail.Parse(json, "quad75");
                Quad100 = TwentyThreeThumbnail.Parse(json, "quad100");
                Medium = TwentyThreeThumbnail.Parse(json, "medium");
                Portrait = TwentyThreeThumbnail.Parse(json, "portrait");
                Standard = TwentyThreeThumbnail.Parse(json, "standard");
                Large = TwentyThreeThumbnail.Parse(json, "large");
                VideoMedium = TwentyThreeVideoFormat.Parse(json, "video_medium");
                VideoHd = TwentyThreeVideoFormat.Parse(json, "video_hd");
                Video1080p = TwentyThreeVideoFormat.Parse(json, "video_1080p");
                Video4K = TwentyThreeVideoFormat.Parse(json, "video_4k");
                VideoMobileH263Amr = TwentyThreeVideoFormat.Parse(json, "video_mobile_h263_amr");
                VideoMobileH263Aac = TwentyThreeVideoFormat.Parse(json, "video_mobile_h263_aac");
                VideoMobileMpeg4Amr = TwentyThreeVideoFormat.Parse(json, "video_mobile_mpeg4_amr");
                VideoMobileHigh = TwentyThreeVideoFormat.Parse(json, "video_mobile_high");
                Content = json.GetString("content");
                ContentText = json.GetString("content_text");
                Tags = json.GetStringArray("tags");
                Thumbnails = new[] { Original, Quad16, Quad50, Quad75, Quad100, Medium, Portrait, Standard, Large }.Where(x => x != null).ToArray();
                VideoFormats = new[] { VideoMedium, VideoHd, Video1080p, Video4K, VideoMobileH263Amr, VideoMobileH263Aac, VideoMobileMpeg4Amr, VideoMobileHigh }.Where(x => x != null).ToArray();
            } catch (Exception ex) {
                throw new TwentyThreeJsonParseException("Failed parsing photo from JSON.", json, ex);
            }
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Gets an instance of <see cref="TwentyThreePhoto"/> from the specified <paramref name="json"/> object.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> to parse.</param>
        /// <returns>An instance of <see cref="TwentyThreePhoto"/>.</returns>
        public static TwentyThreePhoto Parse(JObject json) {
            return json == null ? null : new TwentyThreePhoto(json);
        }

        #endregion

    }

}