using System;

using Xamarin.Forms;

namespace SwatsApp
{
	public class AgendaPage : ContentPage
	{
		public AgendaPage ()
		{
			Title = "Agenda";

			WebView webView = new WebView {
				Source = new UrlWebViewSource {
					Url = "http://www.vcdeswatsers.nl/index.php?pagina=agenda"
				},
				VerticalOptions = LayoutOptions.FillAndExpand
			};


			Content = new StackLayout { 
				Children = {
					webView
				}
			};
		}
	}
}


