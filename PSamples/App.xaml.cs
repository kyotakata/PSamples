using PSamples.Views;
using Prism.Ioc;
using Prism.Modularity;
using System.Windows;
using PSamples.ViewModels;

namespace PSamples
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(
            IContainerRegistry containerRegistry)
        {
            // 画面遷移するViewを登録する
            containerRegistry.RegisterForNavigation<ViewA>();
            containerRegistry.RegisterForNavigation<ViewC>();
            containerRegistry.RegisterDialog<ViewB, ViewBViewModel>();// ダイアログの場合

            containerRegistry.RegisterSingleton<MainWindowViewModel>();
        }
    }
}
