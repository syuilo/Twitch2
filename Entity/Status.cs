﻿using System;
using System.Threading.Tasks;

namespace Twitch.Entity
{
	/// <summary>
	/// ツイートを格納するツイート オブジェクトです。
	/// </summary>
	[Serializable]
	public class Status : Response.Tweets.Status
	{
		public Status()
			: base() { }

		public Status(string source)
			: base(source) { }
	}
}
