﻿using System;

using Xamarin.Forms;

namespace SwatsApp
{
	public class LoginPage : ContentPage
	{
		public LoginPage ()
		{
			Title = "Login";

			var nameEntry = new Entry { Placeholder = "Voor je naam in..." };
			var passwordEntry = new Entry { Placeholder = "Geef unique ID" };

			Button loginButton = new Button {
				Text = "Login",
				BorderWidth = 1,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				VerticalOptions = LayoutOptions.CenterAndExpand,
				BackgroundColor = Color.Red
			};
			loginButton.Clicked += OnLoginClicked;

			Content = new StackLayout { 
				Children = {
					new Label { Text = "Login om gebruik te kunnen maken van deze app." },
					nameEntry,
					passwordEntry,
					loginButton
				}
			};
		}

		void OnLoginClicked(object sender, EventArgs e) {
			//To-Do: Login
			postLoginCredentials ();
			//Navigation.PushModalAsync (GetMainPage ());
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