using System;
using System.Collections.Specialized;
using System.Threading.Tasks;
using Twitch.Entity;

namespace Twitch
{
	public partial class Twitter
	{
		/// <summary>
		/// ユーザーを取得します。
		/// 
		/// Returns a variety of information about the user specified by the required user_id or screen_name parameter.
		/// The author's most recent Tweet will be returned inline when possible.
		///
		/// GET users/lookup is used to retrieve a bulk collection of user objects.
		/// </summary>
		/// <param name="user_id">取得するユーザーのID。</param>
		/// <param name="screen_name">取得するユーザーのScreenName。</param>
		/// <returns>ユーザー</returns>
		public async Task<User> UsersShow(
			Int64? user_id = null,
			string screen_name = null)
		{
			var query = new StringDictionary();
			query["user_id"] = user_id.ToString();
			query["screen_name"] = screen_name;

			return new User(
				await this.Request(
					API.Method.GET,
					new Uri(API.Urls.Users_Show), query));
		}

		/// <summary>
		/// 対象のアカウントをスパムとして報告します。
		/// 
		/// Report the specified user as a spam account to Twitter.
		/// Additionally performs the equivalent of POST blocks/create on behalf of the authenticated user.
		/// </summary>
		/// <param name="user_id">スパム報告されるユーザーのID。</param>
		/// <param name="screen_name">スパム報告されるユーザーのScreenName。</param>
		/// <returns>スパム報告されたユーザー</returns>
		public async Task<User> UsersReportSpam(
			Int64? user_id = null,
			string screen_name = null)
		{
			var query = new StringDictionary();
			query["user_id"] = user_id.ToString();
			query["screen_name"] = screen_name;

			return new User(
				await this.Request(
					API.Method.POST,
					new Uri(API.Urls.Users_ReportSpam), query));
		}
	}
}
