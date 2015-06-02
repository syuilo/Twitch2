using System;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Twitch.Entity
{
	/// <summary>
	/// Twitterのユーザー(アカウント)を表します。
	/// </summary>
	[Serializable]
	public class User : Response.Users.User, ISerializationSurrogate
	{
		public User()
			: base() { }

		public User(string source)
			: base(source) { }

		public void GetObjectData(
			object obj, SerializationInfo info, StreamingContext context)
		{
			base.GetObjectData(obj, info, context);
		}

		public object SetObjectData(
			object obj, SerializationInfo info, StreamingContext context, ISurrogateSelector selector)
		{
			return base.SetObjectData(obj, info, context, selector);
		}

		/// <summary>
		/// @を含むScreenNameを取得します。
		/// </summary>
		public string DisplayScreenName
		{
			get
			{
				return '@' + this.ScreenName;
			}
		}
	}
}
