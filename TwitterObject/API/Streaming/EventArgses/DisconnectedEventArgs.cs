using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitch.Streaming
{
	public class DisconnectedEventArgs : EventArgs
	{
		public int Code
		{
			get;
			set;
		}

		public string StreamName
		{
			get;
			set;
		}

		public string Reason
		{
			get;
			set;
		}
	}
}
