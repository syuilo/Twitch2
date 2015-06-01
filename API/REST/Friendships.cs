using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitch.Entity;

namespace Twitch.API
{
	public partial class Rest
	{
		[AuthenticationRequired]
		public static async Task<User> FriendshipsCreate(
			Twitter twitter,
			string screen_name = null,
			Int64? id = null,
			bool follow = false)
		{
			var query = new Dictionary<string, string>();
			query["screen_name"] = screen_name;
			query["user_id"] = id.ToString();
			query["follow"] = follow.ToString();

			return new User(
				await twitter.Request(
					API.Method.POST,
					new Uri(API.Urls.Friendships_Create), query));
		}

		[AuthenticationRequired]
		public static async Task<User> FriendshipsDestory(
			Twitter twitter,
			string screen_name = null,
			Int64? id = null)
		{
			var query = new Dictionary<string, string>();
			query["screen_name"] = screen_name;
			query["user_id"] = id.ToString();

			return new User(
				await twitter.Request(
					API.Method.POST,
					new Uri(API.Urls.Friendships_Destroy), query));
		}
	}
}
