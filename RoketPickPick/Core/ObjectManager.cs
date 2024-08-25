using Prism.Mvvm;
using RoketPickPick.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace RoketPickPick.Core
{
    public class ObjectManager : BindableBase
    {
        #region Singleton
        private static ObjectManager _instance;
        public static ObjectManager Instance => _instance ?? (_instance = new ObjectManager());
        private ObjectManager() { }
        #endregion

        private ObservableCollection<ProductModel> _totalProducts = new ObservableCollection<ProductModel>(
            new ProductModel[] {
                new ProductModel("마늘", "깐마늘1", 1200),
                new ProductModel("마늘", "깐마늘2", 1300),
                new ProductModel("마늘", "깐마늘3", 1250),
                new ProductModel("마늘", "생마늘1", 1700),
                new ProductModel("마늘", "생마늘2", 1600),
                new ProductModel("마늘", "생마늘3", 1800),
            });
        public ObservableCollection<ProductModel> TotalProducts
        {
            get => _totalProducts;
            set => SetProperty(ref _totalProducts, value);
        }

        private ObservableCollection<RecipeModel> _totalRecipes = new ObservableCollection<RecipeModel>();
        public ObservableCollection<RecipeModel> TotalRecipes
        {
            get => _totalRecipes;
            set => SetProperty(ref _totalRecipes, value);
        }

        private RecipeModel _test = new RecipeModel()
        {
            Name = "김치찌개",
            MinPrice = 7800,
            IngredientTags = new List<string>(new string[] { "김치", "두부", "마늘", "대파", "된장", "간장" }),
        };
        public RecipeModel Test
        {
            get => _test;
            set => SetProperty(ref _test, value);
        }



        public void Init()
        {
            var recipeFolderPath = @"Recipes";
            var productFolderPath = @"Products";

            TotalRecipes.AddRange(DataParser.ParseRecipes(recipeFolderPath));

            TotalProducts.AddRange(DataParser.ParseProducts(productFolderPath));

            if (TotalRecipes.Count != 0) Test = TotalRecipes[0];
        }
    }
}
