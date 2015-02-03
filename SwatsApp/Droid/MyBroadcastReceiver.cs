using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

using Android.App;
using Android.Content;
using Android.Util;

using ByteSmith.WindowsAzure.Messaging;
using Gcm.Client;

[assembly: Permission(Name = "nl.ocb.swatsapp.permission.C2D_MESSAGE")]
[assembly: UsesPermission(Name = "nl.ocb.swatsapp.permission.C2D_MESSAGE")]
[assembly: UsesPermission(Name = "com.google.android.c2dm.permission.RECEIVE")]


namespace SwatsApp.Droid
{
	[BroadcastReceiver(Permission=Gcm.Client.Constants.PERMISSION_GCM_INTENTS)]
	[IntentFilter(new string[] { Gcm.Client.Constants.INTENT_FROM_GCM_MESSAGE }, Categories = new string[] { "nl.ocb.swatsapp" })]
	[IntentFilter(new string[] { Gcm.Client.Constants.INTENT_FROM_GCM_REGISTRATION_CALLBACK }, Categories = new string[] { "nl.ocb.swatsapp" })]
	[IntentFilter(new string[] { Gcm.Client.Constants.INTENT_FROM_GCM_LIBRARY_RETRY }, Categories = new string[] { "nl.ocb.swatsapp" })]
	public class MyBroadcastReceiver : GcmBroadcastReceiverBase<GcmService>
	{
		public static string[] SENDER_IDS = new string[] { Constants.SenderID };

		public const string TAG = "MyBroadcastReceiver-GCM";
	}

	[Service] //Must use the service tag
	public class GcmService : GcmServiceBase
	{
		public static string RegistrationID { get; private set; }
		private NotificationHub Hub { get; set; }

		public GcmService() : base(Constants.SenderID) 
		{
			Log.Info(MyBroadcastReceiver.TAG, "GcmService() constructor"); 
		}

		protected override async void OnRegistered(Context context, string registrationId)
		{
			Log.Verbose(MyBroadcastReceiver.TAG, "GCM Registered: " + registrationId);
			RegistrationID = registrationId;

			createNotification("GcmService-GCM Registered...", "The device has been Registered, Tap to View!");

			Hub = new NotificationHub(Constants.NotificationHubPath, Constants.ConnectionString);
			try
			{
				await Hub.UnregisterAllAsync(registrationId);
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.Message);
				Debugger.Break();
			}

			var tags = new List<string>() { "falcons" }; // create tags if you want

			try
			{
				var hubRegistration = await Hub.RegisterNativeAsync(registrationId, tags);
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.Message); 
				Debugger.Break();
			}
		}

		protected override void OnUnRegistered (Context context, string registrationId)
		{
			Log.Verbose(MyBroadcastReceiver.TAG, "GCM Unregistered: " + registrationId);
			//Remove from the web service
			//	var wc = new WebClient();
			//	var result = wc.UploadString("http://your.server.com/api/unregister/", "POST",
			//		"{ 'registrationId' : '" + lastRegistrationId + "' }");

			createNotification("GCM Unregistered...", "The device has been unregistered, Tap to View!");
		}

		protected override void OnMessage(Context context, Intent intent)
		{
			Log.Info(MyBroadcastReceiver.TAG, "GCM Message Received!");

			var msg = new StringBuilder();

			if (intent != null && intent.Extras != null)
			{
				foreach (var key in intent.Extras.KeySet())
					msg.AppendLine(key + "=" + intent.Extras.Get(key).ToString());
			}

			string messageText = intent.Extras.GetString("msg");
			if (!string.IsNullOrEmpty(messageText))
			{
				createNotification("New hub message!", messageText);
				return;
			}

			createNotification("Unknown message details", msg.ToString());
		}

		protected override void OnError (Context context, string errorId)
		{
			Log.Error(MyBroadcastReceiver.TAG, "GCM Error: " + errorId);
		}

		void createNotification(string title, string desc)
		{
			//Create notification
			var notificationManager = GetSystemService(Context.NotificationService) as NotificationManager;

			//Create an intent to show ui
			var uiIntent = new Intent(this, typeof(MainActivity));

			//Create the notification
			var notification = new Notification(Android.Resource.Drawable.SymActionEmail, title);

			//Auto cancel will remove the notification once the user touches it
			notification.Flags = NotificationFlags.AutoCancel;

			//Set the notification info
			//we use the pending intent, passing our ui intent over which will get called
			//when the notification is tapped.
			notification.SetLatestEventInfo(this, title, desc, PendingIntent.GetActivity(this, 0, uiIntent, 0));

			//Show the notification
			notificationManager.Notify(1, notification);
		}
	}
}