using System;

using Xamarin.Forms;

namespace SwatsApp
{
	public class AgendaPage : ContentPage
	{
		public AgendaPage ()
		{
			Title = "Agenda";

			Content = new StackLayout { 
				Children = {
					new Label { Text = "Hello Agenda Page" }
				}
			};
		}
	}
}


