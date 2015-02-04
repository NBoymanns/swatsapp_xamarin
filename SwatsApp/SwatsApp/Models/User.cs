using System;
using System.Collections.Generic;

namespace SwatsApp
{
	public class User
	{
		public String id {
			get;
			set;
		}

		public String created {
			get;
			set;
		}

		public String name {
			get;
			set;
		}

		public String device_id {
			get;
			set;
		}

		public List<String> photos {
			get;
			set;
		}
	}
}