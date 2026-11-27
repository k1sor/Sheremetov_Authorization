using Sheremetov_Authorization.Models;
using Sheremetov_Authorization.Services;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Sheremetov_Authorization.Pages
{
    /// <summary>
    /// Логика взаимодействия для Autho.xaml
    /// </summary>
    public partial class Autho : Page
    {
        int click;

        public Autho()
        {
            InitializeComponent();
            click = 0;
        }

        private void btnEnterGuests_Click(object sender, RoutedEventArgs e)
        {
            click = 0;
            ClearFields();
            HideCaptcha();
            NavigationService.Navigate(new Client(null, null));
        }

        private void GenerateCaptcha()
        {
            txtBlockCaptcha.Visibility = Visibility.Visible;
            txtboxCaptcha.Visibility = Visibility.Visible;
            string captchaText = CaptchaGenerator.GenerateCaptchaText(6);
            txtBlockCaptcha.Text = captchaText;
            txtBlockCaptcha.TextDecorations = TextDecorations.Strikethrough;
        }

        private void HideCaptcha()
        {
            txtBlockCaptcha.Visibility = Visibility.Hidden;
            txtboxCaptcha.Visibility = Visibility.Hidden;
            txtBlockTimer.Visibility = Visibility.Hidden;
        }

        private void ClearFields()
        {
            txtbLogin.Clear();
            pswbPassword.Clear();
            txtboxCaptcha.Clear();
        }

        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            click += 1;
            string login = txtbLogin.Text.Trim();
            string password = pswbPassword.Password.Trim();
            string passwordHash = Hash.HashPassword(password);

            LibraryEntities db = LibraryEntities.GetContext();
            var user = db.User
                .Where(x => x.UserLogin == login && x.UserPassword == passwordHash)
                .FirstOrDefault();

            if (click == 1)
            {
                if (user != null)
                {
                    MessageBox.Show("Вы вошли под: " + user.Role.RoleName.ToString());
                    ClearFields();
                    HideCaptcha();
                    LoadPage(user.Role.RoleName.ToString(), user);
                }
                else
                {
                    MessageBox.Show("Вы ввели логин или пароль неверно!");
                    pswbPassword.Clear();
                    txtboxCaptcha.Clear();
                    GenerateCaptcha();
                }
            }
            else if (click > 1)
            {
                if (user != null && txtboxCaptcha.Text.Trim() == txtBlockCaptcha.Text)
                {
                    MessageBox.Show("Вы вошли под: " + user.Role.RoleName.ToString());
                    ClearFields();
                    HideCaptcha();
                    LoadPage(user.Role.RoleName.ToString(), user);
                }
                else
                {
                    MessageBox.Show("Введите данные заново!");
                    ClearFields();
                    GenerateCaptcha();
                }
            }
        }

        private void LoadPage(string role, User user)
        {
            click = 0;
            switch (role)
            {
                case "Читатель":
                    NavigationService.Navigate(new Client(user, role));
                    break;
                case "Библиотекарь":
                    NavigationService.Navigate(new LibrarianPage(user, role));
                    break;
                case "Администратор":
                    NavigationService.Navigate(new AdminPage(user, role));
                    break;
            }
        }
    }
}
