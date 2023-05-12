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

            // ここに登録しておくことでコンストラクタに引数を指定した時、自動的にDIしてくれる
            containerRegistry.RegisterSingleton<MainWindowViewModel>();// メイン画面はアプリケーションでただ１つしかないため、シングルトン設定をしておく。
                                                                       // メイン画面から画面遷移したとしてもメイン画面が切り替わるわけではなく、メイン画面上にUserControlをおいているイメージなので、メイン画面は１つしかない。
        }
    }
}
