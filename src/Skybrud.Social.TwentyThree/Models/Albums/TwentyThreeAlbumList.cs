using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.TwentyThree.Models.Albums {

    /// <summary>
    /// Class representing a paginated list of <see cref="TwentyThreeAlbum"/>.
    /// </summary>
    public class TwentyThreeAlbumList : TwentyThreeList {

        #region Properties

        /// <summary>
        /// Gets a reference to the individual albums of the list.
        /// </summary>
        public IReadOnlyList<TwentyThreeAlbum> Albums { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of <see cref="TwentyThreeAlbumList"/> parsed from the specified <paramref name="json"/> object.
        /// </summary>
        /// <param name="json">The <see cref="JObject"/> to be parsed.</param>
        protected TwentyThreeAlbumList(JObject json) : base(json) {
            Albums = json.GetArrayItems("albums", TwentyThreeAlbum.Parse)!;
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Returns an instance of <see cref="TwentyThreeAlbumList"/> from the specified <paramref name="json"/> object.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> to parse.</param>
        /// <returns>An instance of <see cref="TwentyThreeAlbumList"/>.</returns>
        public static TwentyThreeAlbumList? Parse([NotNullIfNotNull(nameof(json))] JObject? json) {
            return json == null ? null : new TwentyThreeAlbumList(json);
        }

        #endregion

    }

}