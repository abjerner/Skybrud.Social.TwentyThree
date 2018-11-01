using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.TwentyThree.Models {

    public class TwentyThreeError : JsonObjectBase {

        #region Properties

        public string Status { get; }

        public string Message { get; }

        public string Code { get; }

        public string PermissionLevel { get; }

        public string Endpoint { get; }

        #endregion

        #region Constructor

        protected TwentyThreeError(JObject obj) : base(obj) {
            Status = obj.GetString("status");
            Message = obj.GetString("message");
            Code = obj.GetString("code");
            PermissionLevel = obj.GetString("permission_level");
            Endpoint = obj.GetString("endpoint");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Gets an instance of <see cref="TwentyThreeError"/> from the specified <see cref="JObject"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to parse.</param>
        /// <returns>An instance of <see cref="TwentyThreeError"/>.</returns>
        public static TwentyThreeError Parse(JObject obj) {
            return obj == null ? null : new TwentyThreeError(obj);
        }

        #endregion

    }

}