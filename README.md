# Twitch2
Twitch2 is a .NET Twitter library

# Examples
## はじめに
まず
```CSharp
var twitter = new Twitter("your consumer key", "your consumer secret");
twitter.Authorize();
```
とします(`your consumer key`にはあなたのアプリケーションの*ConsumerKey*を、`your consumer secret`にはあなたのアプリケーションの*ConsumerSecret*を設定してください)。

すると規定のウェブブラウザで連携認証フォームが表示されます。ユーザーが連携を許可するとPINコードが得られます。
次に、
```CSharp
twitter = await twitter.AuthorizePin('got pin code');
```
とすることでTwitterAPIにアクセス出来るようになります(`got pin code`には取得できた*PINコード*を設定してください)。
ここまでたった3文です。
実際になにかつぶやいてみましょう:
```CSharp
twitter.StatusesUpdate("Hello, Twitch!");
```
さあどうでしょうか。タイムラインを確認してみてください。
無事にツイートが投稿されていれば成功です。
