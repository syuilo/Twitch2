using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitch.Entity;

namespace Twitch
{
	public partial class Twitter
	{
		[Obsolete("オーバーロードを使用してください。")]
		/// <summary>
		/// 指定したユーザーをフォローします。
		/// </summary>
		/// <param name="screen_name">フォローするユーザーのScreenName</param>
		/// <param name="id">フォローするユーザーのID</param>
		/// <param name="follow">ユーザーからの通知を受け取るかどうかを示す System.Boolean 値。</param>
		/// <returns>フォローされたユーザー</returns>
		public async Task<User> FriendshipsCreate(
			string screen_name = null,
			Int64? id = null,
			bool follow = false)
		{
			var query = new Dictionary<string, string>();
			query["screen_name"] = screen_name;
			query["user_id"] = id.ToString();
			query["follow"] = follow.ToString();

			return new User(
				await this.Request(
					API.Method.POST,
					new Uri(API.Urls.Friendships_Create), query));
		}

		/// <summary>
		/// 指定したユーザーをフォローします。
		/// </summary>
		/// <param name="id">フォローするユーザーのID</param>
		/// <param name="follow">ユーザーからの通知を受け取るかどうかを示す System.Boolean 値</param>
		/// <returns>フォローされたユーザー</returns>
		public async Task<User> FriendshipsCreate(
			Int64 id,
			bool follow = false)
		{
			var query = new Dictionary<string, string>();
			query["user_id"] = id.ToString();
			query["follow"] = follow.ToString();

			return new User(
				await this.Request(
					API.Method.POST,
					new Uri(API.Urls.Friendships_Create), query));
		}

		/// <summary>
		/// 指定したユーザーをフォローします。
		/// </summary>
		/// <param name="screen_name">フォローするユーザーのScreenName</param>
		/// <param name="follow">ユーザーからの通知を受け取るかどうかを示す System.Boolean 値</param>
		/// <returns>フォローされたユーザー</returns>
		public async Task<User> FriendshipsCreate(
			string screen_name,
			bool follow = false)
		{
			var query = new Dictionary<string, string>();
			query["screen_name"] = screen_name;
			query["follow"] = follow.ToString();

			return new User(
				await this.Request(
					API.Method.POST,
					new Uri(API.Urls.Friendships_Create), query));
		}

		/// <summary>
		/// 指定したユーザーをフォローします。
		/// </summary>
		/// <param name="user">フォローするユーザー</param>
		/// <param name="follow">ユーザーからの通知を受け取るかどうかを示す System.Boolean 値</param>
		/// <returns>フォローされたユーザー</returns>
		public async Task<User> FriendshipsCreate(
			User user,
			bool follow = false)
		{
			return await this.FriendshipsCreate(user.ID, follow);
		}

		[Obsolete("オーバーロードを使用してください。")]
		/// <summary>
		/// 指定したユーザーのフォローを解除します。
		/// </summary>
		/// <param name="screen_name">フォローを解除するユーザーのScreenName</param>
		/// <param name="id">フォローを解除するユーザーのID</param>
		/// <returns>フォローを解除されたユーザー</returns>
		public async Task<User> FriendshipsDestory(
			string screen_name = null,
			Int64? id = null)
		{
			var query = new Dictionary<string, string>();
			query["screen_name"] = screen_name;
			query["user_id"] = id.ToString();

			return new User(
				await this.Request(
					API.Method.POST,
					new Uri(API.Urls.Friendships_Destroy), query));
		}

		/// <summary>
		/// 指定したユーザーのフォローを解除します。
		/// </summary>
		/// <param name="id">フォローを解除するユーザーのID</param>
		/// <returns>フォローを解除されたユーザー</returns>
		public async Task<User> FriendshipsDestory(Int64 id)
		{
			var query = new Dictionary<string, string>();
			query["user_id"] = id.ToString();

			return new User(
				await this.Request(
					API.Method.POST,
					new Uri(API.Urls.Friendships_Destroy), query));
		}

		/// <summary>
		/// 指定したユーザーのフォローを解除します。
		/// </summary>
		/// <param name="screen_name">フォローを解除するユーザーのScreenName</param>
		/// <returns>フォローを解除されたユーザー</returns>
		public async Task<User> FriendshipsDestory(string screen_name)
		{
			var query = new Dictionary<string, string>();
			query["screen_name"] = screen_name;

			return new User(
				await this.Request(
					API.Method.POST,
					new Uri(API.Urls.Friendships_Destroy), query));
		}
	}
}
