using System.Runtime.Serialization;
using System.ServiceModel;

namespace UserRatingService
{

    [ServiceContract]
    public interface IUserRateService
    {
        [OperationContract]
        string GetData(int value);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);
        [OperationContract]
        void RegisteredUser(string nick, int userId);

        [OperationContract]
        void PutPostEvaluation(int userId, int evaluation);

        [OperationContract]
        string GetMaxRatedUser();


    }

    [DataContract]
    public class CompositeType
    {
        private bool boolValue = true;
        private string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
