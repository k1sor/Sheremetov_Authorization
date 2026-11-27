using System.Windows.Controls;
using Sheremetov_Authorization.Models;

namespace Sheremetov_Authorization.Pages
{
    /// <summary>
    /// Логика взаимодействия для LibrarianPage.xaml
    /// </summary>
    public partial class LibrarianPage : Page
    {
        public LibrarianPage(User user, string role)
        {
            InitializeComponent();
            txtWelcome.Text = "Вы вошли как: " + role +
                (user != null ? " (" + user.UserLogin + ")" : "");
        }
    }
}
