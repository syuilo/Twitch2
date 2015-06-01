using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading.Tasks;
using Twitch.Entity;

namespace Twitch.API
{
	public partial class Rest
	{
		[AuthenticationRequired]
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

		[AuthenticationRequired]
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
