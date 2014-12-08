using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserRatingService.Repository
{
    public class FakeRepository : IUserRepository
    {
        private readonly List<User> _users = new List<User>();

        public async Task AddUserAsync(User user)
        {
            try
            {
                await Task.Run(() =>
                {
                    if (_users.Any(u=>u.Id == user.Id))
                                             throw new Exception("Пользователь с таким Ид уже существует");
                    _users.Add(user);
                });
            }
            catch (Exception ex)
            {
                throw;
            }
            //_users.Add(user.Id, user);
            
        }

        public async Task UpdateUserRateAsync(int userId, int rating)
        {
            await Task.Run(() =>
            {
                var user = _users.FirstOrDefault(u=>u.Id == userId);
                return user != null ? (user.Rating = rating) : 0;
            });
        }

        public async Task<User> GetMaxRatedUserAsync()
        {
            var firstOrDefault = _users.OrderBy(u => u.Rating).FirstOrDefault();
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