using System.Data.SqlClient;
using System.Windows;

namespace WPF_LoginForm.Repositories
{
    public abstract class RepositoryBase
    {
        public readonly SqlConnection connection;
        private const string DB_PATH_CONNECTION =
            @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Projects\Visual Studio Projects\Password Form\Data\LoginFormDb.mdf;Integrated Security=True";
        public RepositoryBase()
        {
            connection = new SqlConnection(DB_PATH_CONNECTION);
            try
            {
                connection.Open();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
