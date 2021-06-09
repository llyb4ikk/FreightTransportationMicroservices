using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Location.Entities;
using Location.Enums;
using Location.Interfaces;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.OpenApi.Extensions;
using MongoDB.Driver;

namespace Location.Services
{
    public class CityService : ICityService
    {
        private readonly IMongoCollection<City> _city;
        private readonly IDistributedCache _redisCache;

        public CityService(IMongoClient client, IDistributedCache cache)
        {
            _city = client.GetDatabase("Location").GetCollection<City>("cit");
            _redisCache = cache;
        }

        public async Task<City> GetCityById(string id)
        {
            //var cahed = await _redisCache.GetStringAsync(id);

            //if (String.IsNullOrEmpty(cahed))
            //{
                var filter = Builders<City>.Filter.Eq(c => c.Id, id);
                City res = await _city.Find(filter).FirstOrDefaultAsync();
                return res;
                //    await _redisCache.SetStringAsync(id, JsonSerializer.Serialize(res));
                //    return res;
                //}

                //return JsonSerializer.Deserialize<City>(cahed);
        }

        public async Task<IEnumerable<City>> GetCitiesByRegion(Region region)
        {
            string idOfCollection = $"CitiesIn{region}";
            var cahed = await _redisCache.GetStringAsync(idOfCollection);

            if (String.IsNullOrEmpty(cahed))
            {
                var filter = Builders<City>.Filter.Eq(c => c.Region, region);
                IEnumerable<City> result = await _city.Find(filter).ToListAsync();
                await _redisCache.SetStringAsync(idOfCollection, JsonSerializer.Serialize(result));
                return result;
            }
             
            return JsonSerializer.Deserialize<IEnumerable<City>>(cahed);
        }
    }
}