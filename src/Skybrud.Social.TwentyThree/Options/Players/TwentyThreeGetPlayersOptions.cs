using Skybrud.Essentials.Http;
using Skybrud.Essentials.Http.Collections;
using Skybrud.Essentials.Http.Options;

namespace Skybrud.Social.TwentyThree.Options.Players {
    
    /// <summary>
    /// Options for getting a list of players.
    /// </summary>
    /// <see>
    ///     <cref>https://www.twentythree.com/api/player-list</cref>
    /// </see>
    public class TwentyThreeGetPlayersOptions : IHttpRequestOptions {

        #region Properties

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
        public IHttpRequest GetRequest() {

            IHttpQueryString query = new HttpQueryString();

            if (Page is not null) query.Add("p", Page);
            if (Size is not null) query.Add("size", Size);

            // Initialize a new request
            return HttpRequest.Get("/api/player/list", query);

        }
        
        #endregion

    }

}