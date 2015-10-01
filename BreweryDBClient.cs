using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace BreweryDB
{
    public class BreweryDBClient
    {
        public BreweryDBClient(string key)
        {
            _key = key;
        }
       
        public List<Models.Beer> SearchForBeer(string name)
        {           
            if (_client == null)
                _client = new WebClient();

            Models.Response model;

            var url = string.Format("https://api.brewerydb.com/v2/search/?q={0}&withBreweries=y&key={1}&format=json", name, _key);
            var response = _client.DownloadString(url);

            model = JsonConvert.DeserializeObject<Models.Response>(response);
            model.Data = JsonConvert.DeserializeObject<List<Models.Beer>>(model.Data.ToString());

            return model.Data as List<Models.Beer>;  
        }

        private WebClient _client;
        private string _key;
    }
}
