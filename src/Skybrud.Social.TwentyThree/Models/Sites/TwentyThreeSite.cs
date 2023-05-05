using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.TwentyThree.Models.Sites {

    /// <summary>
    /// Class representing a TwentyThree site.
    /// </summary>
    public class TwentyThreeSite : TwentyThreeObject {

        #region Properties

        /// <summary>
        /// Gets the ID of the site.
        /// </summary>
        public string SiteId { get; }

        /// <summary>
        /// Gets the domain of the site.
        /// </summary>
        public string Domain { get; }

        /// <summary>
        /// Gets the secure domain of the site.
        /// </summary>
        public string SecureDomain { get; }

        /// <summary>
        /// Gets the name of the site.
        /// </summary>
        public string SiteName { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of <see cref="TwentyThreeSite"/> parsed from the specified <paramref name="json"/> object.
        /// </summary>
        /// <param name="json">The <see cref="JObject"/> to be parsed.</param>
        protected TwentyThreeSite(JObject json) : base(json) {
            SiteId = json.GetString("site_id")!;
            Domain = json.GetString("domain")!;
            SecureDomain = json.GetString("secure_domain")!;
            SiteName = json.GetString("site_name")!;
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Gets an instance of <see cref="TwentyThreeSite"/> from the specified <paramref name="json"/> object.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> to parse.</param>
        /// <returns>An instance of <see cref="TwentyThreeSite"/>.</returns>
        public static TwentyThreeSite? Parse([NotNullIfNotNull(nameof(json))] JObject? json) {
            return json == null ? null : new TwentyThreeSite(json);
        }

        #endregion

    }

}