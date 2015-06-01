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
		public static async Task<User> UsersShow(
			Twitter twitter,
			Int64? user_id = null,
			string screen_name = null)
		{
			var query = new Dictionary<string, string>();
			query["user_id"] = user_id.ToString();
			query["screen_name"] = screen_name;

			return new User(
				await twitter.Request(
					API.Method.GET,
					new Uri(API.Urls.Users_Show), query));
		}

		[AuthenticationRequired]
		public static async Task<User> UsersReportSpam(
			Twitter twitter,
			Int64? user_id = null,
			string screen_name = null)
		{
			var query = new Dictionary<string, string>();
			query["user_id"] = user_id.ToString();
			query["screen_name"] = screen_name;

			return new User(
				await twitter.Request(
					API.Method.POST,
					new Uri(API.Urls.Users_ReportSpam), query));
		}
	}
}
