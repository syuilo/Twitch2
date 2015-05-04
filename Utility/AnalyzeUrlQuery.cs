namespace Twitch.Utility
{
	public static class AnalyzeUrlQuery
	{
		public static string Analyze(string query, string target)
		{
			string value = null;

			for (int i = (query.IndexOf(target) + target.Length + 1); i < query.Length; i++)
			{
				if (query[i] == '&')
					break;

				value += query[i];
			}

			return value;
		}
	}
}
