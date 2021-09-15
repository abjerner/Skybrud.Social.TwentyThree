using Skybrud.Essentials.Collections;
using Skybrud.Essentials.Http;
using Skybrud.Essentials.Http.Collections;
using Skybrud.Essentials.Http.Options;
using Skybrud.Essentials.Strings.Extensions;

namespace Skybrud.Social.TwentyThree.Options.Spots {
    
    /// <summary>
    /// Options for getting a list of spots.
    /// </summary>
    /// <see>
    ///     <cref>https://www.twentythree.com/api/spot-list</cref>
    /// </see>
    public class TwentyThreeGetSpotsOptions : IHttpRequestOptions {

        #region Properties

        public string SpotId { get; set; }

        public string Token { get; set; }

        public TwentyThreeSpotType SpotType { get; set; }

        public TwentyThreeSpotSortField OrderBy { get; set; }

        public TwentyThreeSortOrder Order { get; set; }

        public int Page { get; set; }

        public int Size { get; set; }

        #endregion

        #region Constructors

        public TwentyThreeGetSpotsOptions() { }

        public TwentyThreeGetSpotsOptions(string spotId) {
            SpotId = spotId;
        }

        #endregion

        #region Member methods

        public IHttpRequest GetRequest() {
            
            IHttpQueryString query = new HttpQueryString();

            if (string.IsNullOrWhiteSpace(SpotId) == false) query.Add("spot_id", SpotId);
            if (string.IsNullOrWhiteSpace(Token) == false) query.Add("token", Token);

            switch (SpotType) {
                case TwentyThreeSpotType.Page:
                    query.Add("spot_type", "page");
                    break;
                case TwentyThreeSpotType.Widget:
                    query.Add("spot_type", "widget");
                    break;
            }

            if (OrderBy != default) query.Add("orderby", TwentyThreeUtils.ToString(OrderBy));
            if (Order != default) query.Add("order", TwentyThreeUtils.ToString(Order));

            if (Page > 0) query.Add("p", Page);
            if (Size > 0) query.Add("size", Size);

            return HttpRequest.Get("/api/spot/list", query);

        }

        #endregion

    }

}