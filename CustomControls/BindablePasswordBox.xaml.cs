using System.Windows;
using System.Windows.Controls;
namespace Password_Form.CustomControls
{
    /// <summary>
    /// Interaction logic for BindablePasswordBox.xaml
    /// </summary>
    public partial class BindablePasswordBox : UserControl
    {
        // Dependency property for the password
        public static readonly DependencyProperty PasswordProperty =
            DependencyProperty.Register("Password", typeof(string), typeof(BindablePasswordBox));

        // Property to get and set the password value
        public string Password
        {
            get { return (string)GetValue(PasswordProperty); }
            set { SetValue(PasswordProperty, value); }
        }

        public BindablePasswordBox()
        {
            // Initialize the component
            InitializeComponent();

            // Attach an event handler for the PasswordChanged event of tb2
            PasswordField.PasswordChanged += OnPasswordChanged;

        }

        // Event handler for the PasswordChanged event
        private void OnPasswordChanged(object sender, RoutedEventArgs e)
        {
            // Checking if the password length is greater than 0
            if (PasswordField.Password.Length > 0)
            {
                // Hiding the visibility of an element
                Watermark.Visibility = Visibility.Collapsed;
            }
            else
            {
                // Showing the visibility of an element
                Watermark.Visibility = Visibility.Visible;
            }

            // Update the value of the Password property with the current value of the SecurePassword property of tb2
            Password = PasswordField.Password;
        }
    }
}
