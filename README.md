# Twitch2
Twitch2 is a .NET Twitter library

# Examples
## Authentication
まず
```CSharp
var twitter = new Twitter("your consumer key", "your consumer secret");
twitter.Authorize();
```
とします。すると規定のウェブブラウザで連携認証フォームが表示されます。ユーザーが連携を許可するとPINコードが得られます。
次に、
```CSharp
twitter = await twitter.AuthorizePin('got pin code');
```
とすることでTwitterAPIにアクセス出来るようになります。ここまでたった3文です。
実際になにかつぶやいてみましょう:
```CSharp
twitter.StatusesUpdate("Hello, Twitch!");
```
さあどうでしょうか。タイムラインを確認してみてください。
無事にツイートが投稿されていれば完了です。
