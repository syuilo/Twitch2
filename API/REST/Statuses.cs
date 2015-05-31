using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading.Tasks;
using Twitch.Entity;

namespace Twitch.API
{
	public partial class Rest
	{
		public static async Task<List<Status>> StatusesHomeTimeline(
			Twitter twitter,
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

			var query = new Dictionary<string, string>();
			query["count"] = count.ToString();
			query["since_id"] = since_id.ToString();
			query["max_id"] = max_id.ToString();
			query["trim_user"] = trim_user.ToString();
			query["exclude_replies"] = exclude_replies.ToString();
			query["contributor_details"] = contributor_details.ToString();
			query["include_entities"] = include_entities.ToString();

			string source = await twitter.Request(API.Method.GET, new Uri(API.Urls.Statuses_HomeTimeline), query);

			dynamic json = Utility.DynamicJson.Parse(source);

			var statuses = new List<Status>();
			foreach (dynamic status in json)
			{
				statuses.Add(new Status(status.ToString()));
			}
			return statuses;
		}

		public static async Task<List<Status>> StatusesUserTimeline(
			Twitter twitter,
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

			var query = new Dictionary<string, string>();
			if (user_id != string.Empty)
				query["user_id"] = user_id;
			else if (screen_name != string.Empty)
				query["screen_name"] = screen_name;
			query["count"] = count.ToString();
			query["since_id"] = since_id.ToString();
			query["max_id"] = max_id.ToString();
			query["trim_user"] = trim_user.ToString();
			query["exclude_replies"] = exclude_replies.ToString();
			query["contributor_details"] = contributor_details.ToString();
			query["include_rts"] = include_rts.ToString();

			string source = await twitter.Request(API.Method.GET, new Uri(API.Urls.Statuses_UserTimeline), query);

			dynamic json = Utility.DynamicJson.Parse(source);

			var statuses = new List<Status>();
			foreach (dynamic status in json)
			{
				statuses.Add(new Status(status.ToString()));
			}
			return statuses;
		}

		public static async Task<List<Status>> StatusesMentionsTimeline(
			Twitter twitter,
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

			var query = new Dictionary<string, string>();
			query["count"] = count.ToString();
			query["since_id"] = since_id.ToString();
			query["max_id"] = max_id.ToString();
			query["trim_user"] = trim_user.ToString();
			query["contributor_details"] = contributor_details.ToString();
			query["include_entities"] = include_entities.ToString();

			string source = await twitter.Request(API.Method.GET, new Uri(API.Urls.Statuses_MentionsTimeline), query);

			dynamic json = Utility.DynamicJson.Parse(source);

			var statuses = new List<Status>();
			foreach (dynamic status in json)
			{
				statuses.Add(new Status(status.ToString()));
			}
			return statuses;
		}

		public static async Task<Status> StatusesUpdate(
			Twitter twitter,
			string status,
			Int64? in_reply_to_status_id = null)
		{
			var query = new Dictionary<string, string>();
			query["status"] = status;
			query["in_reply_to_status_id"] = in_reply_to_status_id.ToString();

			return new Status(
				await twitter.Request(API.Method.POST, new Uri(API.Urls.Statuses_Update), query));
		}

		public static async Task<Status> StatusesRetweet(
			Twitter twitter, 
			Int64 id)
		{
			var query = new Dictionary<string, string>();
			query["id"] = id.ToString();

			return new Status(
				await twitter.Request(API.Method.POST, new Uri(API.Urls.Statuses_Retweet + id + ".json"), query));
		}

		public static async Task<Status> StatusesShow(
			Twitter twitter, 
			Int64 id)
		{
			var query = new Dictionary<string, string>();
			query["id"] = id.ToString();

			return new Status(
				await twitter.Request(API.Method.GET, new Uri(API.Urls.Statuses_Show), query));
		}
	}
}
