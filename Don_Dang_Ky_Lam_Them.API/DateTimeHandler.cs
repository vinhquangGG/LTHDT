using System.Text.Json;
using System.Text.Json.Serialization;

namespace Don_Dang_Ky_Lam_Them.API
{
    public class DateTimeHandler : JsonConverter<DateTime>
    {
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return DateTime.Parse(reader.GetString() ?? "");
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(DateTime.SpecifyKind(value, DateTimeKind.Local));
        }
    }
}
