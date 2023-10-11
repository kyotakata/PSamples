using Prism.Mvvm;
using System.Windows.Input;
using System;

namespace EventSample.ViewModels
{

    //public delegate void KeyCommandEventHandler(object sender, MouseEventArgs e); // デリゲート宣言

    public class MainWindowViewModel : BindableBase
    {
        public event MouseEventHandler MouceDownCommand = (_, _) => { };     // イベントハンドラが登録されないままにイベントが発生した場合に備えたもの

        private string _title = "Prism Application";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public MainWindowViewModel()
        {
            MouceDownCommand += MouseDownEvent;
        }

        public void MouseDownEvent(object sender, MouseEventArgs e)
        {
            Console.WriteLine($"Form2.MouseDownイベント：クリックされた座標は()");
        }

    }
}
