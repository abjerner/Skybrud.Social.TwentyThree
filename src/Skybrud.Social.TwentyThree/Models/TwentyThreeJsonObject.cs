using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json;

namespace Skybrud.Social.TwentyThree.Models {

    /// <summary>
    /// Class representing a basic object from the Twenty Three API derived from an instance of <see cref="JObject"/>.
    /// </summary>
    public class TwentyThreeObject : JsonObjectBase {

        #region Constructor

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> representing the object.</param>
        protected TwentyThreeObject(JObject obj) : base(obj) { }

        #endregion

    }

}