using System;

using Xamarin.Forms;

namespace SwatsApp
{
	public class FotoCell : ViewCell
	{
		public FotoCell ()
		{
			var image = new Image {
				HorizontalOptions = LayoutOptions.Start
			};

			image.SetBinding (Image.SourceProperty, new Binding ("poster_profile_picture"));
			image.WidthRequest = image.HeightRequest = 50;

			var viewLayout = new StackLayout () {
				Padding = new Thickness(10, 10, 10, 10),
				Children = { image }
			};
			View = viewLayout;
		}
	}
}