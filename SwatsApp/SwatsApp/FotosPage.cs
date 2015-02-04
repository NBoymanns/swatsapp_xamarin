using System;

using Xamarin.Forms;

namespace SwatsApp
{
	public class FotosPage : ContentPage
	{
		ListView listView = new ListView(){ ItemTemplate = new DataTemplate(typeof(FotoCell)), RowHeight = 100 };

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
		}

		private void MakeNewPhoto()
		{
			//To-Do: Make new Photo
		}
	}
}