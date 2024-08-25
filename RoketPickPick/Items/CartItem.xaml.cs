using RoketPickPick.Models;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RoketPickPick.Items
{
    /// <summary>
    /// CartItem.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class CartItem : UserControl
    {
        public CartItem()
        {
            InitializeComponent();
        }



        public IngredientModel Ingredient
        {
            get { return (IngredientModel)GetValue(IngredientProperty); }
            set { SetValue(IngredientProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Product.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IngredientProperty =
            DependencyProperty.Register(nameof(Ingredient), typeof(IngredientModel), typeof(CartItem), new PropertyMetadata(default));

        private void Button_Plus_Click(object sender, RoutedEventArgs e)
        {
            if (Ingredient != null)
            {
                Ingredient.Amount += 1;
            }
        }

        private void Button_Minus_Click(object sender, RoutedEventArgs e)
        {
            if (Ingredient != null && Ingredient.Amount >= 2)
            {
                Ingredient.Amount -= 1;
            }
        }
    }
}