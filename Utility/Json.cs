/*====================================================================
 * Json
 * ver 0.0.0.0
 *
 * created and maintained by syuilo <syuilotan@yahoo.co.jp>
 * licensed under the MIT license
 * http://syuilo.com/
 * https://github.com/syuilo/Json
 *====================================================================*/

using System;
using System.Collections.Generic;

namespace Twitch.Utility
{
	public static class Json
	{
		public static object Deserialize(string source)
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

			private const string TRUE = "true";

			private const string FALSE = "false";

			private const string NULL = "null";

			private enum TokenType
			{
				OpenCurlyBracket,
				CloseCurlyBracket,
				OpenSquareBracket,
				CloseSquareBracket,
				DoubleQuote,
				Colon,
				Comma,
				Number,
				Hyphen,
				Period,
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
					case '-':
						return TokenType.Hyphen;
					case '.':
						return TokenType.Period;
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
				return this.Source[this.Cursor + pos];
			}

			private Char ReadAndNext()
			{
				var c = this.Read();
				this.Next();
				return c;
			}

			private void Next(int? step = null)
			{
				if (step == null)
					this.Cursor++;
				else
					this.Cursor += (int)step;
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

			public object Parse()
			{
				if (String.IsNullOrEmpty(this.Source))
					throw new FormatException("データソースが空です。");

				var obj = new object();

				switch (this.GetTokenType(this.ReadAndNext()))
				{
					case TokenType.OpenCurlyBracket:
						obj = this.AnalyzeObject();
						break;
					case TokenType.OpenSquareBracket:
						obj = this.AnalyzeArray();
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
					switch (this.GetTokenType(this.ReadAndNext()))
					{
						case TokenType.DoubleQuote:
							var key = this.AnalyzeKey();
							var value = this.AnalyzeValue();
							obj.Add(key, value);
							break;
						case TokenType.CloseCurlyBracket:
							return obj;
						case TokenType.PrettyToken:
						case TokenType.Comma:
							break;
						default:
							throw new FormatException("Invalid format.");
					}
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

						default:
							this.Back();
							array.Add(this.AnalyzeValue());
							break;
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
						case TokenType.Escape:
							this.Next();
							break;
						case TokenType.DoubleQuote:
							return key;
						default:
							key += c;
							break;
					}
				}

				throw new FormatException("キーの途中でソースが終了しました。");
			}

			private object AnalyzeValue()
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
						case TokenType.Hyphen:
							return this.AnalyzeNumber();

						case TokenType.PrettyToken:
						case TokenType.Colon:
						case TokenType.Comma:
							break;

						default:
							// Boolean (true)
							if (this.Source.Substring(this.Cursor - 1, TRUE.Length) == TRUE)
							{
								this.Next(TRUE.Length - 1);
								return true;
							}
							// Boolean (false)
							else if (this.Source.Substring(this.Cursor - 1, FALSE.Length) == FALSE)
							{
								this.Next(FALSE.Length - 1);
								return false;
							}
							// Null
							else if (this.Source.Substring(this.Cursor - 1, NULL.Length) == NULL)
							{
								this.Next(NULL.Length - 1);
								return null;
							}
							else
								throw new FormatException("Invalid format.");
					}
				}

				throw new FormatException("値に出会う前にソースが終了しました。");
			}

			private string AnalyzeString()
			{
				var str = String.Empty;

				for (; this.Cursor < this.Source.Length; )
				{
					var c = this.ReadAndNext();
					switch (this.GetTokenType(c))
					{
						case TokenType.Escape:
							if (this.Read() == 'u')
							{
								str += "\\u";
							}
							this.Next();
							break;
						case TokenType.DoubleQuote:
							return System.Text.RegularExpressions.Regex.Unescape(str);
						default:
							str += c;
							break;
					}
				}

				throw new FormatException("文字列の途中でソースが終了しました。");
			}

			private object AnalyzeNumber()
			{
				this.Back();
				var num = String.Empty;

				for (; this.Cursor < this.Source.Length; )
				{
					var c = this.Read();
					switch (this.GetTokenType(c))
					{
						case TokenType.Number:
						case TokenType.Hyphen:
						case TokenType.Period:
							num += c;
							this.Next();
							break;
						default:
							if (num.IndexOf('.') >= 0)
								return double.Parse(num);
							else
								return long.Parse(num);
					}
				}

				throw new FormatException("数値の途中でソースが終了しました。");
			}
		}
	}
}
