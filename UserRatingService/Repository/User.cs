
using System;
using System.ComponentModel.DataAnnotations;

namespace UserRatingService.Repository
{
    /// <summary>
    /// Пользователь соцсети
    /// </summary>
    public class User
    {
        [Range(0, 1000000000)]
        public int Id { get; set; }

        [MaxLength(20)]
        public string Nick { get; set; }

        private int _rating;

        /// <summary>
        /// Рейтинг пользователя(среднее значение всех оценко постов)
        /// </summary>
        [Range(-1000000000, 1000000000)]
        public int Rating
        {
            get { return _rating; }
            set
            {
                _rating = (_rating*_postCount + value)/++_postCount;
            }
        }

        private int _postCount;

        public User(int userId, string nick, int rating = 0)
        {
            this.Id = userId;
            this.Nick = nick;
            this._rating = rating;
        }
    }
}