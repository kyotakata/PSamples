using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PSamples.ViewModels
{
    public class ViewBViewModel : BindableBase, IDialogAware// ポップアップで表示したい画面のViewModelにはIDialogAwareを実装する
    {
        public ViewBViewModel()
        {
            OKButton = new DelegateCommand(OKButtonExecute);
        }

        public string Title => "ViewB";

        private string _viewBTextBox = "XXX";
        /// <summary>
        /// 受け取ったパラメータ表示用テキストボックス
        /// </summary>
        public string ViewBTextBox
        {
            get { return _viewBTextBox; }
            set { SetProperty(ref _viewBTextBox, value); }
        }


        private int _width = 100;
        /// <summary>
        /// 画面横幅
        /// </summary>
        public int Width
        {
            get { return _width; }
            set { SetProperty(ref _width, value); }
        }

        private int _height = 100;
        /// <summary>
        /// 画面縦幅
        /// </summary>
        public int Height
        {
            get { return _height; }
            set { SetProperty(ref _height, value); }
        }

        private string _resizeMode = "NoResize";
        /// <summary>
        /// リサイズモード(CanResize,NoResize,CanMinimize,CanResizeWithGrip指定可能)
        /// </summary>
        public string ResizeMode
        {
            get { return _resizeMode; }
            set { SetProperty(ref _resizeMode, value); }
        }

        /// <summary>
        /// RequestCloseというアクション
        /// IDialogAwareの実装
        /// </summary>
        public event Action<IDialogResult> RequestClose;

        /// <summary>
        /// OKボタン
        /// </summary>
        public DelegateCommand OKButton { get; }

        /// <summary>
        /// ポップアップ画面閉じれるかどうか
        /// IDialogAwareの実装
        /// </summary>
        /// <returns>tureの時は閉じれる。</returns>
        public bool CanCloseDialog()
        {
            return true;
        }

        /// <summary>
        /// ポップアップ画面が閉じる時に通過するメソッド。終了処理がある場合はここに書く。
        /// IDialogAwareの実装
        /// </summary>
        public void OnDialogClosed()
        {
        }

        /// <summary>
        /// ポップアップ画面が開くときに通過するメソッド
        /// IDialogAwareの実装
        /// </summary>
        /// <param name="parameters">ここでパラメータを受ける</param>
        public void OnDialogOpened(IDialogParameters parameters)
        {
            ViewBTextBox =
                 parameters.GetValue<string>(nameof(ViewBTextBox));
            Width =
                 parameters.GetValue<int>(nameof(Width));
            Height =
                 parameters.GetValue<int>(nameof(Height));
            var mode =
                 parameters.GetValue<string>(nameof(ResizeMode));
            if (mode != null)// parametersにResizeModeが追加されていない場合、nullとなってしまうのを防ぐ。nullの時はフィールド宣言時に初期化された値となる。
            {
                ResizeMode= mode;
            }
        }

        /// <summary>
        /// OKボタン押下時に実行されるメソッド
        /// </summary>
        private void OKButtonExecute()
        {
            // ポップアップ画面の戻り値を呼び出し元(MainWindowViewModel)に返す
            var p = new DialogParameters();
            p.Add(nameof(ViewBTextBox), ViewBTextBox);
            RequestClose?.Invoke(new DialogResult(ButtonResult.OK, p));// 第一引数にどのボタンが押されたか、第二引数に返したいパラメータを指定する。
        }
    }
}