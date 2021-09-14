using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.TwentyThree.Models.Albums {

    public class TwentyThreeAlbum : TwentyThreeObject {

        #region Properties

        public string AlbumId { get; }

        public string Title { get; }

        public string Token { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of <see cref="TwentyThreeAlbum"/> parsed from the specified <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">The <see cref="JObject"/> to be parsed.</param>
        protected TwentyThreeAlbum(JObject obj) : base(obj) {
            AlbumId = obj.GetString("album_id");
            Title = obj.GetString("title");
            Token = obj.GetString("token");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Gets an instance of <see cref="TwentyThreeAlbum"/> from the specified <see cref="JObject"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to parse.</param>
        /// <returns>An instance of <see cref="TwentyThreeAlbum"/>.</returns>
        public static TwentyThreeAlbum Parse(JObject obj) {
            return obj == null ? null : new TwentyThreeAlbum(obj);
        }

        #endregion

    }

}