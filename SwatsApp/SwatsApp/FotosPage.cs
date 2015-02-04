using System;

using Xamarin.Forms;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace SwatsApp
{
	public class FotosPage : ContentPage
	{
		ListView listView = new ListView(){ ItemTemplate = new DataTemplate(typeof(FotoCell)), RowHeight = 200 };

		public FotosPage ()
		{
			Title = "Foto's";

			var settings = new ToolbarItem {
				Icon = "plus.png",
				Text = "Nieuwe foto",
				Command = new Command(this.MakeNewPhoto)
			};

			ToolbarItems.Add (settings);

			Content = new StackLayout { 
				Children = {
					listView
				}
			};

			getUser();
		}

		private void MakeNewPhoto()
		{
			//To-Do: Make new Photo
		}

		public async void getUser() {
			APICommunicator communicator = new APICommunicator ();
			String result = await communicator.getRequest ("http://swatsapp-gae.appspot.com/users/5707702298738688");
			User user = JsonConvert.DeserializeObject<User> (result);

			List<String> photos = new List<String> (); 

			foreach (String item in user.photos) {
				photos.Add(string.Format ("http://swatsapp-gae.appspot.com/users/{0}/photos/{1}", user.id, item));
			}

			listView.ItemsSource = photos;
		}
	}
}