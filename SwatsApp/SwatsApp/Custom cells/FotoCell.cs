using System;

using Xamarin.Forms;

namespace SwatsApp
{
	public class FotoCell : ViewCell
	{
		public FotoCell ()
		{
			var image = new Image {
				HorizontalOptions = LayoutOptions.Center
			};

			image.SetBinding (Image.SourceProperty, new Binding ());
			image.WidthRequest = image.HeightRequest = 200;

			var viewLayout = new StackLayout () {
				Padding = new Thickness(10, 5, 5, 10),
				HorizontalOptions = LayoutOptions.Center, 
				Children = { image }
			};
			View = viewLayout;
		}
	}
}