using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading.Tasks;

namespace Twitch
{
	public partial class Twitter
	{
		/// <summary>
		/// ダイレクト メッセージを送信します。
		/// </summary>
		/// <param name="text">ダイレクト メッセージの本文。</param>
		/// <param name="screen_name">宛先のユーザーのScreenName。</param>
		/// <param name="id">宛先のユーザーのID。</param>
		/// <returns></returns>
		public async Task<string> DirectMessagesNew(
			string text, string screen_name = null, Int64? id = null)
		{
			var query = new Dictionary<string, string>();
			query["text"] = text;
			query["screen_name"] = screen_name;
			query["user_id"] = id.ToString();

			return await this.Request(API.Method.POST, new Uri(API.Urls.DirectMessages_New), query);
		}
	}
}
