using ST10291856PROG6221Poe.Xaml_Files;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PROG6221_ST10291856_Poe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
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
        private void Viewbtn(object sender, RoutedEventArgs e)
        {
            this.Hide();
            ViewRecipe window = new ViewRecipe();
            window.Show();
        }
    }
}