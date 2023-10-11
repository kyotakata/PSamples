using Prism.Commands;
using Prism.Mvvm;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace ItemsControlBasic.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "Prism Application";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private ObservableCollection<Person> _people;
        public ObservableCollection<Person> People
        {
            get { return _people; }
            set { SetProperty(ref _people, value); }
        }

        private int _count;

        private DelegateCommand _addCommand;

        public DelegateCommand AddCommand
        {
            get
            {
                return this._addCommand ?? (this._addCommand = new DelegateCommand(
                    () =>
                    {
                        this._count++;
                        var person = new Person()
                        {
                            FamilyName = "田中",
                            FirstName = this._count + "太郎",
                            Age = this._count,
                        };
                        this.People.Add(person);
                        this.DeleteCommand.RaiseCanExecuteChanged();
                        System.Diagnostics.Debug.WriteLine(person.FullName + " を追加しました。");

                    }));
            }
        }

        private DelegateCommand _deleteCommand;

        public DelegateCommand DeleteCommand
        {
            get
            {
                return this._deleteCommand ?? (this._deleteCommand = new DelegateCommand(
                    () =>
                    {
                        this.People.RemoveAt(this.People.Count - 1);
                        this.DeleteCommand.RaiseCanExecuteChanged();
                    },
                    () => this.People.Count > 0
                    ));
            }
        }

        public MainWindowViewModel()
        {
            var peopleList = Enumerable.Range(0, 100).Select(x => new Person()
            {
                FamilyName = "田中",
                FirstName = x + "太郎",
                Age = x,
                Gender = (x % 2 ==0) ? Gender.Male : Gender.Female,
                IsAuthenticated = x % 3 == 0,
            }).ToList();

            this.People =new ObservableCollection<Person>(peopleList);
        }
    }
}
