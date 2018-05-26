using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Text;
using XF.Prism.Demo.Events;

namespace XF.Prism.Demo.ViewModels
{
    public class ViewBPageViewModel : BindableBase, INavigatedAware
    {
        /* Properties */
        private string title;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        /* Services */
        private IEventAggregator _eventAgreggator;
        private INavigationService _navigationService;
        private IPageDialogService _pageDialogService;

        /* Commands */
        public DelegateCommand GoBackCommand { get; set; }
        public DelegateCommand ShowDialogCommand { get; set; }
        public DelegateCommand ChangeTitleCommand { get; set; }

        public ViewBPageViewModel(IPageDialogService pageDialogService, 
                                  INavigationService navigationService,
                                  IEventAggregator eventAgreggator)
        {
            _eventAgreggator = eventAgreggator;
            _navigationService = navigationService;
            _pageDialogService = pageDialogService;

            GoBackCommand = new DelegateCommand(GoBack);
            ShowDialogCommand = new DelegateCommand(ShowDialog);
            ChangeTitleCommand = new DelegateCommand(ChangeTitle);
        }

        async void GoBack()
        {
           await _navigationService.GoBackAsync();
        }

        async void ShowDialog()
        {
            var choice = await _pageDialogService.DisplayAlertAsync(title: "Demo", message: "Hello from Conference", acceptButton: "Ok", cancelButton: "Dismiss");
        }

        void ChangeTitle()
        {
            _eventAgreggator.GetEvent<SomeEvent>().Publish("Hello from View B");
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            var paramTitle = parameters["title"] as string;
            Title = paramTitle;
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
            // throw new NotImplementedException();
        }
    }
}
