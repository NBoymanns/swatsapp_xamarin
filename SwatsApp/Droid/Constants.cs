using System;

namespace SwatsApp.Droid
{
	public class Constants
	{
		public const string SenderID = "1022468187177"; // Google API Project Number

		// Azure app specific connection string and hub path
		public const string ConnectionString = "Endpoint=sb://swatsapphub-ns.servicebus.windows.net/;SharedAccessKeyName=DefaultFullSharedAccessSignature;SharedAccessKey=fcIlAOoHM5AZVciSGfvKM5hrnaDpP4B4iaiWls7A9zE=";
		public const string NotificationHubPath = "swatsapphub";
	}
}

