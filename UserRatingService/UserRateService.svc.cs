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
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class UserRateService : IUserRateService,IDisposable
    {
        private readonly DataContext _dataContext = new DataContext("dbUser");
        public void RegisteredUser(string nick, int userId)
        {
            _dataContext.Users.Add(new User(userId, nick));
        }

        public void PutPostEvaluation(int userId, int evaluation)
        {
            User user = _dataContext.Users.FirstOrDefault(u => u.Id == userId);
            if (user != null)
            {
                user.Rating = evaluation;
                _dataContext.SaveChanges();
            }
            else
            {
                throw new FaultException<ArgumentException>(new ArgumentException("Нет пользователя с таким идентификатором", "userId"));
            }
        }

        public string GetMaxRatedUser()
        {
            User firstOrDefault = _dataContext.Users.OrderBy(u => u.Rating).FirstOrDefault();
            if (firstOrDefault != null)
                return firstOrDefault.Nick;
            return string.Empty;
        }

        public void Dispose()
        {
            _dataContext.Dispose();
        }
    }
}
