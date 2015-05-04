using System;
using System.Collections.Specialized;
using System.Threading.Tasks;
using Twitch.Entity;

namespace Twitch
{
	public partial class Twitter
	{
		/// <summary>
		/// アカウントのプロフィールを各種変更します。
		/// </summary>
		/// <param name="name">名前。nullまたは指定しなかった場合はこのパラメータは更新されません。</param>
		/// <param name="url">ウェブサイト URL。nullまたは指定しなかった場合はこのパラメータは更新されません。</param>
		/// <param name="location">場所。nullまたは指定しなかった場合はこのパラメータは更新されません。</param>
		/// <param name="description">自己紹介。nullまたは指定しなかった場合はこのパラメータは更新されません。</param>
		/// <returns>更新されたユーザー。</returns>
		public async Task<User> UpdateProfile(
			string name = null,
			Uri url = null,
			string location = null,
			string description = null)
		{
			var query = new StringDictionary();
			if (name != null) query["name"] = name;
			if (url != null) query["url"] = url.ToString();
			if (location != null) query["location"] = location;
			if (description != null) query["description"] = description;

			return new User(await this.Request(API.Method.POST, new Uri(API.Urls.Account_UpdateProfile), query));
		}

		/// <summary>
		/// TwitterContextのアイコンを更新します。
		/// </summary>
		/// <param name="image">base64エンコードされたgifまたはjpgまたはpngの画像。</param>
		/// <returns>更新されたユーザー。</returns>
		public async Task<User> UpdateProfileImage(string image)
		{
			var query = new StringDictionary();
			query["image"] = image;

			return new User(await this.Request(API.Method.POST, new Uri(API.Urls.Account_UpdateProfileImage), query));
		}
	}
}
