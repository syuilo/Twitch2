using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading.Tasks;
using Twitch.Entity;

namespace Twitch
{
	public partial class Twitter
	{
		/// <summary>
		/// 指定されたユーザーをミュートします。
		/// </summary>
		/// <param name="screen_name">ミュートするユーザーのScreenName。</param>
		/// <param name="id">ミュートするユーザーのID。</param>
		/// <returns>ミュートされたユーザー</returns>
		public async Task<User> MutesUsersCreate(
			string screen_name = null, Int64? id = null)
		{
			var query = new Dictionary<string, string>();
			query["screen_name"] = screen_name;
			query["user_id"] = id.ToString();

			return new User(
				await this.Request(
					API.Method.POST,
					new Uri(API.Urls.Mutes_Users_Create), query));
		}

		/// <summary>
		/// 指定したユーザーのミュートを解除します。
		/// </summary>
		/// <param name="screen_name">ミュートを解除するユーザーのScreenName。</param>
		/// <param name="id">ミュートを解除するユーザーのID。</param>
		/// <returns>ミュートを解除されたユーザー</returns>
		public async Task<User> MutesUsersDestroy(
			string screen_name = null, Int64? id = null)
		{
			var query = new Dictionary<string, string>();
			query["screen_name"] = screen_name;
			query["user_id"] = id.ToString();

			return new User(
				await this.Request(
					API.Method.POST,
					new Uri(API.Urls.Mutes_Users_Destroy), query));
		}
	}
}
