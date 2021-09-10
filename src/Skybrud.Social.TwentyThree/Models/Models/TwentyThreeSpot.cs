using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.TwentyThree.Models.Models {

    public class TwentyThreeSpot : TwentyThreeObject {

        #region Properties

        public string Id { get; }

        public string Name { get; }

        public string Type { get; }

        public string Design { get; }

        public string Layout { get; }

        public string Selection { get; }

        public int VideoCount { get; }

        public string Token { get; }

        public string IncludeHtml { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of <see cref="TwentyThreeSpot"/> parsed from the specified <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">The <see cref="JObject"/> to be parsed.</param>
        protected TwentyThreeSpot(JObject obj) : base(obj) {
            Id = obj.GetString("spot_id");
            Name = obj.GetString("spot_name");
            Type = obj.GetString("spot_type");
            Design = obj.GetString("spot_design");
            Layout = obj.GetString("spot_layout");
            Selection = obj.GetString("selection");
            VideoCount = obj.GetInt32("video_count");
            Token = obj.GetString("token");
            IncludeHtml = obj.GetString("include_html");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Gets an instance of <see cref="TwentyThreeSpot"/> from the specified <see cref="JObject"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to parse.</param>
        /// <returns>An instance of <see cref="TwentyThreeSpot"/>.</returns>
        public static TwentyThreeSpot Parse(JObject obj) {
            return obj == null ? null : new TwentyThreeSpot(obj);
        }

        #endregion

    }

}