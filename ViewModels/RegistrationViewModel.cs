using System.Net;
using System.Security.Principal;
using System.Security;
using System.Threading;
using System.Windows.Input;
using Password_Form.Models;
using Password_Form.Repositories;
using Password_Form.Stores;
using Password_Form.Commands;

namespace Password_Form.ViewModels
{
    public class RegistrationViewModel : ViewModelBase
    {
        //Fields
        private string _username;
        private string _name;
        private string _lastName;
        private string _email;
        private string _password;
        private string _confirmationPassword;
        private bool _isntShokShok = false;
        private string _errorMessage;
        private bool _isViewVisible = true;

        private IUserRepository userRepository;

        //Properties
        public string Username
        {
            get
            {
                return _username;
            }
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                _lastName = value;
                OnPropertyChanged(nameof(LastName));
            }
        }
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
                OnPropertyChanged(nameof(Email));
            }
        }
        public string ErrorMessage
        {
            get
            {
                return _errorMessage;
            }
            set
            {
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
            }
        }
        public bool IsViewVisible
        {
            get
            {
                return _isViewVisible;
            }
            set
            {
                _isViewVisible = value;
                OnPropertyChanged(nameof(IsViewVisible));
            }
        }
        public string ConfirmationPassword
        {
            get
            {
                return _confirmationPassword;
            }
            set
            {
                _confirmationPassword = value;
                OnPropertyChanged(nameof(ConfirmationPassword));
            }
        }
        public bool IsntShokShok
        {
            get
            {
                return _isntShokShok;
            }

            set
            {
                _isntShokShok = value;
                OnPropertyChanged(nameof(IsntShokShok));
            }
        }

        //-> Commands
        public ICommand RegistrationCommand { get; }
        public ICommand NavigateToLoginCommand { get; }
        public ICommand ShowPasswordCommand { get; }

        public RegistrationViewModel(NavigationStore navigationStore)
        {
            userRepository = new UserRepository();
            RegistrationCommand = new ViewModelCommand(ExecuteRegistrationCommand, CanExecuteRegistrationCommand);
            NavigateToLoginCommand = new NavigateToLoginCommand(navigationStore);
        }

        private bool CanExecuteRegistrationCommand(object obj)
        {
            bool validData = false;
            if (string.IsNullOrWhiteSpace(Username) || Username.Length < 3 ||
                string.IsNullOrWhiteSpace(Name) || Name.Length < 3 ||
                string.IsNullOrWhiteSpace(LastName) || LastName.Length < 3 ||
                Password == null || Password.Length < 3 ||
                ConfirmationPassword == null || ConfirmationPassword.Length < 3)
                validData = false;
            else
                validData = true;
            return validData;
        }
        private void ExecuteRegistrationCommand(object obj)
        {
            LoginViewModel.ButtonClicked = "Login";
            
            if (_isntShokShok)
            {
                if (Password == ConfirmationPassword)
                {
                    UserModel userModel = new UserModel
                    {
                        Username = Username,
                        Password = Password.ToString(),
                        Name = Name,
                        LastName = LastName,
                        IsAdmin = false,
                        IsRestricted = false
                    };

                    userRepository.Add(userModel);
                    bool isValidUser = userRepository.AuthenticateUser(new NetworkCredential(Username, Password));
                    if (isValidUser)
                    {
                        Thread.CurrentPrincipal = new GenericPrincipal(
                            new GenericIdentity(Username), null); // null это роль!!!
                        IsViewVisible = false;
                    }
                    else
                    {
                        ErrorMessage = "Ой, не получилось зарегистрироваться, попробуйте еще раз.";
                    }
                }
                else
                {
                    ErrorMessage = "Пароли в полях Пароля и его подтвержденя не совпадают, попробуйте еще раз.";
                }
            }
            else
            {
                ErrorMessage = "Вы не согласились с 4 правилом!";
            }

        }
    }
}
