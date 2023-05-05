using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.TwentyThree.Models.Albums {

    /// <summary>
    /// Class representing a TwentyThree album.
    /// </summary>
    public class TwentyThreeAlbum : TwentyThreeObject {

        #region Properties

        /// <summary>
        /// Gets the ID of the album.
        /// </summary>
        public string AlbumId { get; }

        /// <summary>
        /// Gets the title of the album.
        /// </summary>
        public string Title { get; }

        /// <summary>
        /// Gets the token of the album.
        /// </summary>
        public string Token { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of <see cref="TwentyThreeAlbum"/> parsed from the specified <paramref name="json"/>.
        /// </summary>
        /// <param name="json">The <see cref="JObject"/> to be parsed.</param>
        protected TwentyThreeAlbum(JObject json) : base(json) {
            AlbumId = json.GetString("album_id")!;
            Title = json.GetString("title")!;
            Token = json.GetString("token")!;
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Returns an instance of <see cref="TwentyThreeAlbum"/> from the specified <paramref name="json"/> object.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> to parse.</param>
        /// <returns>An instance of <see cref="TwentyThreeAlbum"/>.</returns>
        public static TwentyThreeAlbum? Parse([NotNullIfNotNull(nameof(json))] JObject? json) {
            return json == null ? null : new TwentyThreeAlbum(json);
        }

        #endregion

    }

}