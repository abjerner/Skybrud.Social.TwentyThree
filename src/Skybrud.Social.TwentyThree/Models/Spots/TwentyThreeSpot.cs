using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

#pragma warning disable CS1591

namespace Skybrud.Social.TwentyThree.Models.Spots {

    /// <summary>
    /// Class representing a TwentyThree spot.
    /// </summary>
    public class TwentyThreeSpot : TwentyThreeObject {

        #region Properties

        public string SpotId { get; }

        public string SpotName { get; }

        public string SpotType { get; }

        public string SpotDesign { get; }

        public string SpotLayout { get; }

        public string SpotSelection { get; }

        public int VideoCount { get; }

        public string Token { get; }

        public string IncludeHtml { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of <see cref="TwentyThreeSpot"/> parsed from the specified <paramref name="json"/> object.
        /// </summary>
        /// <param name="json">The <see cref="JObject"/> to be parsed.</param>
        protected TwentyThreeSpot(JObject json) : base(json) {
            SpotId = json.GetString("spot_id")!;
            SpotName = json.GetString("spot_name")!;
            SpotType = json.GetString("spot_type")!;
            SpotDesign = json.GetString("spot_design")!;
            SpotLayout = json.GetString("spot_layout")!;
            SpotSelection = json.GetString("spot_selection")!;
            VideoCount = json.GetInt32("video_count");
            Token = json.GetString("token")!;
            IncludeHtml = json.GetString("include_html")!;
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Gets an instance of <see cref="TwentyThreeSpot"/> from the specified <paramref name="json"/> object.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> to parse.</param>
        /// <returns>An instance of <see cref="TwentyThreeSpot"/>.</returns>
        public static TwentyThreeSpot? Parse([NotNullIfNotNull(nameof(json))] JObject? json) {
            return json == null ? null : new TwentyThreeSpot(json);
        }

        #endregion

    }

}