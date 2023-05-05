using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft;
using Skybrud.Essentials.Json.Extensions;

#pragma warning disable CS1591

namespace Skybrud.Social.TwentyThree.Models {

    /// <summary>
    /// Class representing an error received from the TwentyThree API.
    /// </summary>
    public class TwentyThreeError : JsonObjectBase {

        #region Properties

        public string Status { get; }

        public string Message { get; }

        public string Code { get; }

        public string PermissionLevel { get; }

        public string Endpoint { get; }

        #endregion

        #region Constructor

        protected TwentyThreeError(JObject json) : base(json) {
            Status = json.GetString("status");
            Message = json.GetString("message");
            Code = json.GetString("code");
            PermissionLevel = json.GetString("permission_level");
            Endpoint = json.GetString("endpoint");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Gets an instance of <see cref="TwentyThreeError"/> from the specified <paramref name="json"/> object.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> to parse.</param>
        /// <returns>An instance of <see cref="TwentyThreeError"/>.</returns>
        public static TwentyThreeError Parse(JObject json) {
            return json == null ? null : new TwentyThreeError(json);
        }

        #endregion

    }

}