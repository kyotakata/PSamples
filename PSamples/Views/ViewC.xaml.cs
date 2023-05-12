using System.Windows.Controls;

namespace PSamples.Views
{
    /// <summary>
    /// Interaction logic for ViewC
    /// </summary>
    public partial class ViewC : UserControl
    {
        public ViewC()
        {
            InitializeComponent();

            //https://anderson02.com/cs/wpf/wpf-20/参照
            var selectedIndex = ViewCConboBox.SelectedIndex;
            // 選択されているIdはSelectedValueで取得できます。
            var selectedValue = ViewCConboBox.SelectedValue;
            // 選択されているNameはTextで取得することができます。
            var text = ViewCConboBox.Text;
        }

        /// <summary>
        /// ComboBoxの選択に変化があった時に呼ばれるイベントハンドラ
        /// しかし、コードビハインド側に書かれる。
        /// MVVMの思想としては基本的にViewModelにロジックを集めたいので、ViewModelに書く。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBox_SelectionChanged(
            object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
