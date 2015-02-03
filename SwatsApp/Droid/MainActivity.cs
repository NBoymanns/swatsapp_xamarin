using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

using ByteSmith.WindowsAzure.Messaging;
using Gcm.Client;

namespace SwatsApp.Droid
{
	[Activity (Label = "SwatsApp", Icon = "@drawable/icon", MainLauncher = true, Theme = "@style/MyTheme", ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			global::Xamarin.Forms.Forms.Init (this, bundle);

			RegisterWithGCM ();

			LoadApplication (new App ());
		}

		private void RegisterWithGCM()
		{
			// Check to ensure everything's setup right
			GcmClient.CheckDevice(this);
			GcmClient.CheckManifest(this);

			// Register for push notifications
			System.Diagnostics.Debug.WriteLine("Registering...");
			GcmClient.Register(this, Constants.SenderID);
		}
	}
}

