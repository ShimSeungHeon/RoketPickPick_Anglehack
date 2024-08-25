using RoketPickPick.Models;
using RoketPickPick.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace RoketPickPick.Views
{
    /// <summary>
    /// SelectingPage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class RecipeDetailView : UserControl
    {
        public RecipeDetailView()
        {
            InitializeComponent();
        }

        public RecipeModel Recipe
        {
            get { return (RecipeModel)GetValue(RecipeProperty); }
            set { SetValue(RecipeProperty, value); }
        }

        public static readonly DependencyProperty RecipeProperty =
            DependencyProperty.Register(nameof(Recipe), typeof(RecipeModel), typeof(RecipeDetailView), new PropertyMetadata(default, propertyChangedCallback));

        private static void propertyChangedCallback(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            if (sender is RecipeDetailView obj && obj.DataContext is RecipeDetailViewModel vm)
            {
                vm.Recipe = e.NewValue as RecipeModel;
            }
        }
    }
}