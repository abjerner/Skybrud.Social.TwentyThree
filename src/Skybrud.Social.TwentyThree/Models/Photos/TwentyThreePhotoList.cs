using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Social.TwentyThree.Models.Sites;

namespace Skybrud.Social.TwentyThree.Models.Photos {

    public class TwentyThreePhotoList : TwentyThreeObject {

        #region Properties

        public TwentyThreePhoto[] Photos { get; }

        public int Page { get; }

        public int Size { get; }

        public int Offset { get; }

        public int TotalCount { get; }

        public TwentyThreeSite Site { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of <see cref="TwentyThreePhotoList"/> parsed from the specified <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">The <see cref="JObject"/> to be parsed.</param>
        protected TwentyThreePhotoList(JObject obj) : base(obj) {
            Photos = obj.GetObjectArray("photos", TwentyThreePhoto.Parse);
            Page = obj.GetInt32("p");
            Size = obj.GetInt32("size");
            Offset = obj.GetInt32("offset");
            TotalCount = obj.GetInt32("total_count");
            Site = obj.GetObject("site", TwentyThreeSite.Parse);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Gets an instance of <see cref="TwentyThreePhotoList"/> from the specified <see cref="JObject"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to parse.</param>
        /// <returns>An instance of <see cref="TwentyThreePhotoList"/>.</returns>
        public static TwentyThreePhotoList Parse(JObject obj) {
            return obj == null ? null : new TwentyThreePhotoList(obj);
        }

        #endregion

    }

}