using DataBindSample_01.ViewModels;
using System.Windows;

namespace DataBindSample_01.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.DataContext = new MainWindowViewModel();// MainWindowViewModelをDataContextに設定
            InitializeComponent();
        }
    }
}
