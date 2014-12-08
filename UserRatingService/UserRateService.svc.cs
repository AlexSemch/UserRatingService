using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;
using UserRatingService.Repository;

namespace UserRatingService
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "Service1" в коде, SVC-файле и файле конфигурации.
    // ПРИМЕЧАНИЕ. Чтобы запустить клиент проверки WCF для тестирования службы, выберите элементы Service1.svc или Service1.svc.cs в обозревателе решений и начните отладку.
    public class UserRateService : IUserRateService
    {
        private readonly IUserRepository _repository = FakeRepository.GetRepository();
        public void RegisteredUser(string nick, int userId)
        {
            _repository.AddUserAsync(new User(userId, nick));
        }

        public void PutPostEvaluation(int userId, int evaluation)
        {
            _repository.UpdateUserRateAsync(userId, evaluation);
        }

        public string GetMaxRatedUser()
        {
            var popUser =  _repository.GetMaxRatedUserAsync();
            return popUser.Result.Nick; 
        }
    }
}
