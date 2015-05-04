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

すると規定のウェブブラウザで連携認証フォームが表示されます。ユーザーが連携を許可すると*PINコード*が得られます。
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

## ストリーミング
Twitterの**ストリーミングAPI**を利用すると、リアルタイムでタイムラインを取得したりすることが出来ます。TwitchではこれらのストリーミングAPIをサポートしています。

試しに*UserStream*を利用してみます。
Streaming APIの中でも、*UserStream*はユーザーのホーム タイムライン、各種イベントが送られます。
つまり、通常のそのユーザーのホーム タイムラインに表示されるべきツイートに加えて、ツイートがお気に入りに登録された/解除された、フォローされた、リストが更新されたなどのイベントが発行されます。
Twitchではこれらのイベントも簡単に利用できます。

UserStreamに接続するには、*Streaming.UserStream* クラスを利用します。
UserStream クラスの *Connect()* メソッドにより接続を開始出来ます。

具体的なコードを以下に示します。
```CSharp
var tw = (上記の認証手順などで取得できたTwitterオブジェクト)
 
// UserStream作成
var u = new Twitch.Streaming.UserStream(tw);
 
// StatusUpdated イベントをイベント ハンドラーに登録
// このイベントは、ホーム タイムラインにツイートが投稿された際に発生します。
u.StatusUpdated += 
    new Twitch.Streaming.UserStream.StatusUpdatedEventHandler(StreamingCallback);
 
// 接続を開始
u.Connect();
```
上記のコードに加え、ツイートを受け取るイベント ハンドラーを作成する必要があります。
以下はその例です。
```CSharp
public void StreamingCallback(object sender, Twitch.Streaming.StatusUpdatedEventArgs e)
{
    // ツイートを表示
    Console.WriteLine(e.Status.Text);
}
```
上記のコードを実行すると、コンソールにリアルタイム&非同期でユーザーのホーム タイムラインが表示されていきます。
このように、接続を開始すると、継続してTwitterからStream メッセージが送信されていきます。
イベント メッセージを受信すると、それに対応したイベントが発行されます。これには通常のツイート イベントも含まれます。

UserStreamのStreaming 接続は、様々な理由により予期せずに切断されることがあります。
このとき、あらかじめStreamの*IsAutoReconnect*プロパティを`true`にしておくと、自動的に再接続を試みます。
