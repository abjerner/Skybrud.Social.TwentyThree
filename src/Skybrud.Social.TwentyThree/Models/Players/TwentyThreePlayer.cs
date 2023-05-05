using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.TwentyThree.Models.Players {

    /// <summary>
    /// Class representing a TwentyThree player.
    /// </summary>
    public class TwentyThreePlayer : TwentyThreeObject {

        #region Properties

        /// <summary>
        /// Gets the ID of the player.
        /// </summary>
        public string PlayerId { get; }

        /// <summary>
        /// Gets the name of the player.
        /// </summary>
        public string PlayerName { get; }

        /// <summary>
        /// Gets whether the player is the default player.
        /// </summary>
        public bool IsDefault { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of <see cref="TwentyThreePlayer"/> parsed from the specified <paramref name="json"/> object.
        /// </summary>
        /// <param name="json">The <see cref="JObject"/> to be parsed.</param>
        protected TwentyThreePlayer(JObject json) : base(json) {
            PlayerId = json.GetString("player_id")!;
            PlayerName = json.GetString("player_name")!;
            IsDefault = json.GetBoolean("default_p");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Gets an instance of <see cref="TwentyThreePlayer"/> from the specified <paramref name="json"/> object.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> to parse.</param>
        /// <returns>An instance of <see cref="TwentyThreePlayer"/>.</returns>
        public static TwentyThreePlayer? Parse([NotNullIfNotNull(nameof(json))] JObject? json) {
            return json == null ? null : new TwentyThreePlayer(json);
        }

        #endregion

    }

}