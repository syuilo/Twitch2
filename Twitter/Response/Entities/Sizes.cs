using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitch.Response.Entities
{
	/// <summary>
	/// Sizes情報を格納する Twitch.Twitter.TwitterResponse です。
	/// </summary>
	[Serializable]
	public class Sizes : TwitterResponse
	{
		public Sizes()
			: base() { }

		public Sizes(string source)
			: base(source)
		{
			this.Thumb = new Size(this.Json["thumb"].ToString());
			this.Large = new Size(this.Json["large"].ToString());
			this.Medium = new Size(this.Json["medium"].ToString());
			this.Small = new Size(this.Json["small"].ToString());
		}

		/// <summary>
		/// 
		/// </summary>
		public Size Thumb
		{
			get;
			private set;
		}

		/// <summary>
		/// 
		/// </summary>
		public Size Large
		{
			get;
			private set;
		}

		/// <summary>
		/// 
		/// </summary>
		public Size Medium
		{
			get;
			private set;
		}

		/// <summary>
		/// 
		/// </summary>
		public Size Small
		{
			get;
			private set;
		}
	}
}
