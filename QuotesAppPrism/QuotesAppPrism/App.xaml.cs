using Prism;
using Prism.Ioc;
using QuotesAppPrism.ViewModels;
using QuotesAppPrism.Views;
using Xamarin.Essentials.Interfaces;
using Xamarin.Essentials.Implementation;
using Xamarin.Forms;
using QuotesAppPrism.Services;
using QuotesAppPrism.Interfaces;

namespace QuotesAppPrism
{
    public partial class App
    {
        public App(IPlatformInitializer initializer)
            : base(initializer)
        {
        }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            //await NavigationService.NavigateAsync("NavigationPage/WelcomePage");

            await NavigationService.NavigateAsync("NavigationPage/QuotesPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();

            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<WelcomePage, WelcomePageViewModel>();
            containerRegistry.RegisterForNavigation<HomePage, HomePageViewModel>();
            containerRegistry.RegisterForNavigation<QuotesPage, QuotesPageViewModel>();
            containerRegistry.RegisterSingleton<IQuote, QuotesApi>();
            containerRegistry.RegisterForNavigation<QuotesDetail, QuotesDetailViewModel>();
        }
    }
}
