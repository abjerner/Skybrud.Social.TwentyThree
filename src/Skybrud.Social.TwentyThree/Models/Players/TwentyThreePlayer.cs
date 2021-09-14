using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.TwentyThree.Models.Players {

    public class TwentyThreePlayer : TwentyThreeObject {

        #region Properties

        public string PlayerId { get; }

        public string PlayerName { get; }

        public bool IsDefault { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of <see cref="TwentyThreePlayer"/> parsed from the specified <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">The <see cref="JObject"/> to be parsed.</param>
        protected TwentyThreePlayer(JObject obj) : base(obj) {
            PlayerId = obj.GetString("player_id");
            PlayerName = obj.GetString("player_name");
            IsDefault = obj.GetBoolean("default_p");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Gets an instance of <see cref="TwentyThreePlayer"/> from the specified <see cref="JObject"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to parse.</param>
        /// <returns>An instance of <see cref="TwentyThreePlayer"/>.</returns>
        public static TwentyThreePlayer Parse(JObject obj) {
            return obj == null ? null : new TwentyThreePlayer(obj);
        }

        #endregion

    }

}