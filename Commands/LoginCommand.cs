using Password_Form.Repositories;
using Password_Form.Services;
using Password_Form.Stores;
using Password_Form.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Password_Form.Commands
{
    public class LoginCommand : CommandBase
    {
        private readonly LoginViewModel _viewModel;
        private readonly NavigationService<DashboardViewModel> _navigationService;

        public LoginCommand(LoginViewModel viewModel, NavigationService<DashboardViewModel> navigationService)
        {
            _viewModel=viewModel;
            _navigationService=navigationService;
        }

        public override void Execute(object parameter)
        {
            _navigationService.Navigate();
        }

        /*public override bool CanExecute(object parameter)
        {
            bool validData;
            if (string.IsNullOrWhiteSpace(Username) || Username.Length < 3 ||
                Password == null || Password.Length < 3)
                validData = false;
            else
                validData = true;
            return validData;
        }
        public override void Execute(object parameter)
        {
            LoginViewModel.ButtonClicked = "Login";

            if (_isntShokShok)
            {
                var isValidUser = userRepository.AuthenticateUser(new NetworkCredential(Username, Password));
                if (isValidUser)
                {
                    Thread.CurrentPrincipal = new GenericPrincipal(
                        new GenericIdentity(Username), null); // null это роль!!!
                    _navigationService.Navigate();
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


        public override bool CanExecute(object parameter)
        {
            if (_userStore.CurrentUser.isAdmin)
                return true;
            return false;
        }
        public override void Execute(object parameter)
        {
            _sqlService.changePasswordSize(_optionsViewModel.PasswordMinSize);
            _optionsViewModel.StatusMessage = "Успешно!";
        }*/
    }
}
