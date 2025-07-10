namespace MSLib.Models;

public class ImpressumsTexts
{
    public List<ImpressumsItem> Data { get; set; } = new List<ImpressumsItem>();
    public int CurrentPage { get; set; } = 1;
    public int LastPage { get; set; } = 1;
    public int From { get; set; } = 0;
    public int To { get; set; } = 0;
    public int Total { get; set; } = 0;
    public int PerPage { get; set; } = 0;
}

public class ImpressumsItem
{
    public string Id { get; set; } = string.Empty;
    public string Text { get; set; } = string.Empty;
    public int Sortierreihenfolge { get; set; } = 0;
    public bool IstÜberschrift { get; set; } = false;
}

public class ImpressumSite
{
    public string Id { get; set; } = string.Empty;
    public string Überschrift { get; set; } = string.Empty;
}