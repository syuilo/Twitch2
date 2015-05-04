using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitch
{
	public partial class Twitter
	{
		/// <summary>
		/// 指定したユーザーをフォローします。
		/// </summary>
		/// <param name="screen_name">フォローするユーザーのScreenName。</param>
		/// <param name="id">フォローするユーザーのID。</param>
		/// <param name="follow">このユーザーからの通知を受け取るかどうかを示す System.Boolean 値。</param>
		/// <returns>フォローされたユーザー</returns>
		public async Task<User> FriendshipsCreate(
			string screen_name = null,
			Int64? id = null,
			bool follow = false)
		{
			var query = new StringDictionary();
			query["screen_name"] = screen_name;
			query["user_id"] = id.ToString();
			query["follow"] = follow.ToString();

			return new User(this,
				await this.Request(
					API.Method.POST,
					new Uri(API.Urls.Friendships_Create), query));
		}

		/// <summary>
		/// 指定したユーザーのフォローを解除します。
		/// </summary>
		/// <param name="screen_name">フォローを解除するユーザーのScreenName。</param>
		/// <param name="id">フォローを解除するユーザーのID。</param>
		/// <returns>フォローを解除されたユーザー</returns>
		public async Task<User> FriendshipsDestory(
			string screen_name = null,
			Int64? id = null)
		{
			var query = new StringDictionary();
			query["screen_name"] = screen_name;
			query["user_id"] = id.ToString();

			return new User(this,
				await this.Request(
					API.Method.POST,
					new Uri(API.Urls.Friendships_Destroy), query));
		}
	}
}
