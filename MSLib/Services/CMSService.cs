using System.Net.Mime;
using System.Text.Json;
using MSLib.Models;

namespace MSLib.Services;

public class CmsService
{
    private string _cmsUrl = (Environment.GetEnvironmentVariable("CMSUrl") ?? "http://localhost:1111") + "/api";

    private readonly HttpClient _httpClient;
    private CacheService _cacheService;

    public CmsService(HttpClient httpClient, CacheService cacheService)
    {
        _cacheService = cacheService;
        _httpClient = httpClient;
    }
    
    public async Task<Homepage> GetHomepageAsync()
    {
        return await _cacheService.GetOrAddAsync("Homepage", async () =>
        {
            var result = await GetData<Homepage>("/singles/homepage");
            if (result.Success)
            {
                return result.Data;
            }
            else
            {
                return new Homepage();
            }
        });
    }
    
    public async Task<Einstellungen> GetEinstellungenAsync()
    {
        return await _cacheService.GetOrAddAsync("Einstellungen", async () =>
        {
            var result = await GetData<Einstellungen>("/singles/einstellungen");
            if (result.Success)
            {
                return result.Data;
            }
            else
            {
                return new Einstellungen();
            }
        });
    }
    
    public async Task<List<Album>> GetAlbumsAsync()
    {
        return await _cacheService.GetOrAddAsync("Alben", async () =>
        {
            var result =  await GetData<AlbumResponse>("/collections/albums");
            if (result.Success)
            {
                return result.Data.Data;
            }
            else
            {
                return new List<Album>();
            }
        });
    }
    
    public async Task<ImpressumSite> GetImpressumSiteAsync()
    {
        return await _cacheService.GetOrAddAsync("ImpressumSite", async () =>
        {
            var result = await GetData<ImpressumSite>("/singles/impressum");
            if (result.Success)
            {
                return result.Data;
            }
            else
            {
                return new ImpressumSite();
            }
        });
    }
    
    public async Task<ImpressumsTexts> GetImpressumAsync()
    {
        return await _cacheService.GetOrAddAsync("Impressum", async () =>
        {
            var result = await GetData<ImpressumsTexts>("/collections/impressums-texts");
            if (result.Success)
            {
                return result.Data;
            }
            else
            {
                return new ImpressumsTexts();
            }
        });
    }
    
    public async Task<About> GetAboutAsync()
    {
        return await _cacheService.GetOrAddAsync("About", async () =>
        {
            var result = await GetData<About>("/singles/about");
            if (result.Success)
            {
                return result.Data;
            }
            else
            {
                return new About();
            }
        });
    }
    
    public async Task<GalerieSeite> GetGaleryAsync()
    {
        return await _cacheService.GetOrAddAsync("GalerieSeite", async () =>
        {
            var result = await GetData<GalerieSeite>("/singles/galerie-seite");
            if (result.Success)
            {
                return result.Data;
            }
            else
            {
                return new GalerieSeite();
            }
        });
    }

    private async Task<ApiResult<T>> GetData<T>(string url)
    {
        if (string.IsNullOrEmpty(url))
        {
            return new ApiResult<T>
            {
                Success = false,
                Data = default,
                Error = "URL is null or empty"
            };
        }

        try
        {
            var response = await _httpClient.GetAsync(_cmsUrl + url);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var data = JsonSerializer.Deserialize<T>(json, options);

            return new ApiResult<T>
            {
                Success = true,
                Data = data
            };
        }
        catch (Exception ex)
        {
            return new ApiResult<T>
            {
                Success = false,
                Data = default,
                Error = ex.Message
            };
        }
    }

}