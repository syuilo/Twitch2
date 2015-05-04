using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitch.Streaming
{
	public class StatusUpdatedEventArgs : EventArgs
	{
		public Twitter.Status Status
		{
			get;
			set;
		}
	}
}
