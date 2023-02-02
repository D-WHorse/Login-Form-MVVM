using System.Windows;
using Password_Form.ViewModels;
using Password_Form.Views;

namespace Password_Form
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        /*public App()
        {
            _sqlService = new SqlService();
            _navigationStore = new NavigationStore();
            _userStore = new UserStore();
        }*/

        protected override void OnStartup(StartupEventArgs e)
        {
            //INavigationService<LoginViewModel> loginNavigationService = CreateLoginVeiwModel();
            //loginNavigationService.Navigate();

            MainWindow = new MainWindow()
            {
                //DataContext = new MainViewModel(_navigationStore)
                DataContext = new MainViewModel()
            };
            MainWindow.Show();

            base.OnStartup(e);
        }

        /*protected void ApplicationStart(object sender, StartupEventArgs e)
        {
            var loginView = new LoginView();
            loginView.Show();
            loginView.IsVisibleChanged += (s, ev) =>
            {
                if (loginView.IsVisible == false && loginView.IsLoaded)
                {
                    if (LoginViewModel.ButtonClicked == "Login")
                    {
                        var dashboard = new Dashboard();
                        dashboard.Show();
                        loginView.Close();
                    }
                    else if (LoginViewModel.ButtonClicked == "Sign Up")
                    {
                        var registration = new RegistrationView();
                        registration.Show();
                        loginView.Close();

                        *//*if (registration.IsVisible == false && registration.IsLoaded)
                        {
                            if (LoginViewModel.ButtonClicked == "Register")
                            {
                                var dashboard = new Dashboard();
                                dashboard.Show();
                                registration.Close();
                            }
                        }*//*
                    }
                }
            };
        }*/
    }
}
