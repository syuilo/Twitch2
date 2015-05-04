using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitch.Entity
{
	/// <summary>
	/// Geo情報を格納する Twitch.Twitter.TwitterResponse です。
	/// </summary>
	[Serializable]
	public class Geo : TwitterResponse
	{
		public Geo()
			: base() { }

		public Geo(string source)
			: base(source)
		{

		}
	}
}
