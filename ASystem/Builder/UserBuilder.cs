using ASystem.Enum;
using ASystem.Models.Context;
using ASystem.Singleton;

namespace ASystem.Builder
{
    public class UserBuilder
    {
        private UserContextModel _userContextModel = new UserContextModel();
        public UserBuilder()
        {
            Reset();
        }
        public void Reset()
        {
            _userContextModel = new UserContextModel();
        }
        public void Set(UserContextModel userContextModel)
        {
            _userContextModel = userContextModel;
        }
        public UserBuilder SetUserId(int userId)
        {
            _userContextModel.UserId = userId;
            return this;
        }
        public UserBuilder SetUsername(string username)
        {
            _userContextModel.Username = username;
            return this;
        }
        public UserBuilder SetPassword(string password)
        {
            CipherSingleton cipherSingleton = CipherSingleton.Instance;
            _userContextModel.Password = cipherSingleton.Encrypt(password);
            return this;
        }
        public UserBuilder SetStatus(UserEnum userEnum)
        {
            _userContextModel.Status = userEnum.ToString();
            return this;
        }
        public UserContextModel Build()
        {
            UserContextModel model = _userContextModel;
            Reset();
            return model;
        }
    }
}
