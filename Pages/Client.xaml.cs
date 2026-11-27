using System.Windows.Controls;
using Sheremetov_Authorization.Models;

namespace Sheremetov_Authorization.Pages
{
    /// <summary>
    /// Логика взаимодействия для Client.xaml
    /// </summary>
    public partial class Client : Page
    {
        public Client(User user, string role)
        {
            InitializeComponent();
            txtWelcome.Text = "Вы вошли как: " + (role ?? "Гость") +
                (user != null ? " (" + user.UserLogin + ")" : "");
        }
    }
}
