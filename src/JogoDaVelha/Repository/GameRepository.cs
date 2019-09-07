using JogoDaVelha.Extensions;
using JogoDaVelha.Model;
using JogoDaVelha.Repository.Interfaces;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace JogoDaVelha.Repository
{
    public class GameRepository : IGameRepository
    {
        private readonly IDistributedCache _cache;
        private readonly DistributedCacheEntryOptions _options;
        private readonly IConfiguration _configuration;

        public GameRepository(IDistributedCache cache, IConfiguration configuration)
        {
            _cache = cache;
            _configuration = configuration;
            _options = new DistributedCacheEntryOptions();
            ConfigureCache();
        }

        public async Task<GameModel> GetGame(Guid id)
        {
            var result = await _cache.GetAsync(id.ToString());
            return result.FromByteArray<GameModel>();
        }

        public void SaveGame(GameModel game)
        {
            _cache.Set(game.Id.ToString(), game.ToByteArray(), _options);
        }

        private void ConfigureCache()
        {
            _options.SetAbsoluteExpiration(TimeSpan.FromMinutes(
                _configuration.GetValue<int>("Cache:SetAbsoluteExpiration")));
        }

    }
}
