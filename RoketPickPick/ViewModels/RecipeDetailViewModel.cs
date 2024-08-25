using Prism.Commands;
using Prism.Mvvm;
using RoketPickPick.Core;
using RoketPickPick.Models;

namespace RoketPickPick.ViewModels
{
    public class RecipeDetailViewModel : BindableBase
    {
        RecipeModel _recipe;
        public RecipeModel Recipe
        {
            get => _recipe;
            set => SetProperty(ref _recipe, value);
        }

        string _selectedTag = "다진마늘";
        public string SelectedTag
        {
            get => _selectedTag;
            set
            {
                if (SetProperty(ref _selectedTag, value))
                {
                    if (Recipe.SelectedIngredients.ContainsKey(value))
                    {
                        SelectedProduct = Recipe.SelectedIngredients[value].SelectedProduct;
                    }
                }
            }
        }

        private int _progress;
        public int Progress
        {
            get => _progress;
            set => SetProperty(ref _progress, value);
        }

        ProductModel _selectedProduct;
        public ProductModel SelectedProduct
        {
            get => _selectedProduct;
            set
            {
                if(SetProperty(ref _selectedProduct, value))
                {
                    if (value == null) return;

                    value.IsSelected = true;

                    if (!Recipe.SelectedIngredients.ContainsKey(SelectedTag))
                    {
                        Recipe.SelectedIngredients.Add(SelectedTag, new IngredientModel()
                        {
                            SelectedProduct = value,
                            Amount = 1,
                        });

                        ObjectManager.Instance.Test.CartItems.Add(Recipe.SelectedIngredients[SelectedTag]);
                    }
                    else
                    {
                        if (value != Recipe.SelectedIngredients[SelectedTag].SelectedProduct)
                        {
                            Recipe.SelectedIngredients[SelectedTag].SelectedProduct.IsSelected = false;
                            ObjectManager.Instance.Test.CartItems.Remove(Recipe.SelectedIngredients[SelectedTag]);
                        }
                        Recipe.SelectedIngredients[SelectedTag].SelectedProduct = value;
                    }
                }
            }
        }

        private DelegateCommand<string> _buttonClickCommand;
        public DelegateCommand<string> ButtonClickCommand => _buttonClickCommand ?? (_buttonClickCommand = new DelegateCommand<string>(executeButtonClickCommand));
        private void executeButtonClickCommand(string parameter)
        {
            SelectedTag = parameter;
        }

    }
}