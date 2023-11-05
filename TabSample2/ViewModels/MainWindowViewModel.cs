using Prism.Mvvm;
using TabSample2.ViewModels.Contents;

namespace TabSample2.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "Prism Application";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private ViewModelBase _content01ViewModel = new Content01ViewModel();
        public ViewModelBase Content01ViewModel { get { return this._content01ViewModel; } }

        private ViewModelBase _content02ViewModel = new Content02ViewModel();
        public ViewModelBase Content02ViewModel { get { return this._content02ViewModel; } }

        private ViewModelBase _content03ViewModel = new Content03ViewModel();
        public ViewModelBase Content03ViewModel { get { return this._content03ViewModel; } }


        public MainWindowViewModel()
        {

        }
    }
}
