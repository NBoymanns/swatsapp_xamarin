using System;

using Xamarin.Forms;

namespace SwatsApp
{
	public class FotosPage : ContentPage
	{
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
					new Label { Text = "Hello Foto's Page" }
				}
			};
		}

		private void MakeNewPhoto()
		{
			//To-Do: Make new Photo
		}
	}
}


