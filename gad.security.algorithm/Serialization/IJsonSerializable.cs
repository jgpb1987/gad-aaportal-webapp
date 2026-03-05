using System.Text.Json;
using System.Text.Json.Nodes;

namespace gad.security.algorithm.Serialization
{
    public interface IJsonSerializable : IBaseSerializable
    {


        private static JsonSerializerOptions Indented = new JsonSerializerOptions { WriteIndented = true };
        private static JsonSerializerOptions NotIndented = new JsonSerializerOptions { WriteIndented = false };

        public static JsonSerializerOptions GetIndentOptions(bool indented) { return indented ? Indented : NotIndented; }
        public JsonObject ToJsonObject();
        public string Serialize(bool indented = false);

    }
}
