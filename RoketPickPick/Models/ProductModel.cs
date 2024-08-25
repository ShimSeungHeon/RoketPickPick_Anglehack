using Prism.Mvvm;
using System.Linq;
using System.Windows.Media;

namespace RoketPickPick.Models
{
    public class ProductModel : BindableBase
    {
        private string _productName = string.Empty;
        public string ProductName
        {
            get => _productName;
            set => SetProperty(ref _productName, value);
        }

        private int _price;
        public int Price
        {
            get => _price;
            set
            {
                if (SetProperty(ref _price, value))
                {
                    PriceText = $"{value:N0}원";
                }
            }
        }

        private int _starCount;
        public int StarCount
        {
            get => _starCount;
            set
            {
                if (SetProperty(ref _starCount, value))
                {
                    if (value > 5) value = 5;
                    if (value < 0) value = 0;

                    FilledStarText = string.Join("", Enumerable.Repeat("★", value));
                    EmptyStarText = string.Join("", Enumerable.Repeat("★", 5 - value));
                }
            }
        }
        private string _filledStarText = "★★★★";
        public string FilledStarText
        {
            get => _filledStarText;
            set => SetProperty(ref _filledStarText, value);
        }
        private string _emptyStarText = "★";
        public string EmptyStarText
        {
            get => _emptyStarText;
            set => SetProperty(ref _emptyStarText, value);
        }

        private int _reviewCount;
        public int ReviewCount
        {
            get => _reviewCount;
            set
            {
                if (SetProperty(ref _reviewCount, value))
                {
                    ReviewText = $"({value})";
                }
            }
        }
        private string _reviewText = "(0)";
        public string ReviewText
        {
            get => _reviewText;
            set => SetProperty(ref _reviewText, value);
        }


        private bool _isSelected;
        public bool IsSelected
        {
            get => _isSelected;
            set
            {
                if (SetProperty(ref _isSelected, value))
                {
                    BackColor = value ? new SolidColorBrush(Colors.LightBlue) : new SolidColorBrush();
                }
            }
        }

        SolidColorBrush _backColor = new SolidColorBrush();
        public SolidColorBrush BackColor
        {
            get => _backColor;
            set => SetProperty(ref _backColor, value);
        }

        private string _priceText;
        public string PriceText
        {
            get => _priceText;
            set => SetProperty(ref _priceText, value);
        }

        private string _description = string.Empty;
        public string Description
        {
            get => _description;
            set => SetProperty(ref _description, value);
        }

        private string _tag;
        public string Tag
        {
            get => _tag;
            set => SetProperty(ref _tag, value);
        }

        private string _imagePath;
        public string ImagePath
        {
            get => _imagePath;
            set => SetProperty(ref _imagePath, value);
        }

        public ProductModel() { }

        public ProductModel(string tag, string name, int price, string description = "")
        {
            Tag = tag;
            ProductName = name;
            Price = price;
            Description = description;
        }
    }
}