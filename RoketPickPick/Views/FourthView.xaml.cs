using RoketPickPick.Core;
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
using System.Windows.Shapes;

namespace RoketPickPick.Views
{
    /// <summary>
    /// FourthView.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class FourthView : Window
    {
        public FourthView()
        {
            ObjectManager.Instance.Init();
            this.WindowState = WindowState.Maximized;
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ObjectManager.Instance.Test.RefreshPrice();
            var view = new fifth();
            view.ShowDialog();
        }
    }
}
