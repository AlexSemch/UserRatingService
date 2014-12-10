using System.Threading.Tasks;

namespace UserRatingService.Repository
{
    public interface IUserRepository
    {
        void AddUser(User user);
        void UpdateUserRate(int userId, int rating);
        User GetMaxRatedUser();

    }
}