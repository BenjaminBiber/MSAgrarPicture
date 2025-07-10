namespace MSLib.Models;

using System;
using System.Text.Json.Serialization;

public class GalerieSeite
{
    [JsonPropertyName("id")]
    public Guid Id { get; set; }

    [JsonPropertyName("Überschrift")]
    public string Überschrift { get; set; }
}
