using Skybrud.Essentials.Http;
using Skybrud.Essentials.Http.Collections;
using Skybrud.Essentials.Http.Options;

#pragma warning disable CS1591

namespace Skybrud.Social.TwentyThree.Options.Spots {

    /// <summary>
    /// Options for getting a list of spots.
    /// </summary>
    /// <see>
    ///     <cref>https://www.twentythree.com/api/spot-list</cref>
    /// </see>
    public class TwentyThreeGetSpotsOptions : IHttpRequestOptions {

        #region Properties

        public string? SpotId { get; set; }

        public string? Token { get; set; }

        public TwentyThreeSpotType? SpotType { get; set; }

        public TwentyThreeSpotSortField? OrderBy { get; set; }

        public TwentyThreeSortOrder? Order { get; set; }

        public int? Page { get; set; }

        public int? Size { get; set; }

        #endregion

        #region Constructors

        public TwentyThreeGetSpotsOptions() { }

        public TwentyThreeGetSpotsOptions(string spotId) {
            SpotId = spotId;
        }

        #endregion

        #region Member methods

        public virtual IHttpRequest GetRequest() {

            IHttpQueryString query = new HttpQueryString();

            if (string.IsNullOrWhiteSpace(SpotId) == false) query.Add("spot_id", SpotId!);
            if (string.IsNullOrWhiteSpace(Token) == false) query.Add("token", Token!);

            if (SpotType is not null) query.Add("spot_type", TwentyThreeUtils.ToString(SpotType)!);
            if (OrderBy is not null) query.Add("orderby", TwentyThreeUtils.ToString(OrderBy)!);
            if (Order is not null) query.Add("order", TwentyThreeUtils.ToString(Order)!);

            if (Page is not null) query.Add("p", Page);
            if (Size is not null) query.Add("size", Size);

            return HttpRequest.Get("/api/spot/list", query);

        }

        #endregion

    }

}