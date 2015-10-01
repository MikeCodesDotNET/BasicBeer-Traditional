using System;
using System.Collections.ObjectModel;
using BreweryDB.Models;
using System.Threading.Tasks;

namespace BasicBeer
{
    public class SearchViewModel
    {
        public ObservableCollection<Beer> Beers = new ObservableCollection<Beer>();

        public void SearchForBeersCommand(string searchTerm)
        { 
            try
            {
                var client = new BreweryDB.BreweryDBClient("b7da1c5827026053a276f0dbe2234962");
                var results = client.SearchForBeer(searchTerm);

                Beers.Clear();

                if (results.Count > 0)
                {
                    foreach (var beer in results)
                    {
                        Beers.Add(beer);                  
                    }  
                    return;
                }
            }
            catch(Exception ex)
            {
                Acr.UserDialogs.UserDialogs.Instance.ShowError(ex.Message);
            }
        }
    }
}

