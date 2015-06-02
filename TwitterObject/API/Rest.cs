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

		#region GetTimeline

		/// <summary>
		/// ホーム タイムラインを取得します。
		/// </summary>
		/// <param name="count">取得するツイートの数。200以下でなければなりません。</param>
		/// <param name="trim_user">trueに設定すると、タイムライン上で返される各ツイートはステータスのみ作者数値IDを含むユーザーオブジェクトが含まれます。完全なユーザーオブジェクトを受け取るためには、このパラメータを省略します。</param>
		/// <param name="exclude_replies">trueに設定すると、取得するタイムラインからリツイートやリプライは除外されます。</param>
		/// <param name="contributor_details"></param>
		/// <param name="include_entities"></param>
		/// <returns>ツイートのリスト</returns>
		public async Task<List<Status>> GetTimeline(
			double count,
			bool trim_user = false,
			bool exclude_replies = false,
			bool contributor_details = false,
			bool include_entities = true)
		{
			return await
				API.Rest.StatusesHomeTimeline(
					this, count, null, null, trim_user, exclude_replies, contributor_details, include_entities);
		}

		/// <summary>
		/// ホーム タイムラインを取得します。
		/// </summary>
		/// <param name="count">取得するツイートの数。200以下でなければなりません。</param>
		/// <param name="since_id">指定したIDより大きなIDを持つ結果のみを返します(つまり、より新しい)。APIを介してアクセスできるツイートの数には制限があります。ツイートの制限がsince_id以来発生している場合は、since_idは、利用可能な最も古いIDに強制されます。</param>
		/// <param name="max_id">指定されたIDと同じか、それより古いIDを持つ結果のみを返します(つまり、より古い)。</param>
		/// <param name="trim_user">trueに設定すると、タイムライン上で返される各ツイートはステータスのみ作者数値IDを含むユーザーオブジェクトが含まれます。完全なユーザーオブジェクトを受け取るためには、このパラメータを省略します。</param>
		/// <param name="exclude_replies">trueに設定すると、取得するタイムラインからリツイートやリプライは除外されます。</param>
		/// <param name="contributor_details"></param>
		/// <param name="include_entities"></param>
		/// <returns>ツイートのリスト</returns>
		public async Task<List<Status>> GetTimeline(
			double count,
			Int64 since_id,
			Int64 max_id,
			bool trim_user = false,
			bool exclude_replies = false,
			bool contributor_details = false,
			bool include_entities = true)
		{
			if (since_id != null && max_id != null)
			{
				throw new ArgumentException("since_id と max_id を同時に指定することはできません。");
			}

			return await
				API.Rest.StatusesHomeTimeline(
					this, count, since_id, max_id, trim_user, exclude_replies, contributor_details, include_entities);
		}

		#endregion

		#region GetUserTimeline

		/// <summary>
		/// 指定したユーザーのタイムラインを取得します。
		/// </summary>
		/// <param name="userID">対象のユーザーのID</param>
		/// <param name="count">取得するツイートの数。200以下でなければなりません。</param>
		/// <param name="trim_user">trueに設定すると、タイムライン上で返される各ツイートはステータスのみ作者数値IDを含むユーザーオブジェクトが含まれます。完全なユーザーオブジェクトを受け取るためには、このパラメータを省略します。</param>
		/// <param name="exclude_replies">trueに設定すると、取得するタイムラインからリツイートやリプライは除外されます。</param>
		/// <param name="contributor_details"></param>
		/// <param name="include_rts"></param>
		/// <returns>ツイートのリスト</returns>
		public async Task<List<Status>> GetUserTimeline(
			Int64 userID,
			double count = 0,
			bool trim_user = false,
			bool exclude_replies = false,
			bool contributor_details = false,
			bool include_rts = false)
		{
			return await
				API.Rest.StatusesUserTimeline(this, userID, null, count, null, null, trim_user, exclude_replies, contributor_details, include_rts);
		}

		/// <summary>
		/// 指定したユーザーのタイムラインを取得します。
		/// </summary>
		/// <param name="user_id"></param>
		/// <param name="screen_name"></param>
		/// <param name="count">取得するツイートの数。200以下でなければなりません。</param>
		/// <param name="since_id">指定したIDより大きなIDを持つ結果のみを返します(つまり、より新しい)。APIを介してアクセスできるツイートの数には制限があります。ツイートの制限がsince_id以来発生している場合は、since_idは、利用可能な最も古いIDに強制されます。</param>
		/// <param name="max_id">指定されたIDと同じか、それより古いIDを持つ結果のみを返します(つまり、より古い)。</param>
		/// <param name="trim_user">trueに設定すると、タイムライン上で返される各ツイートはステータスのみ作者数値IDを含むユーザーオブジェクトが含まれます。完全なユーザーオブジェクトを受け取るためには、このパラメータを省略します。</param>
		/// <param name="exclude_replies">trueに設定すると、取得するタイムラインからリツイートやリプライは除外されます。</param>
		/// <param name="contributor_details"></param>
		/// <param name="include_rts"></param>
		/// <returns>ツイートのリスト</returns>
		public async Task<List<Status>> GetUserTimeline(
			Int64? user_id = null,
			string screen_name = null,
			double count = 0,
			Int64? since_id = null,
			Int64? max_id = null,
			bool trim_user = false,
			bool exclude_replies = false,
			bool contributor_details = false,
			bool include_rts = false)
		{
			if (since_id != null && max_id != null)
			{
				throw new ArgumentException("since_id と max_id を同時に指定することはできません。");
			}

			return await
				API.Rest.StatusesUserTimeline(this, user_id, screen_name, count, since_id, max_id, trim_user, exclude_replies, contributor_details, include_rts);
		}

		#endregion

		#region GetMentions

		/// <summary>
		/// メンション タイムラインを取得します。
		/// </summary>
		/// <param name="count">取得するツイートの数。200以下でなければなりません。</param>
		/// <param name="since_id">指定したIDより大きなIDを持つ結果のみを返します(つまり、より新しい)。APIを介してアクセスできるツイートの数には制限があります。ツイートの制限がsince_id以来発生している場合は、since_idは、利用可能な最も古いIDに強制されます。</param>
		/// <param name="max_id">指定されたIDと同じか、それより古いIDを持つ結果のみを返します(つまり、より古い)。</param>
		/// <param name="trim_user">trueに設定すると、タイムライン上で返される各ツイートはステータスのみ作者数値IDを含むユーザーオブジェクトが含まれます。完全なユーザーオブジェクトを受け取るためには、このパラメータを省略します。</param>
		/// <param name="contributor_details"></param>
		/// <param name="include_entities"></param>
		/// <returns>ツイートのリスト</returns>
		public async Task<List<Status>> GetMentions(
			double count = 0,
			Int64? since_id = null,
			Int64? max_id = null,
			bool trim_user = false,
			bool contributor_details = true,
			bool include_entities = true)
		{
			if (since_id != null && max_id != null)
			{
				throw new ArgumentException("since_id と max_id を同時に指定することはできません。");
			}

			return await API.Rest.StatusesMentionsTimeline(this, count, since_id, max_id, trim_user, contributor_details, include_entities);
		}

		#endregion

		#region Tweet

		/// <summary>
		/// 新しいツイートを投稿します。
		/// </summary>
		/// <param name="text">本文</param>
		/// <returns>投稿したツイート</returns>
		public async Task<Status> Tweet(string text)
		{
			return await API.Rest.StatusesUpdate(this, text);
		}

		/// <summary>
		/// 新しいツイートを投稿します。
		/// </summary>
		/// <param name="text">本文</param>
		/// <param name="replyID">返信元になるツイートのID</param>
		/// <returns>投稿したツイート</returns>
		public async Task<Status> Tweet(
			string text,
			Int64 replyID)
		{
			return await API.Rest.StatusesUpdate(this, text, replyID);
		}

		/// <summary>
		/// 新しいツイートを投稿します。
		/// </summary>
		/// <param name="text">本文</param>
		/// <param name="reply">返信元になるツイート</param>
		/// <returns>投稿したツイート</returns>
		public async Task<Status> Tweet(
			string text,
			Status reply)
		{
			return await API.Rest.StatusesUpdate(this, text, reply.ID);
		}

		#endregion

		#region Retweet

		/// <summary>
		/// 対象のツイートをリツイートします。
		/// </summary>
		/// <param name="id">リツイートするツイートのID</param>
		/// <returns>リツイートしたツイート</returns>
		public async Task<Status> Retweet(Int64 id)
		{
			return await API.Rest.StatusesRetweet(this, id);
		}

		/// <summary>
		/// 対象のツイートをリツイートします。
		/// </summary>
		/// <param name="status">リツイートするツイート</param>
		/// <returns>リツイートしたツイート</returns>
		public async Task<Status> Retweet(Status status)
		{
			return await this.Retweet(status.ID);
		}

		#endregion

		#region GetTweet

		/// <summary>
		/// ツイートを取得します。
		/// </summary>
		/// <param name="id">取得するツイートのID。</param>
		/// <returns>ツイート オブジェクト</returns>
		public async Task<Status> GetTweet(Int64 id)
		{
			var query = new Dictionary<string, string>();
			query["id"] = id.ToString();

			return new Status(
				await this.Request(API.Method.GET, new Uri(API.Urls.Statuses_Show), query));
		}

		#endregion

		#region Favorite

		/// <summary>
		/// ツイートをお気に入りに登録します。
		/// </summary>
		/// <param name="id">対象のツイートのID</param>
		/// <returns>対象のツイート</returns>
		public async Task<Status> Favorite(Int64 id)
		{
			return await
				API.Rest.FavoritesCreate(this, id);
		}

		/// <summary>
		/// ツイートをお気に入りに登録します。
		/// </summary>
		/// <param name="status">対象のツイート</param>
		/// <returns>対象のツイート</returns>
		public async Task<Status> Favorite(Status status)
		{
			return await
				API.Rest.FavoritesCreate(this, status.ID);
		}

		#endregion

		#region UnFavorite

		/// <summary>
		/// ツイートをお気に入りから削除します。
		/// </summary>
		/// <param name="id">対象のツイートのID</param>
		/// <returns>対象のツイート</returns>
		public async Task<Status> UnFavorite(Int64 id)
		{
			return await
				API.Rest.FavoritesDestroy(this, id);
		}

		/// <summary>
		/// ツイートをお気に入りから削除します。
		/// </summary>
		/// <param name="status">対象のツイート</param>
		/// <returns>対象のツイート</returns>
		public async Task<Status> UnFavorite(Status status)
		{
			return await
				API.Rest.FavoritesDestroy(this, status.ID);
		}

		#endregion

		#region GetUser

		/// <summary>
		/// ユーザーを取得します。
		/// </summary>
		/// <param name="userID">取得するユーザーのID</param>
		/// <returns>取得したユーザー</returns>
		public async Task<User> GetUser(Int64 userID)
		{
			return await
				API.Rest.UsersShow(this, user_id: userID);
		}

		/// <summary>
		/// ユーザーを取得します。
		/// </summary>
		/// <param name="screenName">取得するユーザーのScreenName</param>
		/// <returns>取得したユーザー</returns>
		public async Task<User> GetUser(string screenName)
		{
			return await
				API.Rest.UsersShow(this, screen_name: screenName);
		}

		#endregion

		#region ReportSpam

		/// <summary>
		/// 対象のアカウントをスパムとして報告します。
		/// </summary>
		/// <param name="userID">対象のユーザーのID</param>
		/// <returns>スパム報告されたユーザー</returns>
		public async Task<User> ReportSpam(Int64 userID)
		{
			return await
				API.Rest.UsersReportSpam(this, user_id: userID);
		}

		/// <summary>
		/// 対象のアカウントをスパムとして報告します。
		/// </summary>
		/// <param name="screenName">対象のScreenName</param>
		/// <returns>スパム報告されたユーザー</returns>
		public async Task<User> ReportSpam(string screenName)
		{
			return await
				API.Rest.UsersReportSpam(this, screen_name: screenName);
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

		#region AddListMember

		/// <summary>
		/// ユーザーをリストに追加します。
		/// </summary>
		/// <param name="listID">リストのID</param>
		/// <param name="userID">リストに追加するユーザーのID</param>
		public async void AddListMember(Int64 listID, Int64 userID)
		{
			API.Rest.ListsMembersCreate(this, list_id: listID, user_id: userID);
		}

		/// <summary>
		/// ユーザーをリストに追加します。
		/// </summary>
		/// <param name="listID">リストのID</param>
		/// <param name="screenName">リストに追加するユーザーのScreenName</param>
		public async void AddListMember(Int64 listID, string screenName)
		{
			API.Rest.ListsMembersCreate(this, list_id: listID, screen_name: screenName);
		}

		/// <summary>
		/// ユーザーをリストに追加します。
		/// </summary>
		/// <param name="slug">リストのスラグ</param>
		/// <param name="ownerID">リスト作成者のID</param>
		/// <param name="userID">リストに追加するユーザーのID</param>
		public async void AddListMember(string slug, Int64 ownerID, Int64 userID)
		{
			API.Rest.ListsMembersCreate(this, slug: slug, owner_id: ownerID, user_id: userID);
		}

		/// <summary>
		/// ユーザーをリストに追加します。
		/// </summary>
		/// <param name="slug">リストのスラグ</param>
		/// <param name="ownerID">リスト作成者のID</param>
		/// <param name="screenName">リストに追加するユーザーのScreenName</param>
		public async void AddListMember(string slug, Int64 ownerID, string screenName)
		{
			API.Rest.ListsMembersCreate(this, slug: slug, owner_id: ownerID, screen_name: screenName);
		}

		/// <summary>
		/// ユーザーをリストに追加します。
		/// </summary>
		/// <param name="slug">リストのスラグ</param>
		/// <param name="ownerScreenName">リスト作成者のScreenName</param>
		/// <param name="userID">リストに追加するユーザーのID</param>
		public async void AddListMember(string slug, string ownerScreenName, Int64 userID)
		{
			API.Rest.ListsMembersCreate(this, slug: slug, owner_screen_name: ownerScreenName, user_id: userID);
		}

		/// <summary>
		/// ユーザーをリストに追加します。
		/// </summary>
		/// <param name="slug">リストのスラグ</param>
		/// <param name="ownerScreenName">リスト作成者のScreenName</param>
		/// <param name="screenName">リストに追加するユーザーのScreenName</param>
		public async void AddListMember(string slug, string ownerScreenName, string screenName)
		{
			API.Rest.ListsMembersCreate(this, slug: slug, owner_screen_name: ownerScreenName, screen_name: screenName);
		}

		#endregion

		#region RemoveListMember

		/// <summary>
		/// ユーザーをリストから削除します。
		/// </summary>
		/// <param name="listID">リストのID</param>
		/// <param name="userID">リストから削除するユーザーのID</param>
		public async void RemoveListMember(Int64 listID, Int64 userID)
		{
			API.Rest.ListsMembersDestroy(this, list_id: listID, user_id: userID);
		}

		/// <summary>
		/// ユーザーをリストから削除します。
		/// </summary>
		/// <param name="listID">リストのID</param>
		/// <param name="screenName">リストから削除するユーザーのScreenName</param>
		public async void RemoveListMember(Int64 listID, string screenName)
		{
			API.Rest.ListsMembersDestroy(this, list_id: listID, screen_name: screenName);
		}

		/// <summary>
		/// ユーザーをリストから削除します。
		/// </summary>
		/// <param name="slug">リストのスラグ</param>
		/// <param name="ownerID">リスト作成者のID</param>
		/// <param name="userID">リストから削除するユーザーのID</param>
		public async void RemoveListMember(string slug, Int64 ownerID, Int64 userID)
		{
			API.Rest.ListsMembersDestroy(this, slug: slug, owner_id: ownerID, user_id: userID);
		}

		/// <summary>
		/// ユーザーをリストから削除します。
		/// </summary>
		/// <param name="slug">リストのスラグ</param>
		/// <param name="ownerID">リスト作成者のID</param>
		/// <param name="screenName">リストから削除するユーザーのScreenName</param>
		public async void RemoveListMember(string slug, Int64 ownerID, string screenName)
		{
			API.Rest.ListsMembersDestroy(this, slug: slug, owner_id: ownerID, screen_name: screenName);
		}

		/// <summary>
		/// ユーザーをリストから削除します。
		/// </summary>
		/// <param name="slug">リストのスラグ</param>
		/// <param name="ownerScreenName">リスト作成者のScreenName</param>
		/// <param name="userID">リストから削除するユーザーのID</param>
		public async void RemoveListMember(string slug, string ownerScreenName, Int64 userID)
		{
			API.Rest.ListsMembersDestroy(this, slug: slug, owner_screen_name: ownerScreenName, user_id: userID);
		}

		/// <summary>
		/// ユーザーをリストから削除します。
		/// </summary>
		/// <param name="slug">リストのスラグ</param>
		/// <param name="ownerScreenName">リスト作成者のScreenName</param>
		/// <param name="screenName">リストから削除するユーザーのScreenName</param>
		public async void RemoveListMember(string slug, string ownerScreenName, string screenName)
		{
			API.Rest.ListsMembersDestroy(this, slug: slug, owner_screen_name: ownerScreenName, screen_name: screenName);
		}

		#endregion

		#region Mute

		/// <summary>
		/// ユーザーをミュートします。
		/// </summary>
		/// <param name="id">ミュートするユーザーのID</param>
		/// <returns>ミュートされたユーザー</returns>
		public async Task<User> Mute(Int64 id)
		{
			return await
				API.Rest.MutesUsersCreate(this, id: id);
		}

		/// <summary>
		/// ユーザーをミュートします。
		/// </summary>
		/// <param name="screenName">ミュートを解除するユーザーのScreenName</param>
		/// <returns>ミュートされたユーザー</returns>
		public async Task<User> Mute(string screenName)
		{
			return await
				API.Rest.MutesUsersCreate(this, screen_name: screenName);
		}

		/// <summary>
		/// ユーザーをミュートします。
		/// </summary>
		/// <param name="user">ミュートを解除するユーザー</param>
		/// <returns>ミュートされたユーザー</returns>
		public async Task<User> Mute(User user)
		{
			return await
				API.Rest.MutesUsersCreate(this, id: user.ID);
		}

		#endregion

		#region UnMute

		/// <summary>
		/// ユーザーのミュートを解除します。
		/// </summary>
		/// <param name="id">ミュートを解除するユーザーのID</param>
		/// <returns>ミュートを解除されたユーザー</returns>
		public async Task<User> UnMute(Int64 id)
		{
			return await
				API.Rest.MutesUsersDestroy(this, id: id);
		}

		/// <summary>
		/// ユーザーのミュートを解除します。
		/// </summary>
		/// <param name="screenName">ミュートを解除するユーザーのScreenName</param>
		/// <returns>ミュートを解除されたユーザー</returns>
		public async Task<User> UnMute(string screenName)
		{
			return await
				API.Rest.MutesUsersDestroy(this, screen_name: screenName);
		}

		/// <summary>
		/// ユーザーのミュートを解除します。
		/// </summary>
		/// <param name="user">ミュートを解除するユーザー</param>
		/// <returns>ミュートを解除されたユーザー</returns>
		public async Task<User> UnMute(User user)
		{
			return await
				API.Rest.MutesUsersDestroy(this, id: user.ID);
		}

		#endregion

		#region  OAuthAuthorize

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public async Task<string> OAuthAuthorize()
		{
			return await
				API.Rest.OauthAuthorize(this);
		}

		#endregion

		#region OAuthGetAccessToken

		/// <summary>
		/// OAuth認証におけるアクセス トークンを取得します。
		/// </summary>
		/// <param name="oauthVerifier"></param>
		/// <returns>アクセス トークン</returns>
		public async Task<string> OAuthGetAccessToken(string oauthVerifier)
		{
			return await
				API.Rest.OauthAccessToken(this, oauthVerifier);
		}

		/// <summary>
		/// OAuth認証におけるアクセス トークンを取得します。
		/// </summary>
		/// <param name="xAuthUsername">認証するユーザーのユーザー名</param>
		/// <param name="xAuthPassword">認証するユーザーのパスワード</param>
		/// <returns>アクセス トークン</returns>
		public async Task<string> OAuthGetAccessToken(
			string xAuthUsername, string xAuthPassword)
		{
			return await
				API.Rest.OauthAccessToken(this, xAuthUsername, xAuthPassword);
		}

		#endregion

		#region OAuthGetRequestToken

		/// <summary>
		/// OAuth認証におけるリクエスト トークンを取得します。
		/// </summary>
		/// <returns>リクエスト トークン</returns>
		public async Task<string> OAuthGetRequestToken()
		{
			return await
				API.Rest.OauthRequestToken(this);
		}

		#endregion
	}
}
