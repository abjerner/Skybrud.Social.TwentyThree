using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Social.TwentyThree.Models.Photos;

namespace Skybrud.Social.TwentyThree.Models.Players {

    /// <summary>
    /// Class representing a paginated list of <see cref="TwentyThreePlayer"/>.
    /// </summary>
    public class TwentyThreePlayerList : TwentyThreeList {

        #region Properties

        /// <summary>
        /// Gets a reference to the individual players of the list.
        /// </summary>
        public IReadOnlyList<TwentyThreePlayer> Players { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of <see cref="TwentyThreePhotoList"/> parsed from the specified <paramref name="json"/> object.
        /// </summary>
        /// <param name="json">The <see cref="JObject"/> to be parsed.</param>
        protected TwentyThreePlayerList(JObject json) : base(json) {
            Players = json.GetObjectArray("players", TwentyThreePlayer.Parse)!;
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Gets an instance of <see cref="TwentyThreePlayerList"/> from the specified <paramref name="json"/> object.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> to parse.</param>
        /// <returns>An instance of <see cref="TwentyThreePlayerList"/>.</returns>
        public static TwentyThreePlayerList? Parse([NotNullIfNotNull(nameof(json))] JObject? json) {
            return json == null ? null : new TwentyThreePlayerList(json);
        }

        #endregion

    }

}