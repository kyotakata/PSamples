//http://yujiro15.net/blog/index.php?id=148

using Prism.Mvvm;
using TabSample.ViewModels.Contents;

namespace TabSample.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "Prism Application";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private Content01ViewModel _content01ViewModel = new Content01ViewModel();
        public Content01ViewModel Content01ViewModel { get { return this._content01ViewModel; } }

        private Content02ViewModel _content02ViewModel = new Content02ViewModel();
        public Content02ViewModel Content02ViewModel { get { return this._content02ViewModel; } }

        private Content03ViewModel _content03ViewModel = new Content03ViewModel();
        public Content03ViewModel Content03ViewModel { get { return this._content03ViewModel; } }

        public MainWindowViewModel()
        {
            Content01ViewModel.CheckBoxComment = "a";
        }
    }
}
