using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitch.Streaming
{
	public class FriendsListsEventArgs : EventArgs
	{
		public string[] StringList
		{
			get;
			set;
		}

		public Int64[] IntList
		{
			get;
			set;
		}
	}
}
