using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Social.TwentyThree.Models.Models;

namespace Skybrud.Social.TwentyThree.Models.Photos {

    public class TwentyThreeSpotList : TwentyThreeObject {

        #region Properties

        public TwentyThreeSpot[] Spots { get; }

        public int Page { get; }

        public int Size { get; }

        public int Offset { get; }

        public int TotalCount { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of <see cref="TwentyThreePhotoList"/> parsed from the specified <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">The <see cref="JObject"/> to be parsed.</param>
        protected TwentyThreeSpotList(JObject obj) : base(obj) {
            Spots = obj.GetObjectArray("spots", TwentyThreeSpot.Parse);
            Page = obj.GetInt32("p");
            Size = obj.GetInt32("size");
            Offset = obj.GetInt32("offset");
            TotalCount = obj.GetInt32("total_count");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Gets an instance of <see cref="TwentyThreeSpotList"/> from the specified <see cref="JObject"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to parse.</param>
        /// <returns>An instance of <see cref="TwentyThreeSpotList"/>.</returns>
        public static TwentyThreeSpotList Parse(JObject obj) {
            return obj == null ? null : new TwentyThreeSpotList(obj);
        }

        #endregion

    }

}