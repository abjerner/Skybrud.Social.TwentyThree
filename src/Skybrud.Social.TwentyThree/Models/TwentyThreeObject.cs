using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft;

namespace Skybrud.Social.TwentyThree.Models {

    /// <summary>
    /// Class representing a basic object from the TwentyThree API derived from an instance of <see cref="JObject"/>.
    /// </summary>
    public class TwentyThreeObject : JsonObjectBase {

        #region Properties

        /// <summary>
        /// Gets the internal <see cref="JObject"/> the object was created from.
        /// </summary>
        /// <remarks>This property is known not to be <see langword="null"/>, even though the parent <see cref="JsonObjectBase.JObject"/> property may be <see langword="null"/> in other cases.</remarks>
        public new JObject JObject => base.JObject!;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="json"/> object.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> representing the object.</param>
        protected TwentyThreeObject(JObject json) : base(json) { }

        #endregion

    }

}