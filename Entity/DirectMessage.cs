using System;
using System.Threading.Tasks;

namespace Twitch.Entity
{
	/// <summary>
	/// ダイレクトメッセージ
	/// </summary>
	[Serializable]
	public class DirectMessage : Response.DirectMessage
	{
		public DirectMessage()
			: base() { }

		public DirectMessage(string source)
			: base(source) { }
	}
}
