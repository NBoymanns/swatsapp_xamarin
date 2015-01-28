using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace SwatsApp
{
	public class APICommunicator
	{
		public APICommunicator ()
		{
		}

		public async Task<List<News>> getRequest(string url) {

			var client = new HttpClient ();
			var result = await client.GetStringAsync(url);
			System.Diagnostics.Debug.WriteLine (result.ToString());

			List<News> newsItems = JsonConvert.DeserializeObject<List<News>> (result);
			System.Diagnostics.Debug.WriteLine ("NewsItems count: {0}, {1}, {2}, {3}", newsItems[0].poster, newsItems[0].message, newsItems[0].poster_profile_picture, newsItems[0].image_url);
			return newsItems;
		}	
	}
}