using System;

using Xamarin.Forms;

namespace SwatsApp
{
	public class App : Application
	{
		public App ()
		{
			// The root page of your application
			MainPage = new ContentPage {
				BackgroundColor = new Color(100,0,0),
				Content = new StackLayout {
					VerticalOptions = LayoutOptions.Center,
					Children = {
						new Label {
							XAlign = TextAlignment.Center,
							Text = "Welkom bij SwatsApp!"
						},
						new Label {
							XAlign = TextAlignment.Center,
							Text = "Dit is de officiele app van CV De Swatsers."
						}
					}
				}
			};
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}

