namespace Skybrud.Social.TwentyThree.Options.Photos {

    /// <summary>
    /// Enum class representing the tag mode when getting a list of photos.
    /// </summary>
    /// <remarks>TwentyThree's API documentation is a ambigious or contradictory, and only describes the values
    /// <c>and</c> and <c>all</c>, which seems to mean the same. The API also seems to support <c>or</c> and
    /// <c>any</c>.</remarks>
    /// <see>
    ///     <cref>https://www.twentythree.com/api/photo-list</cref>
    /// </see>
    public enum TwentyThreePhotoTagMode {

        /// <summary>
        /// Indicates that only photos matching all the specified tags should be returned.
        /// </summary>
        And,

        /// <summary>
        /// Indicates that photos maching at least one of the specified tags should be returned.
        /// </summary>
        Or

    }

}