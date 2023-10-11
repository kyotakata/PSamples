using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.ObjectModel;

namespace DataBindSample_02.ViewModels
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

        public ObservableCollection<SelectionViewModel> Selections { get; }
            = new ObservableCollection<SelectionViewModel>();

        private SelectionViewModel _selection;

        /// <summary>
        /// ComboBoxへBindingされた選択された値
        /// </summary>
        public SelectionViewModel Selection
        {
            get { return _selection; }
            set { SetProperty(ref _selection, value); }
        }

        public DelegateCommand<object> RemoveCommand { get; }

        public MainWindowViewModel()
        {
            var index = 0;
            Items.Add(new ItemViewModel(index++) { ItemName = "foo" });
            Items.Add(new ItemViewModel(index++) { ItemName = "bar" });
            Items.Add(new ItemViewModel(index++) { ItemName = "buz" });

            var indexSelection = 0;
            Selections.Add(new SelectionViewModel(indexSelection++) { SelectionName = "foo" });
            Selections.Add(new SelectionViewModel(indexSelection++) { SelectionName = "bar" });
            Selections.Add(new SelectionViewModel(indexSelection++) { SelectionName = "buz" });

            RemoveCommand = new DelegateCommand<object>(RemoveCommandExecute);
        }

        private void RemoveCommandExecute(object parameter)
        {
            if(parameter is int i)
            {
                RemoveId(Items, i);
            }
        }

        private void RemoveId(ObservableCollection<ItemViewModel> items, int i)
        {
            var index = 0;
            foreach (var item in items)
            {
               if(item.Id == i)
                {
                    index = items.IndexOf(item);
                }
            }
            Items?.Remove(items?[index]);

        }
    }

    public class ItemViewModel : BindableBase
    {
        private string _itemName;

        public string ItemName
        {
            get => _itemName;
            set => SetProperty(ref _itemName, value);
        }

        public int Id { get; }

        public ItemViewModel(int id)
        {
            Id = id;
        }


    }

    public class SelectionViewModel : BindableBase
    {

        public string SelectionName
        {
            get => _selectionName;
            set => SetProperty(ref _selectionName, value);
        }

        public int Id { get; }

        public SelectionViewModel(int id)
        {
            Id = id;
        }


        private string _selectionName;
    }

}
