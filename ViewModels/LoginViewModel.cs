using System.Net;
using System.Security.Principal;
using System.Security;
using System.Threading;
using System.Windows.Input;
using Password_Form.Models;
using Password_Form.Repositories;
using System;
using Password_Form.Commands;
using Password_Form.Stores;

namespace Password_Form.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        //Fields
        private string _username;
        private string _password;
        private bool _isntShokShok = false;
        private string _errorMessage;
        private bool _isViewVisible = true;

        public static string ButtonClicked;

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

        //-> Commands
        public ICommand LoginCommand { get; }
        public ICommand NavigateToRegistrationCommand { get; }
        //public ICommand ShowPasswordCommand { get; }

        //Constructor
        public LoginViewModel(NavigationStore navigationStore)
        {
            userRepository = new UserRepository();
            LoginCommand = new ViewModelCommand(ExecuteLoginCommand, CanExecuteLoginCommand);
            NavigateToRegistrationCommand = new NavigateToRegistrationCommand(navigationStore);
            //RecoverPasswordCommand = new ViewModelCommand(p => ExecuteRecoverPassCommand("", ""));
        }

        private bool CanExecuteLoginCommand(object obj)
        {
            bool validData;
            if (string.IsNullOrWhiteSpace(Username) || Username.Length < 3 ||
                Password == null || Password.Length < 3)
                validData = false;
            else
                validData = true;
            return validData;
        }

        private void ExecuteLoginCommand(object obj)
        {
            LoginViewModel.ButtonClicked = "Login";

            if (_isntShokShok)
            {
                var isValidUser = userRepository.AuthenticateUser(new NetworkCredential(Username, Password));
                if (isValidUser)
                {
                    Thread.CurrentPrincipal = new GenericPrincipal(
                        new GenericIdentity(Username), null); // null это роль!!!
                    IsViewVisible = false;
                }
                else
                {
                    ErrorMessage = "(*Звуковой сигнал*) Неправильно! Попробуй еще раз.";
                }
            }
            else
            {
                ErrorMessage = "Вы не согласились с 4 правилом!";
            }
        }
    }
}
