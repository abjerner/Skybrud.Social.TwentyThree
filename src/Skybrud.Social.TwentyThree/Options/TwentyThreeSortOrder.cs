namespace Skybrud.Social.TwentyThree.Options {
    
    public enum TwentyThreeSortOrder {

        /// <summary>
        /// Indicates that the sort order isn't specified when calling the Twenty Three API, leaving the sort order up to the API default.
        /// </summary>
        Unspecified,

        /// <summary>
        /// Indicates that results should be sorted in asscending order.
        /// </summary>
        Ascending,
        
        /// <summary>
        /// Indicates that results should be sorted in descending order.
        /// </summary>
        Descending

    }

}