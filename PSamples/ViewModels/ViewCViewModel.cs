using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using PSamples.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace PSamples.ViewModels
{
    public class ViewCViewModel : BindableBase, IConfirmNavigationRequest// 画面遷移先のViewModelにはIConfirmNavigationRequestを実装する。
                                                                         // 但し、IConfirmNavigationRequestでは画面を離れる直前に通知されるメソッド(ConfirmNavigationRequest)がある。画面を離れてよいか未保存のデータがある時等の確認用の処理を追加したりする
    {
        private IMessageService _messageService;

        private MainWindowViewModel _mainWindowViewModel;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="mainWindowViewModel">App.xaml.csに登録したことで自動的にMainWindowViewModelをDIしてくれる</param>
        public ViewCViewModel(MainWindowViewModel mainWindowViewModel) :
            this(new MessageService(), mainWindowViewModel)
        {
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="messageService">カスタムクラスMessageServiceを受ける</param>
        /// <param name="mainWindowViewModel"></param>
        public ViewCViewModel(
            IMessageService messageService,
            MainWindowViewModel mainWindowViewModel)
        {
            _messageService = messageService;
            _mainWindowViewModel = mainWindowViewModel;

            MyListBox.Add("AAAAAA");
            MyListBox.Add("SSS");
            MyListBox.Add("DDDD");

            Areas.Add(new ComboBoxViewModel(1, "横浜"));
            Areas.Add(new ComboBoxViewModel(2, "神戸"));
            Areas.Add(new ComboBoxViewModel(3, "高松"));

            SelectedArea = Areas[1];    // こうすることで画面起動時にConboBoxの初期値として神戸をセットできる。

            AreaSelectionChanged = new DelegateCommand<object[]>(
                AreaSelectionChangedExecute);
        }

        private ObservableCollection<string> _myListBox
            = new ObservableCollection<string>();
        
        /// <summary>
        /// ListBoxへのBindingデータ
        /// </summary>
        public ObservableCollection<string> MyListBox
        {
            get { return _myListBox; }
            set { SetProperty(ref _myListBox, value); }
        }

        private ObservableCollection<ComboBoxViewModel> _areas
           = new ObservableCollection<ComboBoxViewModel>();

        /// <summary>
        /// ConboBoxへBindingするプロパティ
        /// </summary>
        public ObservableCollection<ComboBoxViewModel> Areas
        {
            get { return _areas; }
            set { SetProperty(ref _areas, value); }
        }

        private ComboBoxViewModel _selectedArea;

        /// <summary>
        /// ComboBoxへBindingされた選択された値
        /// </summary>
        public ComboBoxViewModel SelectedArea
        {
            get { return _selectedArea; }
            set { SetProperty(ref _selectedArea, value); }
        }

        /// <summary>
        /// ComboBoxのInteraction.TriggersにBindingするDelegateCommand
        /// </summary>
        public DelegateCommand<object[]> AreaSelectionChanged { get; }


        private string _selectedAreaLabel;

        /// <summary>
        /// LabelのContentプロパティにBindingするプロパティ。ComboBoxで選択されているデータをLabelに表示する。
        /// </summary>
        public string SelectedAreaLabel
        {
            get { return _selectedAreaLabel; }
            set { SetProperty(ref _selectedAreaLabel, value); }
        }

        /// <summary>
        /// 画面が閉じる直前(OnNavigatedFromよりも前)に通知されるメソッド
        /// IConfirmNavigationRequestの実装
        /// </summary>
        /// <param name="navigationContext"></param>
        /// <param name="continuationCallback">このActionを通知しないと画面が閉じないことになっている</param>
        public void ConfirmNavigationRequest(
            NavigationContext navigationContext,
            Action<bool> continuationCallback)
        {
            if (_messageService.Question("保存していないけどいいですか？")
                == System.Windows.MessageBoxResult.OK)
            {
                continuationCallback(true);// trueにすると画面が閉じる
            }
        }

        /// <summary>
        /// ViewCのインスタンスを使いまわすか
        /// IConfirmNavigationRequestの実装
        /// </summary>
        /// <param name="navigationContext"></param>
        /// <returns>
        /// trueの時は画面が離れる際も再び画面遷移した際もインスタンスが解放されず同じものを使いまわす(前回の値保持)。
        /// falseの時は画面が離れる際に毎回インスタンスが解放され、画面遷移した際に新しくインスタンスを生成する(前回の値保持せずに消える)
        /// </returns>
        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return false;
        }

        /// <summary>
        /// Navigationがこの画面から離れる時に通過するメソッド。終了処理がある場合はここに書く。
        /// IConfirmNavigationRequestの実装
        /// </summary>
        /// <param name="navigationContext"></param>
        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }

        /// <summary>
        /// 画面遷移で通過するメソッド
        /// IConfirmNavigationRequestの実装
        /// </summary>
        /// <param name="navigationContext"></param>
        public void OnNavigatedTo(NavigationContext navigationContext)
        {
        }

        /// <summary>
        /// ComboBoxの値が変化したときに呼ばれるメソッド
        /// </summary>
        /// <param name="items"></param>
        private void AreaSelectionChangedExecute(object[] items)
        {
            SelectedAreaLabel = SelectedArea.Value + " : " +
                SelectedArea.DisplayValue;

            _mainWindowViewModel.Title = SelectedAreaLabel;
            _mainWindowViewModel.PButtonEnabled = false;
        }
    }
}
