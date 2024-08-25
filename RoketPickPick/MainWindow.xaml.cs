using RoketPickPick.Core;
using RoketPickPick.Views;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;

namespace RoketPickPick
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            ObjectManager.Instance.Init();

            InitializeComponent();

            string mainimagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images", "main.jpg");

            MainImage.Source = new BitmapImage(new Uri(mainimagePath));

            string logoimagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images", "logo.png");

            ButtonLogo.Source = new BitmapImage(new Uri(logoimagePath));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new SecondWindow();
            dialog.ShowDialog();
        }
    }
}
