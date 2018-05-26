using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;

namespace XF.Prism.Demo.ViewModels
{
    public class MyPageViewModel : BindableBase
    {
        private string pageTitle = string.Empty;
        public string PageTitle
        {
            get { return pageTitle; }
            set { SetProperty(ref pageTitle, value); }
        }

        public MyPageViewModel()
        {

        }
    }
}
