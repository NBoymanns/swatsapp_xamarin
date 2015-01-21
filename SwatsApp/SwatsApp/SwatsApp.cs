using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace SwatsApp
{
	public class App : Application
	{
		public App ()
		{
			// The root page of your application
			var tp = new TabbedPage ();
			tp.Children.Add (new NavigationPage (new HomePage ()) { Title="Home"});
			tp.Children.Add (new NavigationPage (new FotosPage ()) { Title="Foto's"});
			tp.Children.Add (new NavigationPage (new AgendaPage ()) { Title="Agenda"});

			MainPage = tp;
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

