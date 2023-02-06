using Password_Form.Models;
using Password_Form.Repositories;
using Password_Form.Stores;
using System.Threading;
using System.Windows.Input;

namespace Password_Form.ViewModels
{
    public class DashboardViewModel : ViewModelBase
    {
        //Fields
        private UserStore _userStore;

        public string Name => _userStore.CurrentUser?.Name;
        public string LastName => _userStore.CurrentUser?.LastName;
        //public ICommand NavigateToCommand { get; }

        public DashboardViewModel(UserStore userStore, NavigationStore navigationStore)
        {
            _userStore=userStore;
        }
    }
}
