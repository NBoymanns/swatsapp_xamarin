using System;
using System.Collections.Generic;
using System.Diagnostics;

using Xamarin.Forms;

namespace SwatsApp
{
	public class HomePage : ContentPage
	{
		public HomePage ()
		{
			Title = "Home";

			test ();

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

		public void test() {
			APICommunicator com = new APICommunicator ();
			string test = com.getRequest ("http://api.ihackernews.com/page/").ToString();
			Debug.WriteLine ("Json: {0}", test);
		}
	}
}