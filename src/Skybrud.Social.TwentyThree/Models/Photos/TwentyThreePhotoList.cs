using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.TwentyThree.Models.Photos {

    /// <summary>
    /// Class representing a paginated list of <see cref="TwentyThreePhoto"/>.
    /// </summary>
    public class TwentyThreePhotoList : TwentyThreeList {

        #region Properties

        /// <summary>
        /// Gets a reference to the individual photos of the list.
        /// </summary>
        public IReadOnlyList<TwentyThreePhoto> Photos { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of <see cref="TwentyThreePhotoList"/> parsed from the specified <paramref name="json"/> object.
        /// </summary>
        /// <param name="json">The <see cref="JObject"/> to be parsed.</param>
        protected TwentyThreePhotoList(JObject json) : base(json) {
            Photos = json.GetObjectArray("photos", TwentyThreePhoto.Parse)!;
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Gets an instance of <see cref="TwentyThreePhotoList"/> from the specified <paramref name="json"/> object.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> to parse.</param>
        /// <returns>An instance of <see cref="TwentyThreePhotoList"/>.</returns>
        public static TwentyThreePhotoList? Parse([NotNullIfNotNull(nameof(json))] JObject? json) {
            return json == null ? null : new TwentyThreePhotoList(json);
        }

        #endregion

    }

}