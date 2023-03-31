using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using PSamples.Views;

namespace PSamples.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private IRegionManager _regionManager;
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
        public string SystemDateLabel
        {
            get { return _systemDateLabel; }
            set { SetProperty(ref _systemDateLabel, value); }
        }

        public DelegateCommand SystemDateUpdateButton { get; }

        public DelegateCommand ShowViewAButton { get; }
        public DelegateCommand ShowViewPButton { get; }

        public DelegateCommand ShowViewBButton { get; }
        public DelegateCommand ShowViewCButton { get; }

        private void SystemDateUpdateButtonExecute()
        {
            ButtonEnabled = true;
            SystemDateLabel 
                = System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
        }

        private void ShowViewAButtonExecute()
        {
            _regionManager.RequestNavigate(
                "ContentRegion", nameof(ViewA));
        }

        private void ShowViewPButtonExecute()
        {
            var p = new NavigationParameters();
            p.Add(nameof(ViewAViewModel.MyLabel), SystemDateLabel);
            _regionManager.RequestNavigate(
               "ContentRegion", nameof(ViewA), p);
        }

        private void ShowViewBButtonExecute()
        {
            var p = new DialogParameters();
            p.Add(nameof(ViewBViewModel.ViewBTextBox), SystemDateLabel);
            _dialogService.ShowDialog(nameof(ViewB), p, ViewBClose);
        }

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
