namespace codecord_api
{
  public class Category : Base
  {
    public bool IsPrivate { get; set; }
    public string Name { get; set; } = "";
    public int? ServerId { get; set; }
    public Server Server { get; set; } = null!;
    public ICollection<Channel> Channels { get; } = new List<Channel>();
  }
}
