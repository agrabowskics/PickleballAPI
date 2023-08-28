using BlazorWebAssembely.Shared;

namespace BlazorWebAssembely.Client.Services
{
    public interface IPlayersService
    {
        Task<PlayerResponseDto> SearchPlayersAgeAsync(int age1, int age2, int page);
        Task<PlayerResponseDto> GetPlayersAsync(int page);
        Task<Player> GetPlayerAsync(int id);
    }
}
