using Skybrud.Essentials.Collections;
using Skybrud.Essentials.Http;
using Skybrud.Essentials.Http.Collections;
using Skybrud.Essentials.Http.Options;

namespace Skybrud.Social.TwentyThree.Options.Tags {

    /// <summary>
    /// Class representing the options for getting a list of tags.
    /// </summary>
    /// <see>
    ///     <cref>https://www.twentythree.com/api/tag-list</cref>
    /// </see>
    public class TwentyThreeGetTagsOptions : IHttpRequestOptions {

        #region Properties

        /// <summary>
        /// Gets or sets a search term the returned tags should match.
        /// </summary>
        public string? Search { get; set; }

        /// <summary>
        /// Gets or sets the field by which the tags should be sorted.
        /// </summary>
        public TwentyThreeTagSortField? OrderBy { get; set; }

        /// <summary>
        /// Gets or sets the order in which the tags should be sorted.
        /// </summary>
        public TwentyThreeSortOrder? Order { get; set; }

        /// <summary>
        /// Gets or sets the page offset of the request.
        /// </summary>
        public int? Page { get; set; }

        /// <summary>
        /// Gets or sets the maximum amount of tags to returned per page.
        /// </summary>
        public int? Size { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initialize a new instance with default options.
        /// </summary>
        public TwentyThreeGetTagsOptions() { }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="page"/> and <paramref name="size"/>.
        /// </summary>
        /// <param name="page">The page to be returned.</param>
        /// <param name="size">The maximum amount of tags to be returned on each page.</param>
        public TwentyThreeGetTagsOptions(int? page, int? size) {
            Page = page;
            Size = size;
        }

        /// <summary>
        /// Initializes a new instance based on the specified parameters.
        /// </summary>
        /// <param name="page">The page to be returned.</param>
        /// <param name="size">The maximum amount of tags to be returned on each page.</param>
        /// <param name="orderBy">The field by which the tags should be sorted.</param>
        /// <param name="order">The order in which the tags should be sorted.</param>
        public TwentyThreeGetTagsOptions(int? page, int? size, TwentyThreeTagSortField? orderBy, TwentyThreeSortOrder? order) {
            Page = page;
            Size = size;
            OrderBy = orderBy;
            Order = order;
        }

        /// <summary>
        /// Initializes a new instance based on the specified parameters.
        /// </summary>
        /// <param name="orderBy">The field by which the tags should be sorted.</param>
        /// <param name="order">The order in which the tags should be sorted.</param>
        public TwentyThreeGetTagsOptions(TwentyThreeTagSortField? orderBy, TwentyThreeSortOrder? order) {
            OrderBy = orderBy;
            Order = order;
        }

        #endregion

        #region Member methods

        /// <inheritdoc />
        public IHttpRequest GetRequest() {

            IHttpQueryString query = new HttpQueryString();

            if (string.IsNullOrWhiteSpace(Search) == false) query.Add("search", Search!);

            if (OrderBy is not null) query.Add("orderby", TwentyThreeUtils.ToString(OrderBy)!);
            if (Order is not null) query.Add("order", TwentyThreeUtils.ToString(Order)!);

            if (Page is not null) query.Add("p", Page);
            if (Size is not null) query.Add("size", Size);

            // Initialize a new request
            return HttpRequest.Get("/api/tag/list", query);

        }

        #endregion


    }

}