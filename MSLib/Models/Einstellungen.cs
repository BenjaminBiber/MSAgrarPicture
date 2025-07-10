using System.Text.Json.Serialization;

namespace MSLib.Models;

public class Einstellungen
{
    [JsonPropertyName("id")]
    public Guid Id { get; set; }

    [JsonPropertyName("Logo")]
    public string Logo { get; set; } = string.Empty;

    [JsonPropertyName("Instagram Link")]
    public string InstagramLink { get; set; } = string.Empty;

    [JsonPropertyName("Tiktok Link")]
    public string TiktokLink { get; set; } = string.Empty;

    [JsonPropertyName("Youtube Link")]
    public string YoutubeLink { get; set; } = string.Empty;
}