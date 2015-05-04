namespace Twitch.API
{
	internal static class Urls
	{
		#region Statuses
		internal const string Statuses_MentionsTimeline = "https://api.twitter.com/1.1/statuses/mentions_timeline.json";
		internal const string Statuses_UserTimeline = "https://api.twitter.com/1.1/statuses/user_timeline.json";
		internal const string Statuses_HomeTimeline = "https://api.twitter.com/1.1/statuses/home_timeline.json";
		internal const string Statuses_RetweetsOfMe = "https://api.twitter.com/1.1/statuses/retweets_of_me.json";
		internal const string Statuses_Retweets = "https://api.twitter.com/1.1/statuses/retweets/";
		internal const string Statuses_Show = "https://api.twitter.com/1.1/statuses/show.json";
		internal const string Statuses_Destroy = "https://api.twitter.com/1.1/statuses/destroy/";
		internal const string Statuses_Update = "https://api.twitter.com/1.1/statuses/update.json";
		internal const string Statuses_Retweet = "https://api.twitter.com/1.1/statuses/retweet/";
		internal const string Statuses_UpdateWithMedia = "https://api.twitter.com/1.1/statuses/update_with_media.json";
		internal const string Statuses_Oembed = "https://api.twitter.com/1.1/statuses/oembed.json";
		internal const string Statuses_Retweeters_Ids = "https://api.twitter.com/1.1/statuses/retweeters/ids.json";
		internal const string Statuses_Lookup = "https://api.twitter.com/1.1/statuses/lookup.json";
		#endregion

		#region Search
		internal const string Search_Tweets = "https://api.twitter.com/1.1/search/tweets.json";
		#endregion

		#region Account
		internal const string Account_Settings = "https://api.twitter.com/1.1/account/settings.json";
		internal const string Account_VerifyCredentials = "https://api.twitter.com/1.1/account/verify_credentials.json";
		internal const string Account_UpdateDeliveryDevice = "https://api.twitter.com/1.1/account/update_delivery_device.json";
		internal const string Account_UpdateProfile = "https://api.twitter.com/1.1/account/update_profile.json";
		internal const string Account_UpdateProfileBackgroundImage = "https://api.twitter.com/1.1/account/update_profile_background_image.json";
		internal const string Account_UpdateProfileColors = "https://api.twitter.com/1.1/account/update_profile_colors.json";
		internal const string Account_UpdateProfileImage = "https://api.twitter.com/1.1/account/update_profile_image.json";
		internal const string Account_RemoveProfileBanner = "https://api.twitter.com/1.1/account/remove_profile_banner.json";
		internal const string Account_UpdateProfileBanner = "https://api.twitter.com/1.1/account/update_profile_banner.json";
		#endregion

		#region Blocks
		internal const string Blocks_List = "https://api.twitter.com/1.1/blocks/list.json";
		internal const string Blocks_Ids = "https://api.twitter.com/1.1/blocks/ids.json";
		internal const string Blocks_Create = "https://api.twitter.com/1.1/blocks/create.json";
		internal const string Blocks_Destroy = "https://api.twitter.com/1.1/blocks/destroy.json";
		#endregion

		#region Users
		internal const string Users_Lookup = "https://api.twitter.com/1.1/users/lookup.json";
		internal const string Users_Show = "https://api.twitter.com/1.1/users/show.json";
		internal const string Users_Search = "https://api.twitter.com/1.1/users/search.json";
		internal const string Users_Contributees = "https://api.twitter.com/1.1/users/contributees.json";
		internal const string Users_Contributors = "https://api.twitter.com/1.1/users/contributors.json";
		internal const string Users_ProfileBanner = "https://api.twitter.com/1.1/users/profile_banner.json";
		internal const string Users_ReportSpam = "https://api.twitter.com/1.1/users/report_spam.json";
		#endregion

		#region Mutes
		internal const string Mutes_Users_Create = "https://api.twitter.com/1.1/mutes/users/create.json";
		internal const string Mutes_Users_Destroy = "https://api.twitter.com/1.1/mutes/users/destroy.json";
		internal const string Mutes_Users_Ids = "https://api.twitter.com/1.1/mutes/users/ids.json";
		internal const string Mutes_Users_List = "https://api.twitter.com/1.1/mutes/users/list.json";
		#endregion

		#region Favorites
		internal const string Favorites_List = "https://api.twitter.com/1.1/favorites/list.json";
		internal const string Favorites_Destroy = "https://api.twitter.com/1.1/favorites/destroy.json";
		internal const string Favorites_Create = "https://api.twitter.com/1.1/favorites/create.json";
		#endregion

		#region Friends
		internal const string Friends_Ids = "https://api.twitter.com/1.1/friends/ids.json";
		internal const string Friends_IList = "https://api.twitter.com/1.1/friends/list.json";
		#endregion

		#region Friendships
		internal const string Friendships_NoRetweets_Ids = "https://api.twitter.com/1.1/friendships/no_retweets/ids.json";
		internal const string Friendships_Incoming = "https://api.twitter.com/1.1/friendships/incoming.json";
		internal const string Friendships_Outgoing = "https://api.twitter.com/1.1/friendships/outgoing.format";
		internal const string Friendships_Create = "https://api.twitter.com/1.1/friendships/create.json";
		internal const string Friendships_Destroy = "https://api.twitter.com/1.1/friendships/destroy.json";
		internal const string Friendships_Update = "https://api.twitter.com/1.1/friendships/update.json";
		internal const string Friendships_Show = "https://api.twitter.com/1.1/friendships/show.json";
		#endregion

		#region Followers
		internal const string Followers_Ids = "https://api.twitter.com/1.1/followers/ids.json";
		internal const string Followers_List = "https://api.twitter.com/1.1/followers/list.json";
		#endregion

		#region DirectMessages
		internal const string DirectMessages = "https://api.twitter.com/1.1/direct_messages.json";
		internal const string DirectMessages_Sent = "https://api.twitter.com/1.1/direct_messages/sent.json";
		internal const string DirectMessages_Show = "https://api.twitter.com/1.1/direct_messages/show.json";
		internal const string DirectMessages_Destroy = "https://api.twitter.com/1.1/direct_messages/destroy.json";
		internal const string DirectMessages_New = "https://api.twitter.com/1.1/direct_messages/new.json";
		#endregion

		#region Lists
		internal const string Lists_List = "https://api.twitter.com/1.1/lists/list.json";
		internal const string Lists_Statuses = "https://api.twitter.com/1.1/lists/statuses.json";
		internal const string Lists_Members_Destroy = "https://api.twitter.com/1.1/lists/members/destroy.json";
		internal const string Lists_Memberships = "https://api.twitter.com/1.1/lists/memberships.json";
		internal const string Lists_Subscribers = "https://api.twitter.com/1.1/lists/subscribers.json";
		internal const string Lists_Subscribers_Create = "https://api.twitter.com/1.1/lists/subscribers/create.json";
		internal const string Lists_Subscribers_Show = "https://api.twitter.com/1.1/lists/subscribers/show.json";
		internal const string Lists_Subscribers_Destroy = "https://api.twitter.com/1.1/lists/subscribers/destroy.json";
		internal const string Lists_Members_CreateAll = "https://api.twitter.com/1.1/lists/members/create_all.json";
		internal const string Lists_Members_Show = "https://api.twitter.com/1.1/lists/members/show.json";
		internal const string Lists_Members = "https://api.twitter.com/1.1/lists/members.json";
		internal const string Lists_Members_Create = "https://api.twitter.com/1.1/lists/members/create.json";
		internal const string Lists_Destroy = "https://api.twitter.com/1.1/lists/destroy.json";
		internal const string Lists_Update = "https://api.twitter.com/1.1/lists/update.json";
		internal const string Lists_Create = "https://api.twitter.com/1.1/lists/create.json";
		internal const string Lists_Show = "https://api.twitter.com/1.1/lists/show.json";
		internal const string Lists_Subscriptions = "https://api.twitter.com/1.1/lists/subscriptions.json";
		internal const string Lists_Members_DestroyAll = "https://api.twitter.com/1.1/lists/members/destroy_all.json";
		internal const string Lists_Ownerships = "https://api.twitter.com/1.1/lists/ownerships.json";
		#endregion

		#region SavedSearches
		internal const string SavedSearches_List = "https://api.twitter.com/1.1/saved_searches/list.json";
		internal const string SavedSearches_Show = "https://api.twitter.com/1.1/saved_searches/show/";
		internal const string SavedSearches_Create = "https://api.twitter.com/1.1/saved_searches/create.json";
		internal const string SavedSearches_Destroy = "https://api.twitter.com/1.1/saved_searches/destroy/";
		#endregion

		#region Geo
		internal const string Geo_Id = "https://api.twitter.com/1.1/geo/id/";
		internal const string Geo_ReverseGeocode = "https://api.twitter.com/1.1/geo/reverse_geocode.json";
		internal const string Geo_Search = "https://api.twitter.com/1.1/geo/search.json";
		internal const string Geo_SimilarPlaces = "https://api.twitter.com/1.1/geo/similar_places.json";
		internal const string Geo_Place = "https://api.twitter.com/1.1/geo/place.json";
		#endregion

		#region Trends
		internal const string Trends_Place = "https://api.twitter.com/1.1/trends/place.json";
		internal const string Trends_Available = "https://api.twitter.com/1.1/trends/available.json";
		internal const string Trends_Closest = "https://api.twitter.com/1.1/trends/closest.json";
		#endregion

		#region Oauth
		internal const string Oauth_Authenticate = "https://api.twitter.com/oauth/authenticate";
		internal const string Oauth_Authorize = "https://api.twitter.com/oauth/authorize";
		internal const string Oauth_AccessToken = "https://api.twitter.com/oauth/access_token";
		internal const string Oauth_RequestToken = "https://api.twitter.com/oauth/request_token";
		#endregion

		#region Oauth2
		internal const string Oauth2_Token = "https://api.twitter.com/oauth2/token";
		internal const string Oauth2_InvalidateToken = "https://api.twitter.com/oauth2/invalidate_token";
		#endregion

		#region Help
		internal const string Help_Configuration = "https://api.twitter.com/1.1/help/configuration.json";
		internal const string Help_Languages = "https://api.twitter.com/1.1/help/languages.json";
		internal const string Help_Privacy = "https://api.twitter.com/1.1/help/privacy.json";
		internal const string Help_Tos = "https://api.twitter.com/1.1/help/tos.json";
		#endregion

		#region Application
		internal const string Application_RateLimitStatus = "https://api.twitter.com/1.1/application/rate_limit_status.json";
		#endregion
	}
}
