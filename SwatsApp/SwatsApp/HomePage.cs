﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Diagnostics;

using Xamarin.Forms;
using Newtonsoft.Json;

namespace SwatsApp
{
	public class HomePage : ContentPage
	{
		ListView listView = new ListView(){ ItemTemplate = new DataTemplate(typeof(NewsCell)), RowHeight = 200, HasUnevenRows = false };

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
			string result = await communicator.getRequest ("http://swatsapp-gae.appspot.com/news_items");
			List<News> newsItems = JsonConvert.DeserializeObject<List<News>> (result);

			foreach (News item in newsItems) {
				if (item.message.Length > 225) {
					item.message = item.message.Substring (0, 225);
					item.message = item.message + "...";
				}
			}

			listView.ItemsSource = newsItems;
		}
	}
}