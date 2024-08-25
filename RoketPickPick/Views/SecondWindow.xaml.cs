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

namespace RoketPickPick.Views
{
    /// <summary>
    /// SecondWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class SecondWindow : Window
    {
        public SecondWindow()
        {
            InitializeComponent();

            string mainimagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images", "Category.png");

            MainImage.Source = new BitmapImage(new Uri(mainimagePath));
            this.WindowState = WindowState.Maximized;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new ThirdWindow();
            dialog.ShowDialog();
        }
    }
}
