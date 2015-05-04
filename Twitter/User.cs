using System;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Twitch
{
	public partial class Twitter
	{
		/// <summary>
		/// Twitterのユーザー(アカウント)を表します。
		/// </summary>
		[Serializable]
		public class User : Response.Users.User, ISerializationSurrogate
		{
			public User()
				: base() { }

			public User(Twitter twitter, string source)
				: base(twitter, source) { }

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
				private set
				{
					this.DisplayScreenName = value;
				}
			}

			/// <summary>
			/// 
			/// </summary>
			public void GetHeader()
			{

			}


			/// <summary>
			/// フォローします。
			/// </summary>
			/// <returns>成功したかどうか</returns>
			public async Task<bool> Follow()
			{
				return await this.Twitter.FriendshipsCreate(id: this.ID) != null;
			}

			/// <summary>
			/// フォローを解除します。
			/// </summary>
			/// <returns>成功したかどうか</returns>
			public async Task<bool> Remove()
			{
				return await this.Twitter.FriendshipsDestory(id: this.ID) != null;
			}

			/// <summary>
			/// スパムとして報告します。
			/// </summary>
			/// <returns>成功したかどうか</returns>
			public async Task<bool> SpamAndBlock()
			{
				return await this.Twitter.UsersReportSpam(user_id: this.ID) != null;
			}

			// リストに追加します。
			// 
			// ブロックします。
		}
	}
}
