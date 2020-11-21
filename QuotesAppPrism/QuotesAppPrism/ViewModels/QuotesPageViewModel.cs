using Prism.Mvvm;
using Prism.Navigation;
using QuotesAppPrism.Interfaces;
using QuotesAppPrism.Models;
using System.Collections.ObjectModel;

namespace QuotesAppPrism.ViewModels
{
    public class QuotesPageViewModel : BindableBase
    {
        public ObservableCollection<Quote> Quotes { get; set; }
        private IQuote _quotes;

        public INavigationService NavigationService { get; set; }

        public QuotesPageViewModel(IQuote quotes, INavigationService navigationService)
        {
            Quotes = new ObservableCollection<Quote>();
            _quotes = quotes;
            LoadQuotes();
            NavigationService = navigationService;
        }

        public async void LoadQuotes()
        {
            var quotes = await _quotes.GetQuotes();
            foreach (var quote in quotes)
            {
                Quotes.Add(quote);
            }
        }

        private Quote _selectedQuote;

        public Quote SelectedQuote
        {
            get { return _selectedQuote; }
            set
            {
                _selectedQuote = value;
                if (_selectedQuote != null)
                {
                    var navigationParameters = new NavigationParameters();
                    navigationParameters.Add("quoteDetail", _selectedQuote);
                    NavigationService.NavigateAsync("QuotesDetail", navigationParameters);
                }
            }
        }
    }
}
