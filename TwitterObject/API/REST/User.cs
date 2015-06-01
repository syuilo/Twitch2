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
		/// ユーザーを取得します。
		/// </summary>
		/// <param name="userID">取得するユーザーのID</param>
		/// <returns>取得したユーザー</returns>
		public async Task<User> GetUser(Int64 userID)
		{
			return await
				API.Rest.UsersShow(user_id: userID);
		}

		/// <summary>
		/// ユーザーを取得します。
		/// </summary>
		/// <param name="screenName">取得するユーザーのScreenName</param>
		/// <returns>取得したユーザー</returns>
		public async Task<User> GetUser(string screenName)
		{
			return await
				API.Rest.UsersShow(screen_name: screenName);
		}

		/// <summary>
		/// 対象のアカウントをスパムとして報告します。
		/// </summary>
		/// <param name="userID">対象のユーザーのID</param>
		/// <returns>スパム報告されたユーザー</returns>
		public async Task<User> UsersReportSpam(Int64 userID)
		{
			return await
				API.Rest.UsersReportSpam(user_id: userID);
		}

		/// <summary>
		/// 対象のアカウントをスパムとして報告します。
		/// </summary>
		/// <param name="screenName">対象のScreenName</param>
		/// <returns>スパム報告されたユーザー</returns>
		public async Task<User> UsersReportSpam(string screenName)
		{
			return await
				API.Rest.UsersReportSpam(screen_name: screenName);
		}
	}
}
