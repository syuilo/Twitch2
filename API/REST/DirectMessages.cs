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
		public static async Task<DirectMessage> DirectMessagesNew(
			Twitter twitter,
			string text, string screen_name = null,
			Int64? id = null)
		{
			var query = new Dictionary<string, string>();
			query["text"] = text;
			query["screen_name"] = screen_name;
			query["user_id"] = id.ToString();

			return new DirectMessage(
				await twitter.Request(
					API.Method.POST, new Uri(API.Urls.DirectMessages_New), query));
		}
	}
}
