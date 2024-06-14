using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using RecipeApp;
using ST10291856PROG6221Poe.Xaml_Files; // Adjust this namespace as per your project structure

namespace ST10291856PROG6221Poe.Xaml_Files
{
    /// <summary>
    /// Interaction logic for AddRecipe.xaml
    /// </summary>
    public partial class AddRecipe : Window
    {
        private ObservableCollection<string> ingredientsList;
        private ObservableCollection<string> stepsList;
        private RecipeManager recipeManager;

        public AddRecipe()
        {
            InitializeComponent();
            ingredientsList = new ObservableCollection<string>();
            stepsList = new ObservableCollection<string>();
            lbIngredients.ItemsSource = ingredientsList;
            lbSteps.ItemsSource = stepsList;
            recipeManager = new RecipeManager();
        }

        private void Homebtn(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow window = new MainWindow();
            window.Show();
        }

        private void Addbtn(object sender, RoutedEventArgs e)
        {
            this.Hide();
            AddRecipe window = new AddRecipe();
            window.Show();
        }

        private void Editbtn(object sender, RoutedEventArgs e)
        {
            this.Hide();
            EditRecipe window = new EditRecipe();
            window.Show();
        }

        private void btnAddIngredient_Click(object sender, RoutedEventArgs e)
        {
            // Implement functionality to add ingredients to ingredientsList
            // For example:
            // ingredientsList.Add("New Ingredient");
        }

        private void btnRemoveIngredient_Click(object sender, RoutedEventArgs e)
        {
            // Remove selected ingredient from ingredientsList
            if (lbIngredients.SelectedItem != null)
            {
                ingredientsList.Remove(lbIngredients.SelectedItem.ToString());
            }
        }

        private void btnAddStep_Click(object sender, RoutedEventArgs e)
        {
            // Implement functionality to add steps to stepsList
            // For example:
            // stepsList.Add("New Step");
        }

        private void btnRemoveStep_Click(object sender, RoutedEventArgs e)
        {
            // Remove selected step from stepsList
            if (lbSteps.SelectedItem != null)
            {
                stepsList.Remove(lbSteps.SelectedItem.ToString());
            }
        }

        private void AddRecipe_Click(object sender, RoutedEventArgs e)
        {
            // Create a new Recipe object and populate its properties
            Recipe recipe = new Recipe();
            recipe.Name = txtRecipeName.Text;

            // Add ingredients from ingredientsList to recipe
            foreach (var item in ingredientsList)
            {
                // Example: Parse item string into Ingredient properties
                // and add it to recipe's Ingredients list
            }

            // Add steps from stepsList to recipe
            foreach (var item in stepsList)
            {
                recipe.Steps.Add(item);
            }

            // Call AddRecipe method of RecipeManager
            recipeManager.AddRecipe(recipe);

            MessageBox.Show("Recipe added successfully!");

            // Clear input fields and lists after adding the recipe
            ClearFields();
        }

        private void ClearFields()
        {
            // Clear all input fields and lists
            txtRecipeName.Text = "";
            ingredientsList.Clear();
            stepsList.Clear();
        }
    }
}
