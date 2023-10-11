using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DataBindSample_03_UserControl.Views
{
    /// <summary>
    /// DockCheckBox.xaml の相互作用ロジック
    /// </summary>
    public partial class DockCheckBox : UserControl
    {
        public DockCheckBox()
        {
            InitializeComponent();

            CommentTextBlock.SetBinding(TextBlock.TextProperty,
                new Binding(nameof(CheckBoxComment))
                {
                    Source = this,
                });
        }


        /// <summary>
        /// CLRラッパープロパティ
        /// </summary>
        public string CheckBoxComment
        {
            get { return (string)GetValue(CheckBoxCommentProperty); }
            set { SetValue(CheckBoxCommentProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CheckBoxComment.  This enables animation, styling, binding, etc...
        /// <summary>
        /// 依存関係プロパティ
        /// </summary>
        public static readonly DependencyProperty CheckBoxCommentProperty =
            DependencyProperty.Register(
                "CheckBoxComment", 
                typeof(string), 
                typeof(DockCheckBox), 
                new PropertyMetadata(string.Empty));


    }
}
