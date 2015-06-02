using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Twitch.Entity;

namespace Twitch
{
	public partial class Twitter
	{
		#region ChangeName

		/// <summary>
		/// プロフィールとして表示される「名前」を更新します。
		/// </summary>
		public async void ChangeName(string name)
		{
			await
				API.Rest.UpdateProfile(this, name: name);
		}

		#endregion

		#region ChangeURL

		/// <summary>
		/// プロフィールとして表示される「URL(ホームページアドレス)」を更新します。
		/// </summary>
		public async void ChangeURL(Uri url)
		{
			await
				API.Rest.UpdateProfile(this, url: url);
		}

		#endregion

		#region ChangeLocation

		/// <summary>
		/// プロフィールとして表示される「場所(現在地)」を更新します。
		/// </summary>
		public async void ChangeLocation(string location)
		{
			await
				API.Rest.UpdateProfile(this, location: location);
		}

		#endregion

		#region ChangeBio

		/// <summary>
		/// プロフィールとして表示される「BIO(自己紹介)」を更新します。
		/// </summary>
		public async void ChangeBio(string bio)
		{
			await
				API.Rest.UpdateProfile(this, description: bio);
		}

		#endregion

		#region ChangeIcon

		/// <summary>
		/// アイコンを更新します。
		/// </summary>
		/// <param name="image">base64エンコードされたgifまたはjpgまたはpngの画像</param>
		public async void ChangeIcon(string image)
		{
			await
				API.Rest.UpdateProfileImage(this, image);
		}

		#endregion

		#region Block

		/// <summary>
		/// ユーザーをブロックします。
		/// </summary>
		/// <param name="id">ブロックするユーザーのID</param>
		/// <returns>ブロックされたユーザー</returns>
		public async Task<User> Block(Int64 id)
		{
			return await
				API.Rest.BlocksCreate(this, id: id);
		}

		/// <summary>
		/// ユーザーをブロックします。
		/// </summary>
		/// <param name="screenName">ブロックするユーザーのScreenName</param>
		/// <returns>ブロックされたユーザー</returns>
		public async Task<User> Block(string screenName)
		{
			return await
				API.Rest.BlocksCreate(this, screen_name: screenName);
		}

		#endregion

		#region UnBlock

		/// <summary>
		/// ユーザーのブロックを解除します。
		/// </summary>
		/// <param name="id">ブロックを解除するユーザーのID</param>
		/// <returns>ブロックを解除されたユーザー</returns>
		public async Task<User> UnBlock(Int64 id)
		{
			return await
				API.Rest.BlocksDestroy(this, id: id);
		}

		/// <summary>
		/// ユーザーのブロックを解除します。
		/// </summary>
		/// <param name="screenName">ブロックを解除するユーザーのScreenName</param>
		/// <returns>ブロックを解除されたユーザー</returns>
		public async Task<User> UnBlock(string screenName)
		{
			return await
				API.Rest.BlocksDestroy(this, screen_name: screenName);
		}

		#endregion

		#region SendDirectMessage

		/// <summary>
		/// ダイレクトメッセージを送信します。
		/// </summary>
		/// <param name="text">ダイレクトメッセージ本文</param>
		/// <param name="id">宛先のユーザーのID</param>
		/// <returns></returns>
		public async Task<DirectMessage> SendDirectMessage(
			string text, Int64 id)
		{
			return await
				API.Rest.DirectMessagesNew(this, text, id: id);
		}

		/// <summary>
		/// ダイレクトメッセージを送信します。
		/// </summary>
		/// <param name="text">ダイレクトメッセージ本文</param>
		/// <param name="screenName">宛先のユーザーのScreenName</param>
		/// <returns></returns>
		public async Task<DirectMessage> SendDirectMessage(
			string text, string screenName)
		{
			return await
				API.Rest.DirectMessagesNew(this, text, screen_name: screenName);
		}

		/// <summary>
		/// ダイレクトメッセージを送信します。
		/// </summary>
		/// <param name="text">ダイレクトメッセージ本文</param>
		/// <param name="user">宛先のユーザー</param>
		/// <returns></returns>
		public async Task<DirectMessage> SendDirectMessage(
			string text, User user)
		{
			return await
				API.Rest.DirectMessagesNew(this, text, id: user.ID);
		}

		#endregion

		#region Follow

		/// <summary>
		/// 指定したユーザーをフォローします。
		/// </summary>
		/// <param name="id">フォローするユーザーのID</param>
		/// <param name="follow">ユーザーからの通知を受け取るかどうか</param>
		/// <returns>フォローされたユーザー</returns>
		public async Task<User> Follow(
			Int64 id, bool follow = false)
		{
			return await
				API.Rest.FriendshipsCreate(this, id: id);
		}

		/// <summary>
		/// 指定したユーザーをフォローします。
		/// </summary>
		/// <param name="screenName">フォローするユーザーのScreenName</param>
		/// <param name="follow">ユーザーからの通知を受け取るかどうか</param>
		/// <returns>フォローされたユーザー</returns>
		public async Task<User> FriendshipsCreate(
			string screenName,
			bool follow = false)
		{
			return await
				API.Rest.FriendshipsCreate(this, screen_name: screenName);
		}

		/// <summary>
		/// 指定したユーザーをフォローします。
		/// </summary>
		/// <param name="user">フォローするユーザー</param>
		/// <param name="follow">ユーザーからの通知を受け取るかどうか</param>
		/// <returns>フォローされたユーザー</returns>
		public async Task<User> FriendshipsCreate(
			User user,
			bool follow = false)
		{
			return await
				API.Rest.FriendshipsCreate(this, id: user.ID);
		}

		#endregion

		#region Remove

		/// <summary>
		/// 指定したユーザーのフォローを解除します。
		/// </summary>
		/// <param name="id">フォローを解除するユーザーのID</param>
		/// <returns>フォローを解除されたユーザー</returns>
		public async Task<User> Remove(Int64 id)
		{
			return await
				API.Rest.FriendshipsDestory(this, id: id);
		}

		/// <summary>
		/// 指定したユーザーのフォローを解除します。
		/// </summary>
		/// <param name="screenName">フォローを解除するユーザーのScreenName</param>
		/// <returns>フォローを解除されたユーザー</returns>
		public async Task<User> FriendshipsDestory(string screenName)
		{
			return await
				API.Rest.FriendshipsDestory(this, screen_name: screenName);
		}

		/// <summary>
		/// 指定したユーザーのフォローを解除します。
		/// </summary>
		/// <param name="user">フォローを解除するユーザー</param>
		/// <returns>フォローを解除されたユーザー</returns>
		public async Task<User> FriendshipsDestory(User user)
		{
			return await
				API.Rest.FriendshipsDestory(this, id: user.ID);
		}

		#endregion

		#region CreateList

		/// <summary>
		/// リストを作成します。
		/// </summary>
		/// <param name="name">リスト名</param>
		/// <param name="description">リストの説明</param>
		/// <param name="mode">リストの公開状態。 public または private のいずれかを指定します。nullまたは指定しなかった場合はpublic(公開)になります。</param>
		/// <returns>作成されたリスト</returns>
		public async Task<List> CreateList(
			string name, string description, ListMode? mode = null)
		{
			if (mode != null)
			{
				return await
					API.Rest.ListsCreate(this, name, description, mode.ToString());
			}
			else
			{
				return await
					API.Rest.ListsCreate(this, name, description, null);
			}
		}

		#endregion

		#region DeleteList

		/// <summary>
		/// リストを削除します。
		/// </summary>
		/// <param name="id">リストのID</param>
		/// <returns>削除されたリスト</returns>
		public async Task<List> DeleteList(Int64 id)
		{
			return await
				API.Rest.ListsDestroy(this, list_id: id);
		}

		/// <summary>
		/// リストを削除します。
		/// </summary>
		/// <param name="list">リスト</param>
		/// <returns>削除されたリスト</returns>
		public async Task<List> DeleteList(List list)
		{
			return await
				API.Rest.ListsDestroy(this, list_id: list.ID);
		}

		/// <summary>
		/// リストを削除します。
		/// </summary>
		/// <param name="slug">リストのスラグ</param>
		/// <param name="ownerID">リスト作成者のID</param>
		/// <returns>削除されたリスト</returns>
		public async Task<List> DeleteList(string slug, Int64 ownerID)
		{
			return await
				API.Rest.ListsDestroy(this, slug: slug, owner_id: ownerID);
		}

		/// <summary>
		/// リストを削除します。
		/// </summary>
		/// <param name="slug">リストのスラグ</param>
		/// <param name="ownerScreenName">リスト作成者のScreenName</param>
		/// <returns>削除されたリスト</returns>
		public async Task<List> DeleteList(string slug, string ownerScreenName)
		{
			return await
				API.Rest.ListsDestroy(this, slug: slug, owner_screen_name: ownerScreenName);
		}

		#endregion

		#region ListMemberAdd

		/// <summary>
		/// ユーザーをリストに追加します。
		/// </summary>
		/// <param name="id">リストのID</param>
		/// <returns></returns>
		public async Task<List> ListMemberAdd(Int64 id)
		{
			return await
				API.Rest.ListsMembersCreate(this, list_id: id);
		}

		/// <summary>
		/// ユーザーをリストに追加します。
		/// </summary>
		/// <param name="list">リスト</param>
		/// <returns></returns>
		public async Task<List> ListMemberAdd(List list)
		{
			return await
				API.Rest.ListsMembersCreate(this, list_id: list.ID);
		}

		/// <summary>
		/// ユーザーをリストに追加します。
		/// </summary>
		/// <param name="slug">リストのスラグ</param>
		/// <param name="ownerID">リスト作成者のID</param>
		/// <returns></returns>
		public async Task<List> ListMemberAdd(string slug, Int64 ownerID)
		{
			return await
				API.Rest.ListsMembersCreate(this, slug: slug, owner_id: ownerID);
		}

		/// <summary>
		/// ユーザーをリストに追加します。
		/// </summary>
		/// <param name="slug">リストのスラグ</param>
		/// <param name="ownerScreenName">リスト作成者のScreenName</param>
		/// <returns></returns>
		public async Task<List> ListMemberAdd(string slug, string ownerScreenName)
		{
			return await
				API.Rest.ListsMembersCreate(this, slug: slug, owner_screen_name: ownerScreenName);
		}

		#endregion

		/// <summary>
		/// リストからメンバーを削除します。
		/// </summary>
		/// <param name="slug"></param>
		/// <param name="screen_name"></param>
		/// <param name="owner_screen_name"></param>
		/// <returns></returns>
		public async Task<string> ListsMembersDestroy(string slug, string screen_name, string owner_screen_name)
		{
			var query = new Dictionary<string, string>();
			query["slug"] = slug;
			query["screen_name"] = screen_name;
			query["owner_screen_name"] = owner_screen_name;

			return await this.Request(API.Method.POST, new Uri(API.Urls.Lists_Members_Destroy), query);
		}
	}
}
