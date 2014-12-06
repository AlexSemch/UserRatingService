
using System.ComponentModel.DataAnnotations;

namespace UserRatingService.Repository
{
    /// <summary>
    /// Пользователь соцсети
    /// </summary>
    public class User
    {
        [Range(0,1000000000)]
        public int Id { get; set; }
        [MaxLength(20)]
        public string Nick { get; set; }
        /// <summary>
        /// Рейтинг пользователя(среднее значения оценки всех постов)
        /// </summary>
        [Range(-1000000000, 1000000000)]
        public int Rating { get; set; }
    }
}