using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ST10291856PROG6221Poe.Xaml_Files
{
    /// <summary>
    /// Interaction logic for EditRecipe.xaml
    /// </summary>
    public partial class EditRecipe : Window
    {
        public EditRecipe()
        {
            InitializeComponent();
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
    }
}
