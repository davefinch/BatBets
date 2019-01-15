using System.Text;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms.Xaml;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace BatBets
{
    public class Google
    {
        public async Task<string> UpdateCount(string name, string teams)
        {
            var baseAddr = new Uri("https://batbetsapi.azurewebsites.net");
            using (var client = new HttpClient { BaseAddress = baseAddr })

            {
                
                var returnedJson = await client.GetStringAsync($"/api/batbets/{name}/{teams}");
                return "Success";
  
            }
        }
    }
}
