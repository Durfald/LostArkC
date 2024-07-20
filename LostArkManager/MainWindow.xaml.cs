using LostArkManager.Frames;
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
            //FrameNav.Navigate(new CharacterInfoPage());
            LAParser.GetCharacterv2("Durfald");
            
        }
    }
}