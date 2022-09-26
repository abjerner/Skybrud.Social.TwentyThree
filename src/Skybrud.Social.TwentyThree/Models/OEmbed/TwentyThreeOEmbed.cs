using System;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

#pragma warning disable CS1591

namespace Skybrud.Social.TwentyThree.Models.OEmbed {
    
    /// <summary>
    /// OEmbed details of a Twenty Three resource.
    /// </summary>
    /// <see>
    ///     <cref>https://oembed.com/</cref>
    /// </see>
    public class TwentyThreeOEmbed {
        
        public string Type { get; }
        
        public float Version { get; }
        
        public string Title { get; }

        public string Url { get; }
        
        public string AuthorName { get; }
        
        public string AuthorUrl { get; }
        
        public string ProviderName { get; }
        
        public string ProviderUrl { get; }

        public TimeSpan CacheAge { get; }

        public bool HasCacheAge { get; }
        
        public string ThumbnailUrl { get; }
        
        public int ThumbnailWidth { get; }
        
        public int ThumbnailHeight { get; }

        protected TwentyThreeOEmbed(JObject json) {
            Type = json.GetString("type");
            Version = json.GetFloat("version");
            Title = json.GetString("title");
            Url = json.GetString("url");
            AuthorName = json.GetString("author_name");
            AuthorUrl = json.GetString("author_url");
            ProviderName = json.GetString("provider_name");
            ProviderUrl = json.GetString("provider_url");
            CacheAge = json.GetDouble("cache_age", TimeSpan.FromSeconds);
            HasCacheAge = json.HasValue("cache_age");
            ThumbnailWidth = json.GetInt32("thumbnail_width");
            ThumbnailHeight = json.GetInt32("thumbnail_height");
            ThumbnailUrl = json.GetString("thumbnail_url");
        }

        public static TwentyThreeOEmbed Parse(JObject json) {

            if (json == null) return null;

            string type = json.GetString("type");

            return type switch {
                null => throw new Exception("No OEmbed type specified."),
                "" => throw new Exception("No OEmbed type specified."),
                "video" => TwentyThreeOEmbedVideo.Parse(json),
                "photo" => TwentyThreeOEmbedPhoto.Parse(json),
                _ => throw new Exception($"Unsupported OEmbed type: {type}")
            };
        }

    }

}