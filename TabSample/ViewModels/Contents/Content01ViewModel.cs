using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TabSample.ViewModels.Contents
{
    public class Content01ViewModel: ViewModelBase
    {

        private string _checkBoxComment = "Content01";
        public string CheckBoxComment
        {
            get { return _checkBoxComment; }
            set { SetProperty(ref _checkBoxComment, value); }
        }

    }
}
