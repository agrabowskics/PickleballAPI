using BlazorWebAssembely.Shared;
using System.Net.Http.Json;

namespace BlazorWebAssembely.Client.Services
{
    public class PlayersService : IPlayersService
    {
        private readonly HttpClient _httpClient;

        public PlayersService(HttpClient http) 
        { 
            _httpClient = http;
        }

        public async Task<Player> GetPlayerAsync(int id)
        {
            var results = await _httpClient.GetFromJsonAsync<Player>("api/Players/Player/" + id);

            return results ?? new();
        }

        public async Task<PlayerResponseDto> GetPlayersAsync(int page)
        {
            var results = await _httpClient.GetFromJsonAsync<PlayerResponseDto>("api/Players/Players/" + page);

            return results ?? new(); 
        }

        public async Task<PlayerResponseDto> SearchPlayersAgeAsync(int age1, int age2, int page)
        {
            var results = await _httpClient.GetFromJsonAsync<PlayerResponseDto>("api/Players/Search/Age/" + age1 + "/" + age2 + "/" + page);

            return results ?? new();
        }
    }
}
