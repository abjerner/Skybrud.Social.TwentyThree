using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.TwentyThree.Models.Photos {

    public class TwentyThreeThumbnail {

        #region Properties

        public string Alias { get; }

        public int Width { get; }

        public int Height { get; }

        public long Size { get; }

        public string Url { get; }

        #endregion

        #region Constructors

        protected TwentyThreeThumbnail(JObject obj, string prefix) {
            Alias = prefix;
            Width = obj.GetInt32(prefix + "_width");
            Height = obj.GetInt32(prefix + "_height");
            Size = obj.GetInt64(prefix + "_size");
            Url = obj.GetString(prefix + "_download");
        }

        #endregion

        #region Static methods

        public static TwentyThreeThumbnail Parse(JObject obj, string prefix) {
            if (obj == null) return null;
            if (obj.HasValue(prefix + "_download") == false) return null;
            return new TwentyThreeThumbnail(obj, prefix);
        }

        #endregion

    }

}