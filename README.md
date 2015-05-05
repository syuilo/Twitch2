![](https://raw.githubusercontent.com/syuilo/Twitch2/master/twitch2.png)

できるかぎりシンプルに、できるかぎり簡単に、できるかぎり美しくTwitterを扱えるようにしたTwitterライブラリです。
TwitterAPI 1.1、ストリーミング、xAuth認証などにも対応。

# 簡単なドキュメンテーション
**C#**での解説となります。ご了承ください。
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
**無事にツイートが投稿されていれば成功です。**

### 上記のコードの解説
`var twitter = new Twitter(...)`で***Twitterクラス(Twitch.Twitter)*のインスタンス**を作成しています。

便宜上、この**「Twitterクラスのインスタンス」のことをTwitchでは*Twitterオブジェクト*と呼んでいます。**

Twitterオブジェクトの`Authorize`メソッドの呼び出しでブラウザに認証フォームを表示させます。

Twitterオブジェクトの`AuthorizePin`メソッドは、PINコードを受け取って、新たな認証されたユーザーのTwitterオブジェクトを返します(呼び出したTwitterオブジェクト自体が書き換わるわけではありません。**新たな**Twitterオブジェクトを返します)。

## ストリーミング
Twitterの**ストリーミングAPI**を利用すると、リアルタイムでタイムラインを取得したりすることが出来ます。TwitchではこれらのストリーミングAPIをサポートしています。

試しに*UserStream*を利用してみます。
Streaming APIの中でも、*UserStream*はユーザーのホーム タイムライン、各種イベントが送られます。
つまり、通常のそのユーザーのホーム タイムラインに表示されるべきツイートに加えて、ツイートがお気に入りに登録された/解除された、フォローされた、リストが更新されたなどのイベントが発行されます。
Twitchではこれらのイベントも簡単に利用できます。

UserStreamに接続するには、*UserStream (Twitch.Streaming.UserStream)* クラスを利用します。
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

## カスタム リクエストの作成
一般に公開されていないエンドポイントへのリクエストなど、Twitchが対応していないAPIへの独自のリクエストを送信したい場合は、*TwitterオブジェクトのRequestメソッド*を利用するか、または *TwitterRequest (Twitch.TwitterRequest) クラス* を利用して簡単にリクエストを作成できます。

### TwitterオブジェクトのRequestメソッドを利用する例
```
var query = new StringDictionary();
query["hrtn"] = "hmwr";
query["oomr"] = "skrk";

tw.Request(API.Method.POST, new Uri('https://api.twitter.com/hoge/huga.json'), query);
```

# License
ms-pl

# Special thanks
古谷向日葵、大室櫻子
