using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoinpaprikaAPI;
using Newtonsoft.Json;

namespace BlazorCoins.Data
{
    public class CoinService
    {
        private readonly CoinpaprikaAPI.Client myClient;
        public CoinService()
        {
            myClient = new CoinpaprikaAPI.Client();
        }
        public async Task<List<CoinpaprikaAPI.Entity.CoinInfo>> GetCoinListAsync()
        {
          
            var coins = await myClient.GetCoinsAsync();
            var coinList = JsonConvert.DeserializeObject<List<CoinpaprikaAPI.Entity.CoinInfo>>(coins.Raw);
            return coinList.Take(100).ToList();
        }
        
    }
}
