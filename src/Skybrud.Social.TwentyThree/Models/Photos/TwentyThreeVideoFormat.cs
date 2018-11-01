using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.TwentyThree.Models.Photos {

    public class TwentyThreeVideoFormat {

        #region Properties

        public string Alias { get; }

        public int Width { get; }

        public int Height { get; }

        public long Size { get; }

        public string Url { get; }

        #endregion

        #region Constructors

        protected TwentyThreeVideoFormat(JObject obj, string prefix) {
            Alias = prefix;
            Width = obj.GetInt32(prefix + "_width");
            Height = obj.GetInt32(prefix + "_height");
            Size = obj.GetInt64(prefix + "_size");
            Url = obj.GetString(prefix + "_download");
        }

        #endregion

        #region Static methods

        public static TwentyThreeVideoFormat Parse(JObject obj, string prefix) {
            if (obj == null) return null;
            if (obj.HasValue(prefix + "_download") == false) return null;
            return new TwentyThreeVideoFormat(obj, prefix);
        }

        #endregion

    }

}