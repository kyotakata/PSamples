using Prism.Mvvm;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DataBindSample_01.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "Prism Application";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public string Name => "Hoge";

        public ObservableCollection<ItemViewModel> Items { get; }
            = new ObservableCollection<ItemViewModel>();

        public MainWindowViewModel()
        {
            var index = 0;
            Items.Add(new ItemViewModel(index++) { ItemName = "foo" });
            Items.Add(new ItemViewModel(index++) { ItemName = "bar" });
            Items.Add(new ItemViewModel(index++) { ItemName = "buz" });
        }
    }

    public class ItemViewModel : BindableBase
    {

        public string ItemName
        {
            get => itemName;
            set => SetProperty(ref itemName, value);
        }

        public int Id { get; }

        public ItemViewModel(int id)
        {
            Id = id;
        }


        private string itemName;
    }
}
