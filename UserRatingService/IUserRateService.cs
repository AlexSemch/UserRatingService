using System.ServiceModel;

namespace UserRatingService
{

    [ServiceContract]
    public interface IUserRateService
    {
        [OperationContract]
        void RegisteredUser(string nick, int userId);

        [OperationContract]
        void PutPostEvaluation(int userId, int evaluation);

        [OperationContract]
        string GetMaxRatedUser();
    }
}
