using Prism;
using Prism.Autofac;
using Prism.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using XF.Prism.Demo.Views;

namespace XF.Prism.Demo
{
	public partial class App : PrismApplication
	{
		public App (IPlatformInitializer platformInitializer = null) : base(platformInitializer)
		{
			InitializeComponent();
		}

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<ViewAPage>();
            containerRegistry.RegisterForNavigation<ViewBPage>();
            containerRegistry.RegisterForNavigation<MyPage>();

            containerRegistry.RegisterForNavigation<NavigationPage>();
        }

        protected override void OnInitialized()
        {
           // NavigationService.NavigateAsync(nameof(NavigationPage)+ "/" + nameof(MyPage));
            NavigationService.NavigateAsync(nameof(NavigationPage) + "/" + nameof(ViewAPage));
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
