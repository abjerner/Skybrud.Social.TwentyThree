using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft.Extensions;

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

        /// <summary>
        /// Gets the key (alias) of the site.
        /// </summary>
        public string SiteKey { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of <see cref="TwentyThreeSite"/> parsed from the specified <paramref name="json"/> object.
        /// </summary>
        /// <param name="json">The <see cref="JObject"/> to be parsed.</param>
        protected TwentyThreeSite(JObject json) : base(json) {
            SiteId = json.GetRequiredString("site_id");
            Domain = json.GetRequiredString("domain");
            SecureDomain = json.GetRequiredString("secure_domain");
            SiteName = json.GetRequiredString("site_name");
            SiteKey = json.GetRequiredString("site_key");
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