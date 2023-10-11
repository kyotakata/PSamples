using Prism.Mvvm;

namespace StyleAndTriggerBasic_02.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "Prism Application";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public MainWindowViewModel()
        {

        }

        private bool _flag = true;
        public bool Flag
        {
            get { return _flag; }
            set { SetProperty(ref _flag, value); }
        }

    }
}
