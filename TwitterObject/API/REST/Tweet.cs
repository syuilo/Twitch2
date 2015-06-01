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
			double count = 0,
			Int64? since_id = null,
			Int64? max_id = null,
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
			string user_id = null,
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
	}
}
