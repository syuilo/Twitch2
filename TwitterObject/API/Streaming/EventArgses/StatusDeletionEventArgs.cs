using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitch.Streaming
{
	public class StatusDeletionEventArgs : EventArgs
	{
		public Int64 ID
		{
			get;
			set;
		}

		public string StringID
		{
			get;
			set;
		}

		public Int64 UserID
		{
			get;
			set;
		}

		public string StringUserID
		{
			get;
			set;
		}
	}
}
