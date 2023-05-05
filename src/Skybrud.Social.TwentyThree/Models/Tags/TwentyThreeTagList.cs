using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Social.TwentyThree.Models.Photos;

namespace Skybrud.Social.TwentyThree.Models.Tags {

    /// <summary>
    /// Class representing a paginated list of <see cref="TwentyThreeTag"/>.
    /// </summary>
    public class TwentyThreeTagList : TwentyThreeList {

        #region Properties

        /// <summary>
        /// Gets a reference to the individual tags of the list.
        /// </summary>
        public IReadOnlyList<TwentyThreeTag> Tags { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of <see cref="TwentyThreePhotoList"/> parsed from the specified <paramref name="json"/> object.
        /// </summary>
        /// <param name="json">The <see cref="JObject"/> to be parsed.</param>
        protected TwentyThreeTagList(JObject json) : base(json) {
            Tags = json.GetArrayItems("tags", TwentyThreeTag.Parse)!;
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Gets an instance of <see cref="TwentyThreeTagList"/> from the specified <paramref name="json"/> object.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> to parse.</param>
        /// <returns>An instance of <see cref="TwentyThreeTagList"/>.</returns>
        public static TwentyThreeTagList? Parse([NotNullIfNotNull(nameof(json))] JObject? json) {
            return json == null ? null : new TwentyThreeTagList(json);
        }

        #endregion

    }

}