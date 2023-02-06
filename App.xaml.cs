using System.Windows;
using Password_Form.Stores;
using Password_Form.ViewModels;
using Password_Form.Views;

namespace Password_Form
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        //private SqlService _sqlService;
        private readonly NavigationStore _navigationStore;
        private readonly UserStore _userStore;

        public App()
        {
            //_sqlService = new SqlService();
            _navigationStore = new NavigationStore();
            _userStore = new UserStore();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            //INavigationService<LoginViewModel> loginNavigationService = CreateLoginVeiwModel();
            //loginNavigationService.Navigate();

            _navigationStore.CurrentViewModel = new LoginViewModel(_userStore, _navigationStore);

            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_navigationStore)
            };
            MainWindow.Show();

            base.OnStartup(e);
        }
    }
}
