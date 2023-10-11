using DataBindSample_02.ViewModels;
using System.Windows;

namespace DataBindSample_02.Views
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
