using Skybrud.Essentials.Strings.Extensions;
using Skybrud.Social.TwentyThree.Options;
using Skybrud.Social.TwentyThree.Options.Albums;
using Skybrud.Social.TwentyThree.Options.Photos;

namespace Skybrud.Social.TwentyThree {
    
    public static class TwentyThreeUtils {

        public static string ToString(TwentyThreeSortOrder order) {
            return order switch {
                TwentyThreeSortOrder.Ascending => "asc",
                TwentyThreeSortOrder.Descending => "desc",
                _ => null
            };
        }

        public static string ToString(TwentyThreeAlbumSortField field) {
            return field switch {
                TwentyThreeAlbumSortField.SortKey => "sortkey",
                _ => field.ToUnderscore()
            };
        }

        public static object ToString(TwentyThreeSortOrder? order) {
            return order switch {
                TwentyThreeSortOrder.Ascending => "asc",
                TwentyThreeSortOrder.Descending => "desc",
                _ => null
            };
        }

        public static object ToString(TwentyThreePhotoSortField? field) {
            return field?.ToUnderscore();
        }

    }

}