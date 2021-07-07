using RestSharp.Deserializers;
using RestSharp.Serializers;

namespace BLL.Repository
{
    public interface IJsonSerializer : ISerializer, IDeserializer
    {
    }
}
