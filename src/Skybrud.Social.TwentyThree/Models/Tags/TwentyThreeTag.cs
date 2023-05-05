using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

#pragma warning disable CS1591

namespace Skybrud.Social.TwentyThree.Models.Tags {

    /// <summary>
    /// Class representing a TwentyThree tag.
    /// </summary>
    public class TwentyThreeTag : TwentyThreeObject {

        #region Properties

        public string Tag { get; }

        public int Count { get; }

        public string Url { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of <see cref="TwentyThreeTag"/> parsed from the specified <paramref name="json"/> object.
        /// </summary>
        /// <param name="json">The <see cref="JObject"/> to be parsed.</param>
        protected TwentyThreeTag(JObject json) : base(json) {
            Tag = json.GetString("tag")!;
            Count = json.GetInt32("count");
            Url = json.GetString("url")!;
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Gets an instance of <see cref="TwentyThreeTag"/> from the specified <paramref name="json"/> object.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> to parse.</param>
        /// <returns>An instance of <see cref="TwentyThreeTag"/>.</returns>
        public static TwentyThreeTag? Parse([NotNullIfNotNull(nameof(json))] JObject? json) {
            return json == null ? null : new TwentyThreeTag(json);
        }

        #endregion

    }

}