using Prism.Commands;
using RoketPickPick.Models;
using System.Windows;
using System.Windows.Controls;

namespace RoketPickPick.Items
{
    /// <summary>
    /// RecipeCardItem.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ProductCardItem : UserControl
    {
        public ProductCardItem()
        {
            InitializeComponent();
        }

        public ProductModel Product
        {
            get { return (ProductModel)GetValue(ProductProperty); }
            set { SetValue(ProductProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Name.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ProductProperty =
            DependencyProperty.Register(nameof(Product), typeof(ProductModel), typeof(ProductCardItem), new PropertyMetadata(default));

        public DelegateCommand<ProductModel> Command
        {
            get { return (DelegateCommand<ProductModel>)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Command.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.Register(nameof(Command), typeof(DelegateCommand<ProductModel>), typeof(ProductCardItem), new PropertyMetadata(default));


    }
}