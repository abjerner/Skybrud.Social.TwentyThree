using Skybrud.Essentials.Common;
using Skybrud.Essentials.Http;
using Skybrud.Essentials.Http.Collections;
using Skybrud.Essentials.Http.Options;

#pragma warning disable CS1591

namespace Skybrud.Social.TwentyThree.Options.OEmbed {

    /// <summary>
    /// OEmbed options for a TwentyThree video.
    /// </summary>
    /// <see>
    ///     <cref>https://www.twentythree.com/help/manage-oembed</cref>
    /// </see>
    public class TwentyThreeOEmbedOptions : IHttpRequestOptions {

        public string? Url { get; set; }

        public int MaxWidth { get; set; }

        public int MaxHeight { get; set; }

        public bool? AutoPlay { get; set; }

        public string? PlayerId { get; set; }

        public TwentyThreeOEmbedOptions() { }

        public TwentyThreeOEmbedOptions(string url) {
            Url = url;
        }

        public IHttpRequest GetRequest() {

            if (string.IsNullOrWhiteSpace(Url)) throw new PropertyNotSetException(nameof(Url));

            IHttpQueryString query = new HttpQueryString {
                {"url", Url},
                {"format", "json"}
            };

            if (MaxWidth > 0) query.Add("maxwidth", MaxWidth);
            if (MaxHeight > 0) query.Add("maxheight", MaxHeight);
            if (AutoPlay is not null) query.Add("autoplay", AutoPlay.Value);
            if (!string.IsNullOrWhiteSpace(PlayerId)) query.Add("player_id", PlayerId!);

            // Initialize a new request
            return HttpRequest.Get("/oembed", query);

        }

    }

}