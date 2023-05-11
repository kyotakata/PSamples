using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using PSamples.Services;
using PSamples.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace PSamples.ViewModels
{
    public class ViewAViewModel : BindableBase, INavigationAware// 画面遷移先のViewModelにはINavigationAwareを実装する
    {
        private IDialogService _dialogService;
        private IMessageService _messageService;

        public ViewAViewModel(IDialogService dialogService)
            : this(dialogService, new MessageService())
        {
        }

        public ViewAViewModel(
            IDialogService dialogService,
            IMessageService messageService)
        {
            _dialogService = dialogService;
            _messageService = messageService;
            OKButton = new DelegateCommand(OKButtonExecute);
            OKButton2 = new DelegateCommand(OKButton2Execute);
        }

        private string _myLabel = string.Empty;
        public string MyLabel
        {
            get { return _myLabel; }
            set { SetProperty(ref _myLabel, value); }
        }

        public DelegateCommand OKButton { get; }
        public DelegateCommand OKButton2 { get; }

        /// <summary>
        /// 画面遷移で通過するメソッド
        /// INavigationAwareの実装
        /// </summary>
        /// <param name="navigationContext"></param>
        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            MyLabel = navigationContext
                .Parameters.GetValue<string>(nameof(MyLabel));// string型の値なので、ジェネリックはstring。キーはMyLabelで値を取得する
        }

        /// <summary>
        /// ViewAのインスタンスを使いまわすか
        /// INavigationAwareの実装
        /// </summary>
        /// <param name="navigationContext"></param>
        /// <returns>
        /// trueの時は画面が離れる際も再び画面遷移した際もインスタンスが解放されず同じものを使いまわす(前回の値保持)。
        /// falseの時は画面が離れる際に毎回インスタンスが解放され、画面遷移した際に新しくインスタンスを生成する(前回の値保持せずに消える)
        /// </returns>
        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        /// <summary>
        /// Navigationがこの画面から離れる時に通過するメソッド。終了処理がある場合はここに書く。
        /// INavigationAwareの実装
        /// </summary>
        /// <param name="navigationContext"></param>
        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }

        private void OKButtonExecute()
        {
            // MessageBox.Show("Saveします");
            var p = new DialogParameters();
            p.Add(nameof(ViewBViewModel.ViewBTextBox), "Saveします");
            _dialogService.ShowDialog(nameof(ViewB), p, null);
        }

        private void OKButton2Execute()
        {
            // MessageBox.Show("Saveします");

            if (_messageService.Question("Saveしますか？")
                == MessageBoxResult.OK)
            {
                _messageService.ShowDialog("Saveしました");
            }
        }
    }
}
