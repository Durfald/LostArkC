using LostArkManager.LOSTARK.Extensions;
using LostArkManager.LOSTARK.Parser;
using System.Diagnostics;
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

namespace LostArkManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LAParser.Send("Durfald");
            //Button button = new();
            //button.Width = 40;
            //button.Height = 40;
            //button.Style= (Style)Application.Current.FindResource("BingoSkullButtonStyle");
            //ImageButton.SetImageSource(button, new BitmapImage(new Uri("/YourProjectName;component/Images/NewImage.png", UriKind.Relative)));
            //MG.Children.Add(button);
        }
    }
}