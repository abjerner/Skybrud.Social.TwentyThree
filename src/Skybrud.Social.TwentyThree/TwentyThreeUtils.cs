﻿using System;
using System.Diagnostics.CodeAnalysis;
using Skybrud.Essentials.Common;
using Skybrud.Essentials.Strings.Extensions;
using Skybrud.Social.TwentyThree.Models.Photos;
using Skybrud.Social.TwentyThree.Models.Sites;
using Skybrud.Social.TwentyThree.Options;
using Skybrud.Social.TwentyThree.Options.Albums;
using Skybrud.Social.TwentyThree.Options.Embed;
using Skybrud.Social.TwentyThree.Options.Photos;
using Skybrud.Social.TwentyThree.Options.Spots;
using Skybrud.Social.TwentyThree.Options.Tags;

#pragma warning disable CS1591

namespace Skybrud.Social.TwentyThree {

    public static class TwentyThreeUtils {

        public static string? ToString([NotNullIfNotNull(nameof(field))] TwentyThreeAlbumSortField? field) {
            return field switch {
                TwentyThreeAlbumSortField.SortKey => "sortkey",
                _ => field?.ToUnderscore()
            };
        }

        public static string? ToString([NotNullIfNotNull(nameof(field))] TwentyThreeSpotSortField? field) {
            return field?.ToUnderscore();
        }

        public static string? ToString([NotNullIfNotNull(nameof(order))] TwentyThreeSortOrder? order) {
            return order switch {
                TwentyThreeSortOrder.Ascending => "asc",
                TwentyThreeSortOrder.Descending => "desc",
                _ => null
            };
        }

        public static string? ToString([NotNullIfNotNull(nameof(field))] TwentyThreePhotoSortField? field) {
            return field?.ToUnderscore();
        }

        public static string? ToString([NotNullIfNotNull(nameof(type))] TwentyThreeSpotType? type) {
            return type?.ToUnderscore();
        }

        public static string? ToString([NotNullIfNotNull(nameof(field))] TwentyThreeTagSortField? field) {
            return field?.ToUnderscore();
        }

        public static string? ToString(TwentyThreeVideoParameter? video) {
            return video switch {
                TwentyThreeVideoParameter.OnlyVideos => "1",
                TwentyThreeVideoParameter.IgnoreVideos => "0",
                _ => null
            };
        }

        public static string GetEmbedCode(TwentyThreeSite site, TwentyThreePhoto photo) {
            return GetEmbedCode(site.Domain, photo.PhotoId, photo.Token);
        }

        public static string GetEmbedCode(TwentyThreeSite site, TwentyThreePhoto photo, string playerId) {
            return GetEmbedCode(site.Domain, photo.PhotoId, photo.Token, playerId);
        }

        public static string GetEmbedCode(TwentyThreeSite site, TwentyThreePhoto photo, string playerId, bool? autoPlay, TwentyThreePhotoEmbedEndOn endOn) {
            return GetEmbedCode(site.Domain, photo.PhotoId, photo.Token, playerId, autoPlay, endOn);
        }

        public static string GetEmbedCode(TwentyThreePhotoEmbedOptions options) {
            if (options == null) throw new ArgumentNullException(nameof(options));
            if (string.IsNullOrWhiteSpace(options.Domain)) throw new PropertyNotSetException(nameof(options.Domain));
            if (string.IsNullOrWhiteSpace(options.PhotoId)) throw new PropertyNotSetException(nameof(options.PhotoId));
            if (string.IsNullOrWhiteSpace(options.Token)) throw new PropertyNotSetException(nameof(options.Token));
            return GetEmbedCode(options.Domain!, options.PhotoId!, options.Token!, options.PlayerId, options.AutoPlay, options.EndOn);
        }

        public static string GetEmbedCode(string domain, string photoId, string token) {
            return GetEmbedCode(domain, photoId, token, null, null, default);
        }

        public static string GetEmbedCode(string domain, string photoId, string token, string? playerId) {
            return GetEmbedCode(domain, photoId, token, playerId, null, default);
        }

        public static string GetEmbedCode(string domain, string photoId, string token, string? playerId, bool? autoPlay, TwentyThreePhotoEmbedEndOn? endOn) {

            if (string.IsNullOrWhiteSpace(domain)) throw new ArgumentNullException(nameof(domain));
            if (string.IsNullOrWhiteSpace(photoId)) throw new ArgumentNullException(nameof(photoId));
            if (string.IsNullOrWhiteSpace(token)) throw new ArgumentNullException(nameof(token));

            if (string.IsNullOrWhiteSpace(playerId)) playerId = "v";

            // Generate the mandatory parts of the URL
            string url = $"//{domain}/{playerId}.ihtml/player.html?token={token}&source=embed&photo%5fid={photoId}";

            if (autoPlay != null) url += "&autoPlay=1";
            if (endOn != default) url += $"&endOn={endOn!.ToLower()}";

            return $"<div style=\"width:100%; height:0; position: relative; padding-bottom:100.0%\"><iframe src=\"{url}\" style=\"width:100%; height:100%; position: absolute; top: 0; left: 0;\" frameborder=\"0\" border=\"0\" scrolling=\"no\" mozallowfullscreen=\"1\" webkitallowfullscreen=\"1\" allowfullscreen=\"1\" allow=\"autoplay; fullscreen\"></iframe></div>";

        }

    }

}