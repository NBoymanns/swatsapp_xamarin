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
			List<News> newsItems = JsonConvert.DeserializeObject<List<News>> (result);
			return newsItems;
		}	
	}
}