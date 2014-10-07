using System;
using System.Web.Script.Serialization;

namespace HackerNewsSharp
{
    public interface IDeserializer
    {
        T Deserialize<T>(string json);
    }

    public class JsonDeserializer : IDeserializer
    {
        private readonly JavaScriptSerializer _serializer;

        public JsonDeserializer()
        {
            _serializer = new JavaScriptSerializer();
        }

        public T Deserialize<T>(string json)
        {
            return _serializer.Deserialize<T>(json);
        }
    }
}
