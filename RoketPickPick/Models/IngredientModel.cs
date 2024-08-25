using Prism.Mvvm;
using RoketPickPick.Core;

namespace RoketPickPick.Models
{
    public class IngredientModel : BindableBase
    {
        private ProductModel _selectedProduct;
        public ProductModel SelectedProduct
        {
            get => _selectedProduct;
            set => SetProperty(ref _selectedProduct, value);
        }

        private int _amount;
        public int Amount
        {
            get => _amount;
            set
            {
                if (SetProperty(ref _amount, value))
                {
                    if (SelectedProduct != null)
                    {
                        Price = SelectedProduct.Price * value;
                        ObjectManager.Instance.Test.RefreshPrice();
                    }
                }
            }
        }

        private string _tag;
        public string Tag
        {
            get => _tag;
            set => SetProperty(ref _tag, value);
        }

        private int _price;
        public int Price
        {
            get => _price;
            set
            {
                if (SetProperty(ref _price, value))
                {
                    PriceText = $"{value:N0}";
                }
            }
        }

        private string _priceText;
        public string PriceText
        {
            get => _priceText;
            set => SetProperty(ref _priceText, value);
        }
    }
}