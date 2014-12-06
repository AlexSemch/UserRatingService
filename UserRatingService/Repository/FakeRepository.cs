using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserRatingService.Repository
{
    public class FakeRepository : IUserRepository
    {
        private readonly List<User> _listOfUsers = new List<User>();

        public async Task AddUserAsync(User user)
        {
            await Task.Run(() => _listOfUsers.Add(user));
        }

        public async Task UpdateUserRateAsync(int userId, int rating)
        {
            await Task.Run(() =>
            {
                var firstOrDefault = _listOfUsers.FirstOrDefault(u => u.Id == userId);
                return firstOrDefault != null ? (firstOrDefault.Rating = rating) : 0;
            });
        }

        public async Task<User> GetMaxRatedUserAsync()
        {
            var firstOrDefault = _listOfUsers.OrderBy(u => u.Rating).FirstOrDefault();
            if (firstOrDefault != null)
                return await Task.Run(() => firstOrDefault);
            return null;
        }

        private static FakeRepository _instanceRepository;

        private FakeRepository()
        {
            
        }

        public static IUserRepository GetRepository()
        {
            return _instanceRepository ?? (_instanceRepository = new FakeRepository());
        }
    }
}