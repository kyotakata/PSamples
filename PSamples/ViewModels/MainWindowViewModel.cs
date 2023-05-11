using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using PSamples.Views;

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
        
        private string _title = "PSamples";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private bool _buttonEnabled = false;
        public bool ButtonEnabled
        {
            get { return _buttonEnabled; }
            set { SetProperty(ref _buttonEnabled, value); }
        }

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
        /// ViewB画面遷移ボタン
        /// </summary>
        public DelegateCommand ShowViewBButton { get; }
        public DelegateCommand ShowViewCButton { get; }

        private void SystemDateUpdateButtonExecute()
        {
            ButtonEnabled = true;
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
        /// ViewB画面遷移メソッド
        /// </summary>
        private void ShowViewBButtonExecute()
        {
            var p = new DialogParameters();
            p.Add(nameof(ViewBViewModel.ViewBTextBox), SystemDateLabel);// 第一引数のキーは画面遷移先のプロパティの名前にしておくのが良い。
            _dialogService.ShowDialog(nameof(ViewB), p, ViewBClose);// 第一引数にはViewの名前、第二引数にはパラメータ、第三引数には画面が閉じられたときのActionを指定する。尚、第二引数と第三引数はnullでもポップアップ表示可能。
        }

        /// <summary>
        /// ポップアップが閉じられたときに通過するメソッド(IDialogResult型の引数のActionにする)
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
    }
}
