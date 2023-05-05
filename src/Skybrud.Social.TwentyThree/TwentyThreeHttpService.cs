using System;
using Skybrud.Social.TwentyThree.Endpoints;
using Skybrud.Social.TwentyThree.OAuth;

namespace Skybrud.Social.TwentyThree {

    /// <summary>
    /// Class working as an entry point to the TwentyThree API.
    /// </summary>
    public class TwentyThreeHttpService {

        #region Properties

        /// <summary>
        /// Gets a reference to the underlying OAuth client.
        /// </summary>
        public TwentyThreeOAuthClient Client { get; }

        /// <summary>
        /// Gets a reference to the <strong>Albums</strong> endpoint.
        /// </summary>
        public TwentyThreeAlbumsEndpoint Albums { get; }

        /// <summary>
        /// Gets a reference to the <strong>OEmbed</strong> endpoint.
        /// </summary>
        public TwentyThreeOEmbedEndpoint OEmbed { get; }

        /// <summary>
        /// Gets a reference to the <strong>Photos</strong> endpoint.
        /// </summary>
        public TwentyThreePhotosEndpoint Photos { get; }

        /// <summary>
        /// Gets a reference to the <strong>Players</strong> endpoint.
        /// </summary>
        public TwentyThreePlayersEndpoint Players { get; }

        /// <summary>
        /// Gets a reference to the <strong>Spots</strong> endpoint.
        /// </summary>
        public TwentyThreeSpotsEndpoint Spots { get; }

        /// <summary>
        /// Gets a reference to the <strong>Tags</strong> endpoint.
        /// </summary>
        public TwentyThreeTagsEndpoint Tags { get; }

        #endregion

        #region Constructors

        private TwentyThreeHttpService(TwentyThreeOAuthClient client) {

            // Set the client
            Client = client;

            // Set the endpoints etc.
            Albums = new TwentyThreeAlbumsEndpoint(this);
            OEmbed = new TwentyThreeOEmbedEndpoint(this);
            Photos = new TwentyThreePhotosEndpoint(this);
            Players = new TwentyThreePlayersEndpoint(this);
            Spots = new TwentyThreeSpotsEndpoint(this);
            Tags = new TwentyThreeTagsEndpoint(this);

        }

        #endregion

        #region Static methods

        /// <summary>
        /// Initializes a new instance from the specified <see cref="TwentyThreeOAuthClient"/>.
        /// </summary>
        /// <param name="client">An instance of <see cref="TwentyThreeOAuthClient"/>.</param>
        /// <returns>A new instance of <see cref="TwentyThreeHttpService"/>.</returns>
        public static TwentyThreeHttpService CreateFromOAuthClient(TwentyThreeOAuthClient client) {
            if (client == null) throw new ArgumentNullException(nameof(client));
            return new TwentyThreeHttpService(client);
        }

        #endregion

    }

}