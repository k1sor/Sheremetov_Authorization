using System.Windows.Controls;
using Sheremetov_Authorization.Models;

namespace Sheremetov_Authorization.Pages
{
    /// <summary>
    /// Логика взаимодействия для AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Page
    {
        public AdminPage(User user, string role)
        {
            InitializeComponent();
            txtWelcome.Text = "Вы вошли как: " + role +
                (user != null ? " (" + user.UserLogin + ")" : "");
        }
    }
}
