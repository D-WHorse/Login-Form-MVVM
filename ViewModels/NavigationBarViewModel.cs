﻿/*using Password_Form.Commands;
using Password_Form.Services;
using Password_Form.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Password_Form.ViewModels
{
    public class NavigationBarViewModel : ViewModelBase
    {
        private readonly UserStore _userStore;

        public ICommand NavigateUserListCommand { get; }
        public ICommand NavigateOptionsCommand { get; }
        public ICommand NavigateAboutCommand { get; }
        public bool IsAdminLoggedIn => _userStore.CurrentUser.isAdmin;

        public NavigationBarViewModel(UserStore userStore, INavigationService<UserListingViewModel> userListService,
            INavigationService<OptionsViewModel> optionsService,
            INavigationService<AboutViewModel> aboutService)
        {
            NavigateUserListCommand = new NavigateCommand<UserListingViewModel>(userListService);
            NavigateOptionsCommand = new NavigateCommand<OptionsViewModel>(optionsService);
            NavigateAboutCommand = new NavigateCommand<AboutViewModel>(aboutService);
            _userStore = userStore;
        }
    }
}
*/