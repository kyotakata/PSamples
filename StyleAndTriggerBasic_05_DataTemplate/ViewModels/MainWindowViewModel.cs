using Prism.Mvvm;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.Windows.Media;

namespace StyleAndTriggerBasic_05_DataTemplate.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "Prism Application";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        //private static ObservableCollection<ColorViewModel> _colors;
        //public static ObservableCollection<ColorViewModel> Colors
        //{
        //    get { return _colors; }
        //    set { SetProperty(ref _colors, value); }
        //}

        private static IList<ColorViewModel> colors = new List<ColorViewModel>
        {
            new ColorViewModel{ Name="赤", Color= Colors.Red },
            new ColorViewModel{ Name="黄", Color= Colors.Yellow },
            new ColorViewModel{ Name="青", Color= Colors.Blue },
        };

        public static IList<ColorViewModel> ColorList { get{ return colors; } }

        public MainWindowViewModel()
        {
        }

    }

    public class ColorViewModel : BindableBase
    {

        private string _name;
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        private Color _color;
        public Color Color
        {
            get { return _color; }
            set { SetProperty(ref _color, value); }
        }

        public ColorViewModel()
        {

        }
    }

}
