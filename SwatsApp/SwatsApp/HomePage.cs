using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace SwatsApp
{
	public class HomePage : ContentPage
	{
		public HomePage ()
		{
			Title = "Home";

			List<String> items = new List<String> {
				"Item1", "Item2", "Item3"
			};

			ListView listView = new ListView {
				ItemsSource = items
			};

			Content = new StackLayout { 
				Children = {
					listView
				}
			};
		}
	}
}