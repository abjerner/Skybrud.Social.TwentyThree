using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Social.TwentyThree.Models.Photos;
using Skybrud.Social.TwentyThree.Models.Sites;

namespace Skybrud.Social.TwentyThree.Models {

    /// <summary>
    /// Class representing a paginated list.
    /// </summary>
    public class TwentyThreeList : TwentyThreeObject {

        #region Properties

        /// <summary>
        /// Gets the page number of the list.
        /// </summary>
        public int Page { get; }

        /// <summary>
        /// Gets the size of the list (maximum amount of items returned per page).
        /// </summary>
        public int Size { get; }

        /// <summary>
        /// Gets the current offset of the list.
        /// </summary>
        public int Offset { get; }

        /// <summary>
        /// Gets the total amount of items in the list.
        /// </summary>
        public int TotalCount { get; }

        /// <summary>
        /// Gets a reference to the parent site.
        /// </summary>
        public TwentyThreeSite Site { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of <see cref="TwentyThreePhotoList"/> parsed from the specified <paramref name="json"/> object.
        /// </summary>
        /// <param name="json">The <see cref="JObject"/> to be parsed.</param>
        protected TwentyThreeList(JObject json) : base(json) {
            Page = json.GetInt32("p");
            Size = json.GetInt32("size");
            Offset = json.GetInt32("offset");
            TotalCount = json.GetInt32("total_count");
            Site = json.GetObject("site", TwentyThreeSite.Parse)!;
        }

        #endregion

    }

}