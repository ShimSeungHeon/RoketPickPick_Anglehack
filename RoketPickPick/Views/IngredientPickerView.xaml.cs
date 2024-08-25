using Prism.Commands;
using RoketPickPick.Core;
using RoketPickPick.Models;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace RoketPickPick.Views
{
    /// <summary>
    /// IngredientSelectingPage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class IngredientPickerView : UserControl
    {
        public IngredientPickerView()
        {
            InitializeComponent();

            ItemPickCommand = new DelegateCommand<ProductModel>(execute);
        }



        public string ItemTag
        {
            get { return (string)GetValue(ItemTagProperty); }
            set { SetValue(ItemTagProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Tag.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ItemTagProperty =
            DependencyProperty.Register(nameof(ItemTag), typeof(string), typeof(IngredientPickerView), new PropertyMetadata(string.Empty, propertyChangedCallback));

        private static void propertyChangedCallback(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            if (sender is IngredientPickerView obj && !string.IsNullOrWhiteSpace((string)e.NewValue))
            {
                obj.Products = new ObservableCollection<ProductModel>(ObjectManager.Instance.TotalProducts.Where(i => i.Tag == (string)e.NewValue));
            }
        }


        public ObservableCollection<ProductModel> Products
        {
            get { return (ObservableCollection<ProductModel>)GetValue(ProductsProperty); }
            set { SetValue(ProductsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ProductsProperty =
            DependencyProperty.Register(nameof(Products), typeof(ObservableCollection<ProductModel>), typeof(IngredientPickerView), new PropertyMetadata(default));




        public ProductModel SelectedProduct
        {
            get { return (ProductModel)GetValue(SelectedProductProperty); }
            set { SetValue(SelectedProductProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedProductProperty =
            DependencyProperty.Register(nameof(SelectedProduct), typeof(ProductModel), typeof(IngredientPickerView), new PropertyMetadata(default(ProductModel)));


        public DelegateCommand<ProductModel> ItemPickCommand
        {
            get { return (DelegateCommand<ProductModel>)GetValue(ItemPickCommandProperty); }
            set { SetValue(ItemPickCommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Command.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ItemPickCommandProperty =
            DependencyProperty.Register(nameof(ItemPickCommand), typeof(DelegateCommand<ProductModel>), typeof(IngredientPickerView), new PropertyMetadata(default));

        private void execute(ProductModel item)
        {
            SelectedProduct = item;
        }
    }
}
