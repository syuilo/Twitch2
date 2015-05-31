using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading.Tasks;

namespace Twitch.API
{
	public partial class Rest
	{
		public static async Task<string> DirectMessagesNew(
			Twitter twitter,
			string text, string screen_name = null,
			Int64? id = null)
		{
			var query = new Dictionary<string, string>();
			query["text"] = text;
			query["screen_name"] = screen_name;
			query["user_id"] = id.ToString();

			return await twitter.Request(
				API.Method.POST, new Uri(API.Urls.DirectMessages_New), query);
		}
	}
}
