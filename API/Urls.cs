namespace Twitch.API
{
	public static class Urls
	{
		#region Statuses
		public const string Statuses_MentionsTimeline = "https://api.twitter.com/1.1/statuses/mentions_timeline.json";
		public const string Statuses_UserTimeline = "https://api.twitter.com/1.1/statuses/user_timeline.json";
		public const string Statuses_HomeTimeline = "https://api.twitter.com/1.1/statuses/home_timeline.json";
		public const string Statuses_RetweetsOfMe = "https://api.twitter.com/1.1/statuses/retweets_of_me.json";
		public const string Statuses_Retweets = "https://api.twitter.com/1.1/statuses/retweets/";
		public const string Statuses_Show = "https://api.twitter.com/1.1/statuses/show.json";
		public const string Statuses_Destroy = "https://api.twitter.com/1.1/statuses/destroy/";
		public const string Statuses_Update = "https://api.twitter.com/1.1/statuses/update.json";
		public const string Statuses_Retweet = "https://api.twitter.com/1.1/statuses/retweet/";
		public const string Statuses_UpdateWithMedia = "https://api.twitter.com/1.1/statuses/update_with_media.json";
		public const string Statuses_Oembed = "https://api.twitter.com/1.1/statuses/oembed.json";
		public const string Statuses_Retweeters_Ids = "https://api.twitter.com/1.1/statuses/retweeters/ids.json";
		public const string Statuses_Lookup = "https://api.twitter.com/1.1/statuses/lookup.json";
		#endregion

		#region Search
		public const string Search_Tweets = "https://api.twitter.com/1.1/search/tweets.json";
		#endregion

		#region Account
		public const string Account_Settings = "https://api.twitter.com/1.1/account/settings.json";
		public const string Account_VerifyCredentials = "https://api.twitter.com/1.1/account/verify_credentials.json";
		public const string Account_UpdateDeliveryDevice = "https://api.twitter.com/1.1/account/update_delivery_device.json";
		public const string Account_UpdateProfile = "https://api.twitter.com/1.1/account/update_profile.json";
		public const string Account_UpdateProfileBackgroundImage = "https://api.twitter.com/1.1/account/update_profile_background_image.json";
		public const string Account_UpdateProfileColors = "https://api.twitter.com/1.1/account/update_profile_colors.json";
		public const string Account_UpdateProfileImage = "https://api.twitter.com/1.1/account/update_profile_image.json";
		public const string Account_RemoveProfileBanner = "https://api.twitter.com/1.1/account/remove_profile_banner.json";
		public const string Account_UpdateProfileBanner = "https://api.twitter.com/1.1/account/update_profile_banner.json";
		#endregion

		#region Blocks
		public const string Blocks_List = "https://api.twitter.com/1.1/blocks/list.json";
		public const string Blocks_Ids = "https://api.twitter.com/1.1/blocks/ids.json";
		public const string Blocks_Create = "https://api.twitter.com/1.1/blocks/create.json";
		public const string Blocks_Destroy = "https://api.twitter.com/1.1/blocks/destroy.json";
		#endregion

		#region Users
		public const string Users_Lookup = "https://api.twitter.com/1.1/users/lookup.json";
		public const string Users_Show = "https://api.twitter.com/1.1/users/show.json";
		public const string Users_Search = "https://api.twitter.com/1.1/users/search.json";
		public const string Users_Contributees = "https://api.twitter.com/1.1/users/contributees.json";
		public const string Users_Contributors = "https://api.twitter.com/1.1/users/contributors.json";
		public const string Users_ProfileBanner = "https://api.twitter.com/1.1/users/profile_banner.json";
		public const string Users_ReportSpam = "https://api.twitter.com/1.1/users/report_spam.json";
		#endregion

		#region Mutes
		public const string Mutes_Users_Create = "https://api.twitter.com/1.1/mutes/users/create.json";
		public const string Mutes_Users_Destroy = "https://api.twitter.com/1.1/mutes/users/destroy.json";
		public const string Mutes_Users_Ids = "https://api.twitter.com/1.1/mutes/users/ids.json";
		public const string Mutes_Users_List = "https://api.twitter.com/1.1/mutes/users/list.json";
		#endregion

		#region Favorites
		public const string Favorites_List = "https://api.twitter.com/1.1/favorites/list.json";
		public const string Favorites_Destroy = "https://api.twitter.com/1.1/favorites/destroy.json";
		public const string Favorites_Create = "https://api.twitter.com/1.1/favorites/create.json";
		#endregion

		#region Friends
		public const string Friends_Ids = "https://api.twitter.com/1.1/friends/ids.json";
		public const string Friends_IList = "https://api.twitter.com/1.1/friends/list.json";
		#endregion

		#region Friendships
		public const string Friendships_NoRetweets_Ids = "https://api.twitter.com/1.1/friendships/no_retweets/ids.json";
		public const string Friendships_Incoming = "https://api.twitter.com/1.1/friendships/incoming.json";
		public const string Friendships_Outgoing = "https://api.twitter.com/1.1/friendships/outgoing.format";
		public const string Friendships_Create = "https://api.twitter.com/1.1/friendships/create.json";
		public const string Friendships_Destroy = "https://api.twitter.com/1.1/friendships/destroy.json";
		public const string Friendships_Update = "https://api.twitter.com/1.1/friendships/update.json";
		public const string Friendships_Show = "https://api.twitter.com/1.1/friendships/show.json";
		#endregion

		#region Followers
		public const string Followers_Ids = "https://api.twitter.com/1.1/followers/ids.json";
		public const string Followers_List = "https://api.twitter.com/1.1/followers/list.json";
		#endregion

		#region DirectMessages
		public const string DirectMessages = "https://api.twitter.com/1.1/direct_messages.json";
		public const string DirectMessages_Sent = "https://api.twitter.com/1.1/direct_messages/sent.json";
		public const string DirectMessages_Show = "https://api.twitter.com/1.1/direct_messages/show.json";
		public const string DirectMessages_Destroy = "https://api.twitter.com/1.1/direct_messages/destroy.json";
		public const string DirectMessages_New = "https://api.twitter.com/1.1/direct_messages/new.json";
		#endregion

		#region Lists
		public const string Lists_List = "https://api.twitter.com/1.1/lists/list.json";
		public const string Lists_Statuses = "https://api.twitter.com/1.1/lists/statuses.json";
		public const string Lists_Members_Destroy = "https://api.twitter.com/1.1/lists/members/destroy.json";
		public const string Lists_Memberships = "https://api.twitter.com/1.1/lists/memberships.json";
		public const string Lists_Subscribers = "https://api.twitter.com/1.1/lists/subscribers.json";
		public const string Lists_Subscribers_Create = "https://api.twitter.com/1.1/lists/subscribers/create.json";
		public const string Lists_Subscribers_Show = "https://api.twitter.com/1.1/lists/subscribers/show.json";
		public const string Lists_Subscribers_Destroy = "https://api.twitter.com/1.1/lists/subscribers/destroy.json";
		public const string Lists_Members_CreateAll = "https://api.twitter.com/1.1/lists/members/create_all.json";
		public const string Lists_Members_Show = "https://api.twitter.com/1.1/lists/members/show.json";
		public const string Lists_Members = "https://api.twitter.com/1.1/lists/members.json";
		public const string Lists_Members_Create = "https://api.twitter.com/1.1/lists/members/create.json";
		public const string Lists_Destroy = "https://api.twitter.com/1.1/lists/destroy.json";
		public const string Lists_Update = "https://api.twitter.com/1.1/lists/update.json";
		public const string Lists_Create = "https://api.twitter.com/1.1/lists/create.json";
		public const string Lists_Show = "https://api.twitter.com/1.1/lists/show.json";
		public const string Lists_Subscriptions = "https://api.twitter.com/1.1/lists/subscriptions.json";
		public const string Lists_Members_DestroyAll = "https://api.twitter.com/1.1/lists/members/destroy_all.json";
		public const string Lists_Ownerships = "https://api.twitter.com/1.1/lists/ownerships.json";
		#endregion

		#region SavedSearches
		public const string SavedSearches_List = "https://api.twitter.com/1.1/saved_searches/list.json";
		public const string SavedSearches_Show = "https://api.twitter.com/1.1/saved_searches/show/";
		public const string SavedSearches_Create = "https://api.twitter.com/1.1/saved_searches/create.json";
		public const string SavedSearches_Destroy = "https://api.twitter.com/1.1/saved_searches/destroy/";
		#endregion

		#region Geo
		public const string Geo_Id = "https://api.twitter.com/1.1/geo/id/";
		public const string Geo_ReverseGeocode = "https://api.twitter.com/1.1/geo/reverse_geocode.json";
		public const string Geo_Search = "https://api.twitter.com/1.1/geo/search.json";
		public const string Geo_SimilarPlaces = "https://api.twitter.com/1.1/geo/similar_places.json";
		public const string Geo_Place = "https://api.twitter.com/1.1/geo/place.json";
		#endregion

		#region Trends
		public const string Trends_Place = "https://api.twitter.com/1.1/trends/place.json";
		public const string Trends_Available = "https://api.twitter.com/1.1/trends/available.json";
		public const string Trends_Closest = "https://api.twitter.com/1.1/trends/closest.json";
		#endregion

		#region Oauth
		public const string Oauth_Authenticate = "https://api.twitter.com/oauth/authenticate";
		public const string Oauth_Authorize = "https://api.twitter.com/oauth/authorize";
		public const string Oauth_AccessToken = "https://api.twitter.com/oauth/access_token";
		public const string Oauth_RequestToken = "https://api.twitter.com/oauth/request_token";
		#endregion

		#region Oauth2
		public const string Oauth2_Token = "https://api.twitter.com/oauth2/token";
		public const string Oauth2_InvalidateToken = "https://api.twitter.com/oauth2/invalidate_token";
		#endregion

		#region Help
		public const string Help_Configuration = "https://api.twitter.com/1.1/help/configuration.json";
		public const string Help_Languages = "https://api.twitter.com/1.1/help/languages.json";
		public const string Help_Privacy = "https://api.twitter.com/1.1/help/privacy.json";
		public const string Help_Tos = "https://api.twitter.com/1.1/help/tos.json";
		#endregion

		#region Application
		public const string Application_RateLimitStatus = "https://api.twitter.com/1.1/application/rate_limit_status.json";
		#endregion
	}
}
