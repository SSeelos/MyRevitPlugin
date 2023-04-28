using MyRevitViewModels;
using System.Windows;

namespace MyRevitViews
{
    /// <summary>
    /// Interaction logic for MainV.xaml
    /// </summary>
    public partial class MainV : Window
    {
        public MainV(MainVM mainVM)
        {
            DataContext = mainVM;
            InitializeComponent();
        }
    }
}
