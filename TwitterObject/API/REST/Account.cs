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
		/// プロフィールとして表示される「名前」を更新します。
		/// </summary>
		/// <returns></returns>
		public async Task<User> ChangeName(string name)
		{
			return await
				API.Rest.UpdateProfile(this, name: name);
		}

		/// <summary>
		/// プロフィールとして表示される「URL(ホームページアドレス)」を更新します。
		/// </summary>
		/// <returns></returns>
		public async Task<User> ChangeURL(Uri url)
		{
			return await
				API.Rest.UpdateProfile(this, url: url);
		}

		/// <summary>
		/// プロフィールとして表示される「場所(現在地)」を更新します。
		/// </summary>
		/// <returns></returns>
		public async Task<User> ChangeLocation(string location)
		{
			return await
				API.Rest.UpdateProfile(this, location: location);
		}

		/// <summary>
		/// プロフィールとして表示される「BIO(自己紹介)」を更新します。
		/// </summary>
		/// <returns></returns>
		public async Task<User> ChangeBio(string bio)
		{
			return await
				API.Rest.UpdateProfile(this, description: bio);
		}

		/// <summary>
		/// アイコンを更新します。
		/// </summary>
		/// <param name="image">base64エンコードされたgifまたはjpgまたはpngの画像</param>
		/// <returns>更新されたユーザー</returns>
		public async Task<User> UpdateProfileImage(string image)
		{
			return await
				API.Rest.UpdateProfileImage(this, image);
		}
	}
}
