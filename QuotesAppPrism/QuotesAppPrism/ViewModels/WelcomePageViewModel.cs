using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QuotesAppPrism.ViewModels
{
    public class WelcomePageViewModel : BindableBase
    {
        public DelegateCommand LoginCommand { get; set; }
        public INavigationService NavigationService { get; set; }
        private string _welcomeMessage;

        public string WelcomeMessage
        {
            get { return _welcomeMessage; }
            set { _welcomeMessage = value; }
        }


        public WelcomePageViewModel(INavigationService navigationService)
        {
            LoginCommand = new DelegateCommand(LoginMethod);
            NavigationService = navigationService;
        }

        private void LoginMethod()
        {
            var navigationParameters = new NavigationParameters();
            navigationParameters.Add("parameter", _welcomeMessage);
            NavigationService.NavigateAsync("HomePage", navigationParameters);
        }
    }
}
