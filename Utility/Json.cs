using System;
using System.Collections.Generic;

namespace Twitch.Utility
{
	/// <summary>
	/// Json is a JSON parse libraly.
	/// </summary>
	public static class Json
	{
		public static Dictionary<string, object> Deserialize(string source)
		{
			return new Analyzer(source).Parse();
		}

		private class Analyzer
		{
			private int Cursor
			{
				get;
				set;
			}

			private string Source
			{
				get;
				set;
			}

			private enum TokenType
			{
				/// <summary>
				/// {
				/// </summary>
				OpenCurlyBracket,

				/// <summary>
				/// }
				/// </summary>
				CloseCurlyBracket,

				/// <summary>
				/// [
				/// </summary>
				OpenSquareBracket,

				/// <summary>
				/// ]
				/// </summary>
				CloseSquareBracket,

				/// <summary>
				/// "
				/// </summary>
				DoubleQuote,

				/// <summary>
				/// :
				/// </summary>
				Colon,

				/// <summary>
				/// ,
				/// </summary>
				Comma,

				/// <summary>
				/// 0-9
				/// </summary>
				Number,

				/// <summary>
				/// \
				/// </summary>
				Escape,

				PrettyToken,

				Unknown
			}

			private TokenType GetTokenType(Char c)
			{
				switch (c)
				{
					case '\\':
						return TokenType.Escape;
					case ' ':
					case '\t':
					case '\r':
					case '\n':
						return TokenType.PrettyToken;
					case '{':
						return TokenType.OpenCurlyBracket;
					case '}':
						return TokenType.CloseCurlyBracket;
					case '[':
						return TokenType.OpenSquareBracket;
					case ']':
						return TokenType.CloseSquareBracket;
					case '"':
						return TokenType.DoubleQuote;
					case ':':
						return TokenType.Colon;
					case ',':
						return TokenType.Comma;
					case '0':
					case '1':
					case '2':
					case '3':
					case '4':
					case '5':
					case '6':
					case '7':
					case '8':
					case '9':
						return TokenType.Number;
					default:
						return TokenType.Unknown;
				}
			}

			private Char Read(int pos = 0)
			{
				Console.Write(this.Source[this.Cursor + pos]);
				return this.Source[this.Cursor + pos];
			}

			private Char ReadAndNext()
			{
				var c = this.Read();
				this.Next();
				return c;
			}

			private void Next()
			{
				this.Cursor++;
			}

			private void Back()
			{
				this.Cursor--;
			}

			public Analyzer(string source)
			{
				this.Cursor = 0;
				this.Source = source.Trim();
			}

			public Dictionary<string, object> Parse()
			{
				if (String.IsNullOrEmpty(this.Source))
					throw new FormatException("データソースが空です。");

				var obj = new Dictionary<string, object>();

				switch (this.GetTokenType(this.ReadAndNext()))
				{
					case TokenType.OpenCurlyBracket:
						obj = this.AnalyzeObject();
						break;
					default:
						throw new FormatException("Invalid format.");
				}

				return obj;
			}

			private Dictionary<string, object> AnalyzeObject()
			{
				var obj = new Dictionary<string, object>();

				for (; this.Cursor < this.Source.Length; )
				{
					var key = String.Empty;

					for (; this.Cursor < this.Source.Length; )
					{
						switch (this.GetTokenType(this.ReadAndNext()))
						{
							case TokenType.DoubleQuote:
								key = this.AnalyzeKey();
								goto GetValue;
							case TokenType.CloseCurlyBracket:
								return obj;
							case TokenType.PrettyToken:
							case TokenType.Comma:
								break;
							default:
								throw new FormatException("Invalid format.");
						}
					}

				GetValue:

					var value = new Func<object>(() =>
					{
						for (; this.Cursor < this.Source.Length; )
						{
							switch (this.GetTokenType(this.ReadAndNext()))
							{
								// Object
								case TokenType.OpenCurlyBracket:
									return this.AnalyzeObject();
								// Array
								case TokenType.OpenSquareBracket:
									return this.AnalyzeArray();
								// String
								case TokenType.DoubleQuote:
									return this.AnalyzeString();
								// Number
								case TokenType.Number:
									return this.AnalyzeNumber();

								case TokenType.PrettyToken:
								case TokenType.Colon:
									break;
								default:
									throw new FormatException("Invalid format.");
							}
						}

						throw new FormatException("キーに対応する値に出会う前にソースが終了しました。");
					})();

					obj.Add(key, value);
				}

				throw new FormatException("オブジェクトが終了していません。");
			}

			private List<object> AnalyzeArray()
			{
				var array = new List<object>();

				for (; this.Cursor < this.Source.Length; )
				{
					switch (this.GetTokenType(this.ReadAndNext()))
					{
						case TokenType.CloseSquareBracket:
							return array;

						// Object
						case TokenType.OpenCurlyBracket:
							array.Add(this.AnalyzeObject());
							break;
						// Array
						case TokenType.OpenSquareBracket:
							array.Add(this.AnalyzeArray());
							break;
						// String
						case TokenType.DoubleQuote:
							array.Add(this.AnalyzeString());
							break;
						// Number
						case TokenType.Number:
							array.Add(this.AnalyzeNumber());
							break;

						case TokenType.PrettyToken:
						case TokenType.Colon:
						case TokenType.Comma:
							break;
						default:
							throw new FormatException("Invalid format.");
					}
				}

				throw new FormatException("配列が終了していません。");
			}

			private string AnalyzeKey()
			{
				var key = String.Empty;

				for (; this.Cursor < this.Source.Length; )
				{
					var c = this.ReadAndNext();
					switch (this.GetTokenType(c))
					{
						case TokenType.DoubleQuote:
							return key;
						default:
							key += c;
							break;
					}
				}

				throw new FormatException("キーの途中でソースが終了しました。");
			}

			private string AnalyzeString()
			{
				var str = String.Empty;

				for (; this.Cursor < this.Source.Length; )
				{
					var c = this.ReadAndNext();
					switch (this.GetTokenType(c))
					{
						case TokenType.DoubleQuote:
							return str;
						default:
							str += c;
							break;
					}
				}

				throw new FormatException("文字列の途中でソースが終了しました。");
			}

			private long AnalyzeNumber()
			{
				this.Back();
				var num = String.Empty;

				for (; this.Cursor < this.Source.Length; )
				{
					var c = this.Read();
					switch (this.GetTokenType(c))
					{
						case TokenType.Number:
							num += c;
							this.Next();
							break;
						default:
							return long.Parse(num);
					}
				}

				throw new FormatException("数値の途中でソースが終了しました。");
			}
		}
	}
}
