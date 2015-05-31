![](https://raw.githubusercontent.com/syuilo/Twitch2/master/twitch2.png)

できるかぎりシンプルに、できるかぎり簡単に、できるかぎり美しくTwitterを扱えるようにしたTwitterライブラリです。
TwitterAPI 1.1、ストリーミング、xAuth認証などにも対応。

# ダウンロード
**[ここ](http://syuilo.com/Twitch.zip)**

(注: 上記のダウンロード先のものは古い可能性があります。最新のものを使いたい場合はこのリポジトリをクローンし手動でビルドしてください)

付属のXMLも一緒に設置することで、インテリセンスの恩恵を受けられます。
![](http://syuilo.com/twitch/twitchintellisense.png)

# 簡単なドキュメンテーション
**C#**での解説となります。ご了承ください。
## はじめに
Twitchの使い方の例として、タイムラインにツイートを投稿するまでの一連の流れを見ていきます。

まず
```CSharp
var tw = new Twitter("your consumer key", "your consumer secret");
tw.Authorize();
```
とします(`your consumer key`にはあなたのアプリケーションの*ConsumerKey*を、`your consumer secret`にはあなたのアプリケーションの*ConsumerSecret*を設定してください)。

すると規定のウェブブラウザで連携認証フォームが表示されます。ユーザーが連携を許可すると*PINコード*が得られます。
次に、
```CSharp
tw = await tw.AuthorizePin("got pin code");
```
とすることでTwitterAPIにアクセス出来るようになります(`got pin code`には取得できた*PINコード*を設定してください)。
ここまでたった3文です。
実際になにかつぶやいてみましょう:
```CSharp
tw.StatusesUpdate("Hello, Twitch!");
```
さあどうでしょうか。タイムラインを確認してみてください。
**無事にツイートが投稿されていれば成功です。**

### 上記のコードの解説
`var tw = new Twitter(...)`で***Twitterクラス(Twitch.Twitter)*のインスタンス**を作成しています。

便宜上、この**「Twitterクラスのインスタンス」のことをTwitchでは*Twitterオブジェクト*と呼んでいます。**

Twitterオブジェクトの`Authorize`メソッドの呼び出しでブラウザに認証フォームを表示させます。

Twitterオブジェクトの`AuthorizePin`メソッドは、PINコードを受け取って、認証されたユーザーのAccessToken、AccessTokenSecretなどが設定された新たなTwitterオブジェクトを返します(呼び出したTwitterオブジェクト自体が書き換わるわけではありません。**新たな**Twitterオブジェクトを返します)。

## ストリーミング
Twitterの**ストリーミングAPI**を利用すると、リアルタイムでタイムラインを取得したりすることが出来ます。TwitchではこれらのストリーミングAPIをサポートしています。

試しに*UserStream*を利用してみます。
Streaming APIの中でも、*UserStream*はユーザーのホーム タイムライン、各種イベントが送られます。
つまり、通常のそのユーザーのホーム タイムラインに表示されるべきツイートに加えて、ツイートがお気に入りに登録された/解除された、フォローされた、リストが更新されたなどのイベントが発行されます。
Twitchではこれらのイベントも簡単に利用できます。

UserStreamに接続するには、*UserStream (Twitch.Streaming.UserStream)* クラスを利用します。
UserStream クラスの *Connect()* メソッドにより接続を開始出来ます。

具体的なコードを以下に示します。(`using Twitch.Streaming;`してください)
```CSharp
var tw = (上記の認証手順などで取得できたTwitterオブジェクト)
 
// UserStream作成
var stream = new UserStream(tw);
 
// StatusUpdated イベントをイベント ハンドラーに登録
// このイベントは、ホーム タイムラインにツイートが投稿された際に発生します。
stream.StatusUpdated += 
    new UserStream.StatusUpdatedEventHandler(StreamingCallback);
 
// 接続を開始
stream.Connect();
```
上記のコードに加え、ツイートを受け取るイベントハンドラーを作成する必要があります。
以下はその例です。
```CSharp
public void StreamingCallback(object sender, StatusUpdatedEventArgs e)
{
    // ツイートを表示
    Console.WriteLine(e.Status.Text);
}
```
外部にイベントハンドラーを作成せずに、ラムダ式を使っても書けます。
```CSharp
stream.StatusUpdated += (object _, StatusUpdatedEventArgs e) =>
{
    // ツイートを表示
    Console.WriteLine(e.Status.Text);
};
```
このプログラムを実行すると、コンソールにリアルタイム&非同期でユーザーのホーム タイムラインが表示されていきます。
このように、接続を開始すると、継続してTwitterからStream メッセージが送信されていきます。
イベント メッセージを受信すると、それに対応したイベントが発行されます。これには通常のツイート イベントも含まれます。

UserStreamのStreaming 接続は、様々な理由により予期せずに切断されることがあります。
このとき、あらかじめStreamの*IsAutoReconnect*プロパティを`true`にしておくと、自動的に再接続を試みます。

---

TwitchでこれらのストリーミングAPIを利用すれば、所謂**エタフォ**(タイムラインに流れてきたツイートを自動でふぁぼる)も簡単に実装することが出来ます。

## カスタム リクエストの作成
一般に公開されていないエンドポイントへのリクエストなど、Twitchが対応していないAPIへの独自のリクエストを送信したい場合は、*TwitterオブジェクトのRequestメソッド*を利用するか、または *TwitterRequest (Twitch.TwitterRequest) クラス* を利用して簡単にリクエストを作成できます。

### TwitterオブジェクトのRequestメソッドを利用する例
```
var query = new Dictionary<string, string>();
query["hrtn"] = "hmwr";
query["oomr"] = "skrk";

tw.Request(API.Method.POST, "https://api.twitter.com/hoge/huga.json", query);
```

# 今後の予定
## APIを抽象化してTwitterAPIの仕様を利用者に隠蔽する
現在:(例)
```
tw.StatusesUpdate("櫻子可愛いですわ");
```

今後:(例)
```
tw.Tweet("櫻子可愛いですわ");
```

# 初代Twitchからの変更点(初代Twitchを使っていた人向けのセクション)
- *TwitterContext*は、*Twitter*に名称変更しました。
- APIへのリクエストは、APIクラスのメンバメソッドにTwitterオブジェクトを渡す方式ではなく、Twitterオブジェクト自体がAPIリクエストメソッドを持つようになりました。これにより簡潔にAPIへリクエストを行うことが出来るようになりました。

Twitch:
```
Twitch.Twitter.APIs.REST.Statuses.Update(tw, "櫻子可愛いですわ");
```
Twitch2:
```
tw.StatusesUpdate("櫻子可愛いですわ");
```

- 認証もより簡潔になりました。Twitterオブジェクト自体が認証メソッドを持つようになり、Authorizeクラスのインスタンスを認証プロセスの間保持しておく必要がなくなりました。
- 疑似xAuthは最早サポートされなくなりました。

# License
ms-pl

# Special thanks
古谷向日葵、大室櫻子
