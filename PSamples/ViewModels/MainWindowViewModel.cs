using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using PSamples.Views;
using System.Windows;

namespace PSamples.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        /// <summary>
        /// PrismのRegionManagerを受け取る用のPrivate変数
        /// </summary>
        private IRegionManager _regionManager;

        /// <summary>
        /// PrismのDialogServiceを受け取る用のPrivate変数
        /// </summary>
        private IDialogService _dialogService;


        #region 画面用プロパティ
        private string _title = "PSamples";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private bool _buttonEnabled = false;
        /// <summary>
        /// ボタン押下可否プロパティ
        /// </summary>
        public bool ButtonEnabled
        {
            get { return _buttonEnabled; }
            set { SetProperty(ref _buttonEnabled, value); }
        }

        private bool _pButtonEnabled = false;
        /// <summary>
        /// Pボタン押下可否プロパティ
        /// </summary>
        public bool PButtonEnabled
        {
            get { return _pButtonEnabled; }
            set { SetProperty(ref _pButtonEnabled, value); }
        }

        private bool _visibility = false;
        /// <summary>
        /// VVVボタン表示非表示切り替えプロパティ
        /// BooleanVisibilityConverterによりboolからVisibilityに変換される
        /// </summary>
        public bool Visibility
        {
            get { return _visibility; }
            set { SetProperty(ref _visibility, value); }
        }

        private string _systemDateLabel
    = System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");

        /// <summary>
        /// システム日時
        /// </summary>
        public string SystemDateLabel
        {
            get { return _systemDateLabel; }
            set { SetProperty(ref _systemDateLabel, value); }
        }

        #endregion 画面用プロパティ

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="regionManager">Prismが自動でRegionManagerを依存性注入してくれる</param>
        /// <param name="dialogService">Prismが自動でDialogServiceを依存性注入してくれる</param>
        public MainWindowViewModel(
            IRegionManager regionManager,
            IDialogService dialogService)
        {
            _regionManager = regionManager;
            _dialogService = dialogService;
            SystemDateUpdateButton = new DelegateCommand(
                SystemDateUpdateButtonExecute);
            ShowViewAButton = new DelegateCommand(
                ShowViewAButtonExecute)
                .ObservesCanExecute(()=> ButtonEnabled);
            ShowViewPButton = new DelegateCommand(
                ShowViewPButtonExecute);
            ShowViewBButton = new DelegateCommand(
                ShowViewBButtonExecute);
            ShowViewCButton = new DelegateCommand(
                ShowViewCButtonExecute);
        }

        #region コマンド

        /// <summary>
        /// システム日時更新ボタン
        /// </summary>
        public DelegateCommand SystemDateUpdateButton { get; }

        /// <summary>
        /// ViewA画面遷移ボタン
        /// </summary>
        public DelegateCommand ShowViewAButton { get; }

        /// <summary>
        /// ViewA画面遷移ボタン(パラメータ有り)
        /// </summary>
        public DelegateCommand ShowViewPButton { get; }

        /// <summary>
        /// ViewBポップアップ画面遷移ボタン
        /// </summary>
        public DelegateCommand ShowViewBButton { get; }

        /// <summary>
        /// ViewC画面遷移ボタン
        /// </summary>
        public DelegateCommand ShowViewCButton { get; }

        #endregion コマンド

        #region コマンド用Privateメソッド

        /// <summary>
        /// システム日時更新メソッド
        /// </summary>
        private void SystemDateUpdateButtonExecute()
        {
            ButtonEnabled = true;
            PButtonEnabled = true;
            Visibility = true;
            SystemDateLabel 
                = System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
        }

        /// <summary>
        /// ViewA画面遷移メソッド
        /// </summary>
        private void ShowViewAButtonExecute()
        {
            _regionManager.RequestNavigate(
                "ContentRegion", nameof(ViewA));// 第一引数には表示したい場所、第二引数にはViewの名前を指定する
        }

        /// <summary>
        /// ViewA画面遷移メソッド(パラメータ有り)
        /// </summary>
        private void ShowViewPButtonExecute()
        {
            var p = new NavigationParameters();
            p.Add(nameof(ViewAViewModel.MyLabel), SystemDateLabel);// 第一引数のキーは画面遷移先のプロパティの名前にしておくのが良い。
            _regionManager.RequestNavigate(
               "ContentRegion", nameof(ViewA), p);// 第一引数には表示したい場所、第二引数にはViewの名前、第三引数にはパラメータを指定する
        }
    

        /// <summary>
        /// ViewBポップアップ画面遷移メソッド
        /// </summary>
        private void ShowViewBButtonExecute()
        {
            var p = new DialogParameters();
            p.Add(nameof(ViewBViewModel.ViewBTextBox), SystemDateLabel);// 第一引数のキーは画面遷移先のプロパティの名前にしておくのが良い。
            _dialogService.ShowDialog(nameof(ViewB), p, ViewBClose);// 第一引数にはViewの名前、第二引数にはパラメータ、第三引数には画面が閉じられたときのActionを指定する。尚、第二引数と第三引数はnullでもポップアップ表示可能。
        }

        /// <summary>
        /// ViewBポップアップ画面が閉じられたときに通過するメソッド(IDialogResult型の引数のActionにする)
        /// </summary>
        /// <param name="dialogResult">ここでViewBModelのOKButtonExecuteで定義したnew DialogResult(ButtonResult.OK, p)を受け取れる</param>
        private void ViewBClose(IDialogResult dialogResult)
        {
            if (dialogResult.Result == ButtonResult.OK)
            {
                SystemDateLabel = dialogResult.Parameters.
                    GetValue<string>(nameof(ViewBViewModel.ViewBTextBox));
            }
        }


        private void ShowViewCButtonExecute()
        {
            _regionManager.RequestNavigate(
               "ContentRegion", nameof(ViewC));
        }

        #endregion コマンド用Privateメソッド
    }
}
