using System;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Essentials.Time;
using Skybrud.Social.TwentyThree.Exceptions;

namespace Skybrud.Social.TwentyThree.Extensions {

    internal static class TwentyThreeExtensions {

        #region Member methods

        public static EssentialsTime? GetTimestamp(this JObject? json, string property) {
            try {
                return json.GetDouble(property, EssentialsTime.FromUnixTimeSeconds);
            } catch (Exception ex) {
                throw new TwentyThreeParseException($"Failed parsing timestamp from '{property}' property.", ex);
            }
        }

        #endregion

    }

}