using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Text;

namespace SwatsApp
{
	public class APICommunicator
	{
		/*
		public async Task<List<News>> getRequest(string url) {

			var client = new HttpClient ();
			var result = await client.GetStringAsync(url);
			List<News> newsItems = JsonConvert.DeserializeObject<List<News>> (result);
			return newsItems;
		}*/

		public async Task<string> getRequest(string url) {
			var client = new HttpClient ();
			var result = await client.GetStringAsync(url);
			return result;
		}

		//public async Task<User> postRequest(string url, string jsonBody)
		public async Task<String> postRequest(string url, string jsonBody){
			var client = new HttpClient ();
			//client.DefaultRequestHeaders.Accept.Add (new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue ("application/json"));

			HttpContent content = new StringContent (jsonBody, Encoding.UTF8, "application/json");
					
			var response = await client.PostAsync (url, content);

			var result = await response.Content.ReadAsStringAsync ();
			//User user = JsonConvert.DeserializeObject<User> (result);
			String user = result;
			return user;
		}
	}
}