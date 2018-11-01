using System;
using System.Linq;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Essentials.Strings;
using Skybrud.Essentials.Time;
// ReSharper disable InconsistentNaming

namespace Skybrud.Social.TwentyThree.Models.Photos {

    public class TwentyThreePhoto : TwentyThreeObject {

        #region Properties

        public string Id { get; }

        public string Title { get; }

        public bool IsPublished { get; }

        public TimeSpan VideoLength { get; }

        public string AbsoluteUrl { get; }

        public EssentialsDateTime PublishDate { get; }

        public EssentialsDateTime CreationDate { get; }

        public TwentyThreeThumbnail Original { get; }

        public TwentyThreeThumbnail Quad16 { get; }

        public TwentyThreeThumbnail Quad50 { get; }

        public TwentyThreeThumbnail Quad75 { get; }

        public TwentyThreeThumbnail Quad100 { get; }

        public TwentyThreeThumbnail Medium { get; }

        public TwentyThreeThumbnail Portrait { get; }

        public TwentyThreeThumbnail Standard { get; }

        public TwentyThreeThumbnail Large { get; }

        public TwentyThreeThumbnail[] Thumbnails { get; }

        public TwentyThreeVideoFormat VideoMedium { get; }

        public TwentyThreeVideoFormat VideoHd { get; }

        public TwentyThreeVideoFormat Video1080p { get; }

        public TwentyThreeVideoFormat Video4K { get; }

        public TwentyThreeVideoFormat VideoMobileH263Amr { get; }

        public TwentyThreeVideoFormat VideoMobileH263Aac { get; }

        public TwentyThreeVideoFormat VideoMobileMpeg4Amr { get; }

        public TwentyThreeVideoFormat VideoMobileHigh { get; }

        public TwentyThreeVideoFormat[] VideoFormats { get; }

        public long ViewCount { get; }

        public string Content { get; }

        public string ContentText { get; }

        public string[] Tags { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of <see cref="TwentyThreePhoto"/> parsed from the specified <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">The <see cref="JObject"/> to be parsed.</param>
        protected TwentyThreePhoto(JObject obj) : base(obj) {
            Id = obj.GetString("photo_id");
            Title = obj.GetString("title");
            IsPublished = obj.GetString("published_p", StringUtils.ParseBoolean);
            PublishDate = obj.GetInt32("publish_date_epoch", EssentialsDateTime.FromUnixTimestamp);
            CreationDate = obj.GetInt32("creation_date_epoch", EssentialsDateTime.FromUnixTimestamp);
            ViewCount = obj.GetInt64("view_count");
            AbsoluteUrl = obj.GetString("absolute_url");
            VideoLength = obj.GetDouble("video_length", TimeSpan.FromSeconds);
            Original = TwentyThreeThumbnail.Parse(obj, "original");
            Quad16 = TwentyThreeThumbnail.Parse(obj, "quad16");
            Quad50 = TwentyThreeThumbnail.Parse(obj, "quad50");
            Quad75 = TwentyThreeThumbnail.Parse(obj, "quad75");
            Quad100 = TwentyThreeThumbnail.Parse(obj, "quad100");
            Medium = TwentyThreeThumbnail.Parse(obj, "medium");
            Portrait = TwentyThreeThumbnail.Parse(obj, "portrait");
            Standard = TwentyThreeThumbnail.Parse(obj, "standard");
            Large = TwentyThreeThumbnail.Parse(obj, "large");
            VideoMedium = TwentyThreeVideoFormat.Parse(obj, "video_medium");
            VideoHd = TwentyThreeVideoFormat.Parse(obj, "video_hd");
            Video1080p = TwentyThreeVideoFormat.Parse(obj, "video_1080p");
            Video4K = TwentyThreeVideoFormat.Parse(obj, "video_4k");
            VideoMobileH263Amr = TwentyThreeVideoFormat.Parse(obj, "video_mobile_h263_amr");
            VideoMobileH263Aac = TwentyThreeVideoFormat.Parse(obj, "video_mobile_h263_aac");
            VideoMobileMpeg4Amr = TwentyThreeVideoFormat.Parse(obj, "video_mobile_mpeg4_amr");
            VideoMobileHigh = TwentyThreeVideoFormat.Parse(obj, "video_mobile_high");
            Content = obj.GetString("content");
            ContentText = obj.GetString("content_text");
            Tags = obj.GetStringArray("tags");
            Thumbnails = new[] { Original, Quad16, Quad50, Quad75, Quad100, Medium, Portrait, Standard, Large }.Where(x => x != null).ToArray();
            VideoFormats = new[] { VideoMedium, VideoHd, Video1080p, Video4K, VideoMobileH263Amr, VideoMobileH263Aac, VideoMobileMpeg4Amr, VideoMobileHigh }.Where(x => x != null).ToArray();
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Gets an instance of <see cref="TwentyThreePhoto"/> from the specified <see cref="JObject"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to parse.</param>
        /// <returns>An instance of <see cref="TwentyThreePhoto"/>.</returns>
        public static TwentyThreePhoto Parse(JObject obj) {
            return obj == null ? null : new TwentyThreePhoto(obj);
        }

        #endregion

    }

}