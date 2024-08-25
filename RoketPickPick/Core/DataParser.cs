using RoketPickPick.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace RoketPickPick.Core
{
    public static class DataParser
    {
        public static List<RecipeModel> ParseRecipes(string folderPath)
        {
            var recipes = new List<RecipeModel>();

            foreach (var file in Directory.GetFiles(folderPath, "*.txt"))
            {
                var lines = File.ReadAllLines(file);
                var recipe = new RecipeModel
                {
                    Name = lines.FirstOrDefault(l => l.StartsWith("Name:"))?.Split(':')[1].Trim(),
                    IngredientTags = lines.FirstOrDefault(l => l.StartsWith("Tag:"))?.Split(':')[1].Trim().Split(',').ToList(),
                    ImagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images", lines.FirstOrDefault(l => l.StartsWith("Image:"))?.Split(':')[1].Trim())
                };
                recipes.Add(recipe);
            }

            return recipes;
        }

        public static List<ProductModel> ParseProducts(string folderPath)
        {
            var products = new List<ProductModel>();

            foreach (var file in Directory.GetFiles(folderPath, "*.txt"))
            {
                var lines = File.ReadAllLines(file);
                var product = new ProductModel
                {
                    ProductName = lines.FirstOrDefault(l => l.StartsWith("Name:"))?.Split(':')[1].Trim(),
                    Price = int.Parse(lines.FirstOrDefault(l => l.StartsWith("Price:"))?.Split(':')[1].Trim()),
                    Tag = lines.FirstOrDefault(l => l.StartsWith("Tag:"))?.Split(':')[1].Trim(),
                    ImagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images", lines.FirstOrDefault(l => l.StartsWith("Image:"))?.Split(':')[1].Trim())
                };
                products.Add(product);
            }

            return products;
        }
    }
}
