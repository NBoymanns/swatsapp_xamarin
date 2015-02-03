using System;
using WindowsAzure.Messaging;

namespace SwatsApp.iOS
{
	public class Constants
	{
		public Constants ()
		{
		}

		public const string ConnectionString = "Endpoint=sb://swatsapphub-ns.servicebus.windows.net/;SharedAccessKeyName=DefaultFullSharedAccessSignature;SharedAccessKey=fcIlAOoHM5AZVciSGfvKM5hrnaDpP4B4iaiWls7A9zE=";
		public const string NotificationHubPath = "swatsapphub"; //"<Azure hub path>";
	}
}
//Endpoint=sb://swatsapphub-ns.servicebus.windows.net/;SharedAccessKeyName=DefaultFullSharedAccessSignature;SharedAccessKey=fcIlAOoHM5AZVciSGfvKM5hrnaDpP4B4iaiWls7A9zE=

