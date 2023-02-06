using Password_Form.Models;

namespace Password_Form.Stores
{
    public class UserStore
    {
        private UserModel _currentUser;
        public UserModel CurrentUser { get; set; }
    }
}
