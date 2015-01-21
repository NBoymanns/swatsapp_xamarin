using System;

using Xamarin.Forms;

namespace SwatsApp
{
	public class HomePage : ContentPage
	{
		public HomePage ()
		{
			Title = "Home";

			Content = new StackLayout { 
				Children = {
					new Label { Text = "Hello Home Page" }
				}
			};
		}
	}
}


