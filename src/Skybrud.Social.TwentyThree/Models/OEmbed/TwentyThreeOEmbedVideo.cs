using System;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

#pragma warning disable CS1591

namespace Skybrud.Social.TwentyThree.Models.OEmbed {
    
    /// <summary>
    /// OEmbed details of a TwentyThree video.
    /// </summary>
    /// <see>
    ///     <cref>https://www.twentythree.com/help/manage-oembed</cref>
    /// </see>
    /// <see>
    ///     <cref>https://oembed.com/</cref>
    /// </see>
    public class TwentyThreeOEmbedVideo : TwentyThreeOEmbed {

        public string PhotoId { get; }
        
        public string AlbumId { get; }

        public int Width { get; }

        public int Height { get; }
        
        public string Html { get; }

        public TimeSpan Duration { get; }

        public TwentyThreeOEmbedVideo(JObject json) : base(json) {
            PhotoId = json.GetString("photo_id");
            AlbumId = json.GetString("album_id");
            Width = json.GetInt32("width");
            Height = json.GetInt32("height");
            Html = json.GetString("html");
            Duration = json.GetDouble("duration", TimeSpan.FromSeconds);
        }

        public new static TwentyThreeOEmbedVideo Parse(JObject json) {
            return json == null ? null : new TwentyThreeOEmbedVideo(json);
        }

    }

}