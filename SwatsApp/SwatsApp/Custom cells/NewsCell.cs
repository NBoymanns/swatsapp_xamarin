using System;

using Xamarin.Forms;

namespace SwatsApp
{
	public class NewsCell : ViewCell
	{
		public NewsCell ()
		{
			var image = new Image {
				HorizontalOptions = LayoutOptions.Start
			};

			image.SetBinding (Image.SourceProperty, new Binding ("poster_profile_picture"));
			image.WidthRequest = image.HeightRequest = 40;

			var nameLayout = CreateNameLayout ();

			var viewLayout = new StackLayout () {
				Orientation = StackOrientation.Horizontal,
				Children = { image, nameLayout }
			};
			View = viewLayout;
		}

		static StackLayout CreateNameLayout()
		{

			var nameLabel = new Label
			{
				HorizontalOptions= LayoutOptions.FillAndExpand
			};
			nameLabel.SetBinding(Label.TextProperty, "poster");

			var messageLabel = new Label
			{
				HorizontalOptions = LayoutOptions.FillAndExpand
			};
			messageLabel.SetBinding(Label.TextProperty, "message");

			var nameLayout = new StackLayout()
			{
				HorizontalOptions = LayoutOptions.StartAndExpand,
				Orientation = StackOrientation.Vertical,
				Children = { nameLabel, messageLabel }
			};
			return nameLayout;
		}
	}
}