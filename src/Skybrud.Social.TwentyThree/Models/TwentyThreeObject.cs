using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft;

namespace Skybrud.Social.TwentyThree.Models {

    /// <summary>
    /// Class representing a basic object from the TwentyThree API derived from an instance of <see cref="JObject"/>.
    /// </summary>
    public class TwentyThreeObject : JsonObjectBase {

        #region Constructor

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="json"/> object.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> representing the object.</param>
        protected TwentyThreeObject(JObject json) : base(json) { }

        #endregion

    }

}