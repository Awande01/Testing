using RestSharp.Deserializers;
using RestSharp.Serializers;

namespace BL.Repository
{
    public interface IJsonSerializer : ISerializer, IDeserializer
    {
    }
}
