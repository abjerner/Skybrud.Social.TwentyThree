using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.TwentyThree.Models.Photos {

    /// <summary>
    /// Class representing a video format of a <see cref="TwentyThreePhoto"/>.
    /// </summary>
    public class TwentyThreeVideoFormat {

        #region Properties

        /// <summary>
        /// Gets the alias of the video format.
        /// </summary>
        public string Alias { get; }

        /// <summary>
        /// Gets the width of the video format.
        /// </summary>
        public int Width { get; }

        /// <summary>
        /// Gets the height of the video format.
        /// </summary>
        public int Height { get; }

        /// <summary>
        /// Gets the size of the video format.
        /// </summary>
        public long Size { get; }

        /// <summary>
        /// Gets the URL of the video format.
        /// </summary>
        public string Url { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of <see cref="TwentyThreeVideoFormat"/> parsed from the specified <paramref name="json"/> object.
        /// </summary>
        /// <param name="json">The <see cref="JObject"/> to be parsed.</param>
        /// <param name="prefix">The prefix pf the underlying JSON property.</param>
        protected TwentyThreeVideoFormat(JObject json, string prefix) {
            Alias = prefix;
            Width = json.GetInt32(prefix + "_width");
            Height = json.GetInt32(prefix + "_height");
            Size = json.GetInt64(prefix + "_size");
            Url = json.GetString(prefix + "_download");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Returns an instance of <see cref="TwentyThreeVideoFormat"/> from the specified <paramref name="json"/> object.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> to parse.</param>
        /// <param name="prefix">The prefix pf the underlying JSON property.</param>
        /// <returns>An instance of <see cref="TwentyThreeVideoFormat"/>.</returns>
        public static TwentyThreeVideoFormat Parse(JObject json, string prefix) {
            if (json == null) return null;
            if (json.HasValue(prefix + "_download") == false) return null;
            return new TwentyThreeVideoFormat(json, prefix);
        }

        #endregion

    }

}