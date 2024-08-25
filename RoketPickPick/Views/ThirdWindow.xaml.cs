using System;
using System.Collections.Generic;
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
using System.IO;

namespace RoketPickPick.Views
{
    /// <summary>
    /// ThirdWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ThirdWindow : Window
    {
        public ThirdWindow()
        {
            InitializeComponent();
            this.WindowState = WindowState.Maximized;
            string mainimagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images", "kfood.png");

            MainImage.Source = new BitmapImage(new Uri(mainimagePath));

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new FourthView();
            dialog.ShowDialog();
        }
    }
}

