using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SwatsApp
{
	public class APICommunicator
	{
		public APICommunicator ()
		{
		}

		public async Task<String> getRequest(string url) {

			var client = new HttpClient ();
			var result = await client.GetStringAsync(url);
			System.Diagnostics.Debug.WriteLine (result.ToString());
			return JsonConvert.DeserializeObject (result).ToString ();
		}	
	}
}