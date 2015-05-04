using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitch.Response.Entities
{
	/// <summary>
	/// Size情報を格納する Twitch.Twitter.TwitterResponse です。
	/// </summary>
	[Serializable]
	public class Size : TwitterResponse
	{
		public Size()
			: base() { }

		public Size(string source)
			: base(source)
		{
			this.H = this.Json["h"];
			this.W = this.Json["w"];
			this.Resize = this.Json["resize"];
		}

		/// <summary>
		/// 
		/// </summary>
		public double H
		{
			get;
			private set;
		}

		/// <summary>
		/// 
		/// </summary>
		public double W
		{
			get;
			private set;
		}

		/// <summary>
		/// 
		/// </summary>
		public string Resize
		{
			get;
			private set;
		}
	}
}
