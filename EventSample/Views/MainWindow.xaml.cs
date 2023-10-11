using EventSample.ViewModels;
using System.Windows;

namespace EventSample.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var vm = new MainWindowViewModel();
            if (vm == null) return;

            //vm.MouceDownCommand += (_, _) => { };// イベントハンドラが登録されないままにイベントが発生した場合に備えたもの
        }
    }
}
