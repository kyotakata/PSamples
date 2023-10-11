using Prism.Mvvm;

namespace DataBindSample_03_UserControl.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "Prism Application";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private string _hoge = "ほげ Application";
        public string Hoge
        {
            get { return _hoge; }
            set { SetProperty(ref _hoge, value); }
        }

        public MainWindowViewModel()
        {

        }
    }
}
