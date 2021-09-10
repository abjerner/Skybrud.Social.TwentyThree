using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.TwentyThree.Models.Sites {

    public class TwentyThreeSite : TwentyThreeObject {

        #region Properties

        public string Domain { get; }

        public string SecureDomain { get; }

        public string SiteName { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of <see cref="TwentyThreeSite"/> parsed from the specified <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">The <see cref="JObject"/> to be parsed.</param>
        protected TwentyThreeSite(JObject obj) : base(obj) {
            Domain = obj.GetString("domain");
            SecureDomain = obj.GetString("secure_domain");
            SiteName = obj.GetString("site_name");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Gets an instance of <see cref="TwentyThreeSite"/> from the specified <see cref="JObject"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to parse.</param>
        /// <returns>An instance of <see cref="TwentyThreeSite"/>.</returns>
        public static TwentyThreeSite Parse(JObject obj) {
            return obj == null ? null : new TwentyThreeSite(obj);
        }

        #endregion

    }

}