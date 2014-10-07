using System;
using System.Linq;
using HackerNewsSharp.Models;
using HackerNewsSharp.Responses;

namespace HackerNewsSharp.Mapping
{
    public static class Mapper
    {
        public static HnItem ToItem(ItemResponse source)
        {
            var result = new HnItem();

            result.Id = source.id;
            result.ById = source.by;
            result.CreatedOn = UnixTimeStampToDateTime(source.time);
            result.IsDead = source.dead;
            result.IsDeleted = source.deleted;
            result.KidIds = source.kids;
            result.ParentId = source.parent;
            result.PollOptions = source.parts;
            result.Score = source.score;
            result.Text = source.text;
            result.Url = GetUrl(source.url);
            result.Type = GetType(source.type);

            return result;
        }

        public static HnUser ToUser(UserResponse source)
        {
            var result = new HnUser();

            result.About = source.about;
            result.CreatedOn = UnixTimeStampToDateTime(source.created);
            result.Id = source.id;
            result.Karma = source.karma;
            result.SubmittedIds = source.submitted.Select(x => x.ToString());
            result.VisibilityDelay = TimeSpan.FromMinutes(source.delay);

            return result;
        }

        private static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            return dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
        }

        private static Uri GetUrl(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
                return null;

            if (Uri.IsWellFormedUriString(url, UriKind.RelativeOrAbsolute))
                return null;

            return new Uri(url);
        }

        private static HnType GetType(string type)
        {
            switch (type.ToUpperInvariant())
            {
                case "STORY":
                    return HnType.Story;

                case "COMMENT":
                    return HnType.Comment;

                case "POLL":
                    return HnType.Poll;

                case "POLLOPT":
                    return HnType.PollOpt;

                default:
                    return HnType.Undetermined;
            }
        }
    }
}
