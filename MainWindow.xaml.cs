using System;
using System.Windows;
using Sheremetov_Authorization.Pages;

namespace Sheremetov_Authorization
{
    /// <summary>
    /// Главное окно приложения: шапка с логотипом и кнопкой «Назад»,
    /// фрейм для отображения страниц
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            FrmMain.Navigate(new Autho());
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            FrmMain.GoBack();
        }

        /// <summary>
        /// Кнопка «Назад» видна только тогда, когда есть куда возвращаться
        /// </summary>
        private void FrmMain_ContentRendered(object sender, EventArgs e)
        {
            if (FrmMain.CanGoBack)
                btnBack.Visibility = Visibility.Visible;
            else
                btnBack.Visibility = Visibility.Hidden;
        }
    }
}
