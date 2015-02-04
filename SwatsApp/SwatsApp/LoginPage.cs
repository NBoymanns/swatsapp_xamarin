using System;

using Xamarin.Forms;

namespace SwatsApp
{
	public class LoginPage : ContentPage
	{
		public LoginPage ()
		{
			Title = "Login";

			var nameEntry = new Entry { Placeholder = "Voor je naam in..." };

			Button loginButton = new Button {
				Text = "Login",
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.CenterAndExpand
			};
			loginButton.Clicked += OnLoginClicked;

			Content = new StackLayout { 
				Padding = new Thickness(10, 10, 10, 10),
				Children = {
					new Label { Text = "Login om gebruik te kunnen maken van deze app." },
					nameEntry,
					loginButton
				}
			};
		}

		void OnLoginClicked(object sender, EventArgs e) {
			//To-Do: Login
			//postLoginCredentials ();
			Navigation.PushModalAsync (GetMainPage ());
		}

		public static Page GetMainPage () {
			var tp = new TabbedPage ();
			tp.Children.Add (new NavigationPage (new HomePage ()) { Title="Home", Icon="home.png"});
			tp.Children.Add (new NavigationPage (new FotosPage ()) { Title="Foto's", Icon="fotos.png"});
			tp.Children.Add (new NavigationPage (new AgendaPage ()) { Title="Agenda", Icon="agenda.png"});
			return tp;
		}

		public async void postLoginCredentials() {
			APICommunicator communicator = new APICommunicator ();
			String jsonBody = "{\"name\":\"Test gebruiker\",\"device_id\":\"3423423432\"}";
			//User test = await communicator.postRequest ("http://swatsapp-gae.appspot.com/users", jsonBody);
			String test = await communicator.postRequest ("http://swatsapp-gae.appspot.com/users", jsonBody);
			System.Diagnostics.Debug.WriteLine ("Test {0}", test);
		}
	}
}