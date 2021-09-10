using System;
using Skybrud.Social.TwentyThree.Endpoints;
using Skybrud.Social.TwentyThree.OAuth;

namespace Skybrud.Social.TwentyThree {

    public class TwentyThreeHttpService {

        #region Properties

        /// <summary>
        /// Gets a reference to the underlying OAuth client.
        /// </summary>
        public TwentyThreeOAuthClient Client { get; }

        /// <summary>
        /// Gets a reference to the <strong>Photos</strong> endpoint.
        /// </summary>
        public TwentyThreePhotosEndpoint Photos { get; }

        /// <summary>
        /// Gets a reference to the <strong>Spots</strong> endpoint.
        /// </summary>
        public TwentyThreeSpotsEndpoint Spots { get; }

        #endregion

        #region Constructors

        private TwentyThreeHttpService(TwentyThreeOAuthClient client) {

            // Set the client
            Client = client;
            
            // Set the endpoints etc.
            Photos = new TwentyThreePhotosEndpoint(this);
            Spots = new TwentyThreeSpotsEndpoint(this);

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