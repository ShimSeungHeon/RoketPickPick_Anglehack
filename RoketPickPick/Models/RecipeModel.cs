using Prism.Mvvm;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace RoketPickPick.Models
{
    public class RecipeModel : BindableBase
    {
        private List<string> _ingredientTags = new List<string>();
        public List<string> IngredientTags
        {
            get => _ingredientTags;
            set => SetProperty(ref _ingredientTags, value);
        }

        private string _name = string.Empty;
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        private int _minPrice;
        public int MinPrice
        {
            get => _minPrice;
            set => SetProperty(ref _minPrice, value);
        }

        private string _imagePath;
        public string ImagePath
        {
            get => _imagePath;
            set => SetProperty(ref _imagePath, value);
        }

        private int _totalPrice;
        public int TotalPrice
        {
            get => _totalPrice;
            set
            {
                if (SetProperty(ref _totalPrice, value))
                {
                    TotalPriceText = $"{value:N0}";
                }
            }
        }

        private string _totalPriceText;
        public string TotalPriceText
        {
            get => _totalPriceText;
            set => SetProperty(ref _totalPriceText, value);
        }

        public void RefreshPrice()
        {
            TotalPrice = CartItems.Select(i => i.Price).Sum();
        }

        //private ObservableCollection<IngredientModel> _selectedIngredients = new ObservableCollection<IngredientModel>();
        //public ObservableCollection<IngredientModel> SelectedIngredients
        //{
        //    get => _selectedIngredients;
        //    set => SetProperty(ref _selectedIngredients, value);
        //}

        public Dictionary<string, IngredientModel> SelectedIngredients = new Dictionary<string, IngredientModel>();

        private ObservableCollection<IngredientModel> _cartItems = new ObservableCollection<IngredientModel>();
        public ObservableCollection<IngredientModel> CartItems
        {
            get => _cartItems;
            set => SetProperty(ref _cartItems, value);
        }
    }
}
