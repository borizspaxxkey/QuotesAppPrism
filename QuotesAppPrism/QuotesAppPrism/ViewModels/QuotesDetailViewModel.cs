using Prism.Mvvm;
using Prism.Navigation;
using QuotesAppPrism.Models;

namespace QuotesAppPrism.ViewModels
{
    public class QuotesDetailViewModel : BindableBase, INavigatedAware
    {
        private Quote quote;
        private string _quoteDescription;

        public string QuoteDescription
        {
            get { return _quoteDescription; }
            set { SetProperty(ref _quoteDescription , value); }
        }


        public QuotesDetailViewModel()
        {

        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {

        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            quote = (Quote)parameters["quoteDetail"];
            QuoteDescription = quote.Description;
        }
    }
}
