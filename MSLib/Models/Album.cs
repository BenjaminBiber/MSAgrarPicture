namespace MSLib.Models;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

public class AlbumResponse
{
    [JsonPropertyName("data")]
    public List<Album> Data { get; set; }

    [JsonPropertyName("currentPage")]
    public int CurrentPage { get; set; }

    [JsonPropertyName("lastPage")]
    public int LastPage { get; set; }

    [JsonPropertyName("from")]
    public int From { get; set; }

    [JsonPropertyName("to")]
    public int To { get; set; }

    [JsonPropertyName("total")]
    public int Total { get; set; }

    [JsonPropertyName("perPage")]
    public int PerPage { get; set; }
}

public class Album
{
    [JsonPropertyName("id")]
    public Guid Id { get; set; }

    [JsonPropertyName("Name")]
    public string Name { get; set; }

    [JsonPropertyName("Cover-Bild")]
    public CoverBild CoverBild { get; set; }

    [JsonPropertyName("bilders")]
    public List<Bilder> Bilders { get; set; }
}

public class CoverBild
{
    [JsonPropertyName("small")]
    public string Small { get; set; }

    [JsonPropertyName("large")]
    public string Large { get; set; }

    [JsonPropertyName("original")]
    public string Original { get; set; }
}

public class Bilder
{
    [JsonPropertyName("id")]
    public Guid Id { get; set; }

    [JsonPropertyName("Bild")]
    public BildUrls Bild { get; set; } = new BildUrls();

    [JsonPropertyName("Bildunterschrift")]
    public string Bildunterschrift { get; set; } = string.Empty;

    [JsonPropertyName("IstTopBild")]
    public bool IstTopBild { get; set; }
}

public class BildUrls
{
    [JsonPropertyName("small")]
    public string Small { get; set; } = string.Empty;

    [JsonPropertyName("large")]
    public string Large { get; set; } = string.Empty;

    [JsonPropertyName("original")]
    public string Original { get; set; } = string.Empty;
}

