using System.Text.Json.Serialization;

namespace MSLib.Models;

public class About
{
    [JsonPropertyName("id")]
    public Guid Id { get; set; }

    [JsonPropertyName("Überschrift")]
    public string Ueberschrift { get; set; } = string.Empty;

    [JsonPropertyName("Teilüberschrift")]
    public string TeilUeberschrift { get; set; } = string.Empty;

    [JsonPropertyName("Teil Text")]
    public string TeilText { get; set; } = string.Empty;

    [JsonPropertyName("Teilüberschrift 2")]
    public string TeilUeberschrift2 { get; set; } = string.Empty;

    [JsonPropertyName("Teil Text 2")]
    public string TeilText2 { get; set; } = string.Empty;

    [JsonPropertyName("Ich Bild")]
    public BildUrls IchBild { get; set; } = new BildUrls();
}