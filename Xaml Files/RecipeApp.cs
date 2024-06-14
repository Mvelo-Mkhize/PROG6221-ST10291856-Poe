using System;
using System.Collections.Generic;
using System.Linq;

namespace RecipeApp
{
    class RecipeApp
    {
        static void Main(string[] args)
        {
            RecipeManager recipeManager = new RecipeManager();
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("Recipe Manager");
                Console.WriteLine("1. Add Recipe");
                Console.WriteLine("2. View Recipes");
                Console.WriteLine("3. Display Recipe");
                Console.WriteLine("4. Scale Recipe");
                Console.WriteLine("5. Reset Recipe Quantities");
                Console.WriteLine("6. Clear Data");
                Console.WriteLine("7. Exit");
                Console.Write("Choose an option: ");
                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        recipeManager.AddRecipe(); // Call to AddRecipe without parameters
                        break;
                    case "2":
                        recipeManager.ViewRecipes();
                        break;
                    case "3":
                        recipeManager.DisplayRecipe();
                        break;
                    case "4":
                        recipeManager.ScaleRecipe();
                        break;
                    case "5":
                        recipeManager.ResetQuantities();
                        break;
                    case "6":
                        recipeManager.ClearData();
                        break;
                    case "7":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }
    }

    class RecipeManager
    {
        private List<Recipe> recipes = new List<Recipe>();

        public void AddRecipe(Recipe recipe)
        {
            recipes.Add(recipe);
            Console.WriteLine("Recipe added successfully!");
        }

        public void ViewRecipes()
        {
            Console.WriteLine("Recipes:");
            foreach (var recipe in recipes.OrderBy(r => r.Name))
            {
                Console.WriteLine(recipe.Name);
            }
        }

        public void DisplayRecipe()
        {
            Console.Write("Enter the name of the recipe to display: ");
            string recipeName = Console.ReadLine();

            Recipe recipe = recipes.FirstOrDefault(r => r.Name.Equals(recipeName, StringComparison.OrdinalIgnoreCase));

            if (recipe == null)
            {
                Console.WriteLine("Recipe not found.");
                return;
            }

            recipe.Display();
        }

        public void ScaleRecipe()
        {
            Console.Write("Enter the name of the recipe to scale: ");
            string recipeName = Console.ReadLine();

            Recipe recipe = recipes.FirstOrDefault(r => r.Name.Equals(recipeName, StringComparison.OrdinalIgnoreCase));

            if (recipe == null)
            {
                Console.WriteLine("Recipe not found.");
                return;
            }

            Console.Write("Enter the scaling factor (0.5, 2, 3): ");
            double factor;
            while (!double.TryParse(Console.ReadLine(), out factor) || (factor != 0.5 && factor != 2 && factor != 3))
            {
                Console.WriteLine("Invalid input. Please enter a valid scaling factor (0.5, 2, 3).");
                Console.Write("Enter the scaling factor (0.5, 2, 3): ");
            }

            recipe.Scale(factor);
            Console.WriteLine("Recipe scaled successfully!");
        }

        public void ResetQuantities()
        {
            Console.Write("Enter the name of the recipe to reset quantities: ");
            string recipeName = Console.ReadLine();

            Recipe recipe = recipes.FirstOrDefault(r => r.Name.Equals(recipeName, StringComparison.OrdinalIgnoreCase));

            if (recipe == null)
            {
                Console.WriteLine("Recipe not found.");
                return;
            }

            recipe.ResetQuantities();
            Console.WriteLine("Recipe quantities reset successfully!");
        }

        public void ClearData()
        {
            recipes.Clear();
            Console.WriteLine("All data cleared.");
        }
    }

    class Recipe
    {
        public string Name { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public List<string> Steps { get; set; }
        public double TotalCalories { get; private set; }

        public Recipe()
        {
            Ingredients = new List<Ingredient>();
            Steps = new List<string>();
            TotalCalories = 0;
        }

        public void Display()
        {
            Console.WriteLine($"Recipe: {Name}");
            Console.WriteLine("Ingredients:");
            foreach (var ingredient in Ingredients)
            {
                Console.WriteLine($"- {ingredient.Quantity} {ingredient.Unit} of {ingredient.Name} ({ingredient.Calories} calories)");
            }
            Console.WriteLine($"Total Calories: {TotalCalories}");

            Console.WriteLine("Steps:");
            for (int i = 0; i < Steps.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Steps[i]}");
            }
        }

        public void CalculateTotalCalories()
        {
            TotalCalories = Ingredients.Sum(ingredient => ingredient.Calories);
        }

        public void Scale(double factor)
        {
            foreach (var ingredient in Ingredients)
            {
                ingredient.Quantity *= factor;
            }
            CalculateTotalCalories();
        }

        public void ResetQuantities()
        {
            foreach (var ingredient in Ingredients)
            {
                ingredient.Quantity = 0;
            }
            CalculateTotalCalories();
        }
    }

    class Ingredient
    {
        public string Name { get; set; }
        public double Quantity { get; set; }
        public string Unit { get; set; }
        public double Calories { get; set; }
        public string FoodGroup { get; set; }
    }
}
