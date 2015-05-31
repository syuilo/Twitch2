using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitch.Streaming
{
	public class StreamEventArgs : EventArgs
	{
		public StreamEventArgs(string data = null)
		{
			this.Data = data;
		}

		public string Data
		{
			get;
			set;
		}
	}
}
