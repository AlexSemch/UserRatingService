using System.Threading.Tasks;

namespace UserRatingService.Repository
{
    public interface IUserRepository
    {
        Task AddUserAsync(User user);
        Task UpdateUserRateAsync(int userId, int rating);
        Task<User> GetMaxRatedUserAsync();

    }
}