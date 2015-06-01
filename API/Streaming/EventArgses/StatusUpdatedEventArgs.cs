using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitch.Entity;

namespace Twitch.Streaming
{
	public class StatusUpdatedEventArgs : EventArgs
	{
		public Status Status
		{
			get;
			set;
		}
	}
}
