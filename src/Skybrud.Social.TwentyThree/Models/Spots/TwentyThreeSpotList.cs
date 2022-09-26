using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Social.TwentyThree.Models.Photos;

namespace Skybrud.Social.TwentyThree.Models.Spots {

    /// <summary>
    /// Class representing a paginated list of <see cref="TwentyThreeSpot"/>.
    /// </summary>
    public class TwentyThreeSpotList : TwentyThreeList {

        #region Properties

        /// <summary>
        /// Gets a reference to the individual spots of the list.
        /// </summary>
        public IReadOnlyList<TwentyThreeSpot> Spots { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of <see cref="TwentyThreePhotoList"/> parsed from the specified <paramref name="json"/> object.
        /// </summary>
        /// <param name="json">The <see cref="JObject"/> to be parsed.</param>
        protected TwentyThreeSpotList(JObject json) : base(json) {
            Spots = json.GetObjectArray("spots", TwentyThreeSpot.Parse);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Gets an instance of <see cref="TwentyThreeSpotList"/> from the specified <paramref name="json"/> object.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> to parse.</param>
        /// <returns>An instance of <see cref="TwentyThreeSpotList"/>.</returns>
        public static TwentyThreeSpotList Parse(JObject json) {
            return json == null ? null : new TwentyThreeSpotList(json);
        }

        #endregion

    }

}