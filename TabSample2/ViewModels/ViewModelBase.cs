using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TabSample2.ViewModels
{
    public abstract class ViewModelBase : BindableBase
    {
        public string Caption { get { return ""; } }

    }
}
