using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using HackerNewsSharp.Mapping;
using HackerNewsSharp.Models;
using HackerNewsSharp.Responses;

namespace HackerNewsSharp
{
    public class HnClient : IHnClient
    {
        private const string _version = "v0";

        private readonly Uri _endpointBase;
        private readonly WebClient _client;

        public IDeserializer Deserializer { private get; set; }

        public HnClient(string endPointBase = null, IDeserializer deserializer = null)
        {
            if (endPointBase == null)
                endPointBase = "https://hacker-news.firebaseio.com";

            if (deserializer == null)
                deserializer = new JsonDeserializer();

            _endpointBase = new Uri(endPointBase);
            _client = new WebClient();
            Deserializer = deserializer;
        }

        public HnItem GetItem(string itemId)
        {
            var itemEndPoint = new Uri(_endpointBase, _version + "/item/" + itemId + ".json");
            var response = _client.DownloadString(itemEndPoint);

            if (response == null)
                return null;

            var responseObject = Deserializer.Deserialize<ItemResponse>(response);
            var result = Mapper.ToItem(responseObject);

            return result;
        }

        public HnUser GetUser(string userId)
        {
            var userEndPoint = new Uri(_endpointBase, _version + "/user/" + userId + ".json");
            var response = _client.DownloadString(userEndPoint);

            if (response == null)
                return null;

            var responseObject = Deserializer.Deserialize<UserResponse>(response);
            var result = Mapper.ToUser(responseObject);

            return result;
        }

        public IEnumerable<string> GetTopStories()
        {
            var userEndPoint = new Uri(_endpointBase, _version + "/topstories.json");
            var response = _client.DownloadString(userEndPoint);

            if (response == null)
                return Enumerable.Empty<string>();

            var responseObject = Deserializer.Deserialize<List<string>>(response);

            return responseObject;
        }
    }
}
