namespace codecord_api
{
  public class Server : Base
  {
    public List<User> Members { get; set; } = new List<User>();
    public List<Channel> Channels { get; set; } = new List<Channel>();
  }
}
