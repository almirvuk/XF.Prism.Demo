using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using XF.Prism.Demo.Events;
using XF.Prism.Demo.Views;

namespace XF.Prism.Demo.ViewModels
{
    public class ViewAPageViewModel : BindableBase
    {
        private string title;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        private string titleForViewB;
        public string TitleForViewB
        {
            get { return titleForViewB; }
            set { SetProperty(ref titleForViewB, value); }
        }

        private IEventAggregator _eventAggregator;
        private INavigationService _navigationService;

        private bool canNavigate = false;
        public bool CanNavigate
        {
            get { return canNavigate; }
            set { SetProperty(ref canNavigate, value); }
        }

        public DelegateCommand GoToViewBCommand { get; set; }

        public ViewAPageViewModel(INavigationService navigationService, IEventAggregator eventAggregator)
        {
            Title = "View A";

            GoToViewBCommand = new DelegateCommand(GoToViewB).ObservesCanExecute(() => CanNavigate);

            _eventAggregator = eventAggregator;
            _navigationService = navigationService;

            _eventAggregator.GetEvent<SomeEvent>().Subscribe((message) => Title = message);
        }

        private void GoToViewB()
        {
            var navigationParameters = new NavigationParameters();
            navigationParameters.Add("title", TitleForViewB);

            _navigationService.NavigateAsync(nameof(ViewBPage), navigationParameters);
        }
    }
}
