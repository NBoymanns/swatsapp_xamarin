using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Diagnostics;

using Xamarin.Forms;

namespace SwatsApp
{
	public class HomePage : ContentPage
	{
		ListView listView = new ListView(){ ItemTemplate = new DataTemplate(typeof(NewsCell)), RowHeight = 200, HasUnevenRows = true };

		public HomePage ()
		{
			Title = "Home";

			Content = new StackLayout { 
				Children = {
					listView
				}
			};

			getNews ();
		}

		public async void getNews() {
			APICommunicator communicator = new APICommunicator ();
			List<News> test = await communicator.getRequest ("http://swatsapp-gae.appspot.com/news_items");
			listView.ItemsSource = test;
		}
	}
}