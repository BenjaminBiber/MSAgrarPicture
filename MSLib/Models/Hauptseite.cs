namespace MSLib.Models;

using System;
using System.Text.Json.Serialization;

public class Homepage
{
    [JsonPropertyName("id")]
    public Guid Id { get; set; }

    [JsonPropertyName("Überschrift")]
    public string Überschrift { get; set; } = string.Empty;

    [JsonPropertyName("Haupttext")]
    public string Haupttext { get; set; } = string.Empty;

    [JsonPropertyName("Best Of Text")]
    public string BestOfText { get; set; } = string.Empty;

    [JsonPropertyName("Info Text")]
    public string InfoText { get; set; } = string.Empty;

    [JsonPropertyName("Seitenbild")]
    public string Seitenbild { get; set; } = string.Empty;

    [JsonPropertyName("Hintergrundbild")]
    public string Hintergrundbild { get; set; } = string.Empty;
}
