namespace MSLib.Services;

using System.Collections.Concurrent;

public class CacheItem<T>
{
    public T Data { get; set; }
    public DateTime LastWrite { get; set; }
}

public class CacheService
{
    private readonly ConcurrentDictionary<string, CacheItem<object>> _cache = new();

    public async Task<T> GetOrAddAsync<T>(string key, Func<Task<T>> dataFactory)
    {
        var now = DateTime.UtcNow;

        if (_cache.TryGetValue(key, out var existingItem))
        {
            if (existingItem.LastWrite.AddHours(1) > now)
            {
                // Cache gültig
                return (T)existingItem.Data;
            }
        }

        var newData = await dataFactory();

        var newItem = new CacheItem<object>
        {
            Data = newData,
            LastWrite = now
        };

        _cache[key] = newItem;

        return newData;
    }
}
