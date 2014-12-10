using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserRatingService.Repository
{
    public class FakeRepository : IUserRepository
    {
        private readonly List<User> _users = new List<User>();

        public void AddUser(User user)
        {
            if (_users.Any(u => u.Id == user.Id))
                throw new ArgumentException("Пользователь с таким Ид уже существует", "user");
            _users.Add(user);
        }

        public void UpdateUserRate(int userId, int rating)
        {
            var user = _users.FirstOrDefault(u => u.Id == userId);
            if (user == null)
                throw new ArgumentException("Пользователь с таким идентификатором не зарегистрирован", "userId");
            user.Rating = rating;
        }

        public User GetMaxRatedUser()
        {
            return _users.OrderBy(u => u.Rating).FirstOrDefault();
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