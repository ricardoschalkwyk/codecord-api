namespace codecord_api
{
  public class Channel
  {
    public int ChannelId { get; set; }
    public string? TextChatChannel {get; set;}
    public string? VoiceChatChannel {get; set;}
    public bool IsPrivate;
  }
}
