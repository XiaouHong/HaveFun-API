using System.Text.Json;
using System.Text.Json.Serialization;

namespace HaveFun_API.Schafold
{
	public class JsonDateTimeConverter : JsonConverter<DateTime>
	{
		public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			if (!string.IsNullOrEmpty(reader.GetString()))
			{
				return DateTime.Parse(reader.GetString());
			}
			else
			{
				return DateTime.MinValue;
			}
		}

		public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
		{
			var datetime = DateTime.SpecifyKind(value, DateTimeKind.Utc);
			writer.WriteStringValue(datetime.ToString("yyyy/MM/dd HH:mm:ss"));
		}
	}
}
