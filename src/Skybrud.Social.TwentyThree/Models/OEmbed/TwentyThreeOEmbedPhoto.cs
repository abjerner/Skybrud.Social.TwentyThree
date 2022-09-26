using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

#pragma warning disable CS1591

namespace Skybrud.Social.TwentyThree.Models.OEmbed {
    
    /// <summary>
    /// OEmbed details of a Twenty Three photo.
    /// </summary>
    /// <see>
    ///     <cref>https://www.twentythree.com/help/manage-oembed</cref>
    /// </see>
    /// <see>
    ///     <cref>https://oembed.com/</cref>
    /// </see>
    public class TwentyThreeOEmbedPhoto : TwentyThreeOEmbed {

        public string PhotoId { get; }
        
        public string AlbumId { get; }

        public int Width { get; }

        public int Height { get; }

        public TwentyThreeOEmbedPhoto(JObject json) : base(json) {
            PhotoId = json.GetString("photo_id");
            AlbumId = json.GetString("album_id");
            Width = json.GetInt32("width");
            Height = json.GetInt32("height");
        }

        public new static TwentyThreeOEmbedPhoto Parse(JObject json) {
            return json == null ? null : new TwentyThreeOEmbedPhoto(json);
        }

    }

}