using Skybrud.Essentials.Common;
using Skybrud.Essentials.Http;
using Skybrud.Essentials.Http.Collections;
using Skybrud.Essentials.Http.OAuth;
using Skybrud.Social.TwentyThree.Endpoints;

namespace Skybrud.Social.TwentyThree.OAuth {

    /// <summary>
    /// Class for handling authentication and communication with the TwentyThree API using OAuth 1.0a.
    /// </summary>
    public class TwentyThreeOAuthClient : OAuthClient {

        #region Properties

        /// <summary>
        /// Gets or sets the domain to be used for all API requests - eg. <c>videos.skybrud.dk</c>.
        /// </summary>
        public string? Domain { get; set; }

        /// <summary>
        /// Gets a reference to the raw <strong>Albums</strong> endpoint.
        /// </summary>
        public TwentyThreeAlbumsRawEndpoint Albums { get; }

        /// <summary>
        /// Gets a reference to the raw <strong>OEmbed</strong> endpoint.
        /// </summary>
        public TwentyThreeOEmbedRawEndpoint OEmbed { get; }

        /// <summary>
        /// Gets a reference to the raw <strong>Photos</strong> endpoint.
        /// </summary>
        public TwentyThreePhotosRawEndpoint Photos { get; }

        /// <summary>
        /// Gets a reference to the raw <strong>Players</strong> endpoint.
        /// </summary>
        public TwentyThreePlayersRawEndpoint Players { get; }

        /// <summary>
        /// Gets a reference to the raw <strong>Spots</strong> endpoint.
        /// </summary>
        public TwentyThreeSpotsRawEndpoint Spots { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="TwentyThreeOAuthClient"/> class.
        /// </summary>
        public TwentyThreeOAuthClient() : this(null, null, null, null, null) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="TwentyThreeOAuthClient"/> class.
        /// </summary>
        /// <param name="consumerKey">The comsumer key of your application.</param>
        /// <param name="consumerSecret">The consumer secret of your application.</param>
        /// <param name="token">The access token of the user.</param>
        /// <param name="tokenSecret">The access token secret of the user.</param>
        /// <param name="callback">The callback URI used for authentication.</param>
        public TwentyThreeOAuthClient(string? consumerKey, string? consumerSecret, string? token, string? tokenSecret, string? callback) {

            // Common properties
            ConsumerKey = consumerKey;
            ConsumerSecret = consumerSecret;
            Token = token;
            TokenSecret = tokenSecret;
            Callback = callback;

            // Endpoints
            Albums = new TwentyThreeAlbumsRawEndpoint(this);
            OEmbed = new TwentyThreeOEmbedRawEndpoint(this);
            Photos = new TwentyThreePhotosRawEndpoint(this);
            Players = new TwentyThreePlayersRawEndpoint(this);
            Spots = new TwentyThreeSpotsRawEndpoint(this);

            // Specific to Video23
            RequestTokenUrl = "http://api.visualplatform.net/oauth/request_token";
            AuthorizeUrl = "http://api.visualplatform.net/oauth/access_token";
            AccessTokenUrl = "http://api.visualplatform.net/oauth/authorize";

        }

        #endregion

        #region Member methods

        /// <inheritdoc />
        protected override void PrepareHttpRequest(IHttpRequest request) {

            // Handle /oembed requests specifically
            if (request.Url == "/oembed") {
                if (string.IsNullOrWhiteSpace(Domain)) throw new PropertyNotSetException(nameof(Domain));
                request.Url = "https://" + Domain + request.Url;
                return;
            }

            // Should we append the domain and schema to the URL?
            if (request.Url.StartsWith("/api/")) {
                if (string.IsNullOrWhiteSpace(Domain)) throw new PropertyNotSetException(nameof(Domain));
                request.Url = "https://" + Domain + request.Url;
            }

            // Append "raw" to the query string so we can get a proper JSON response
            request.QueryString ??= new HttpQueryString();
            request.QueryString.Set("format", "json");
            request.QueryString.Set("raw", string.Empty);

            // Call the base method to handle OAuth 1.0a logic
            base.PrepareHttpRequest(request);

        }

        #endregion

    }

}