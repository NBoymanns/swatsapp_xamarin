using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Diagnostics;

using Xamarin.Forms;

namespace SwatsApp
{
	public class HomePage : ContentPage
	{
		ListView listView = new ListView(){ ItemTemplate = new DataTemplate(typeof(NewsCell)), RowHeight = 100 };

		public HomePage ()
		{
			Title = "Home";

			Content = new StackLayout { 
				Children = {
					listView
				}
			};

			test ();
		}

		public async void test() {
			APICommunicator communicator = new APICommunicator ();
			List<News> test = await communicator.getRequest ("http://swatsapp-gae.appspot.com/news_items");
			Debug.WriteLine ("Testje: {0}", test.Count);
			listView.ItemsSource = test;
		}
	}
}