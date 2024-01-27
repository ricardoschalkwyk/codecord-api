namespace codecord_api
{
  public class Server : Base
  {
    public User? User { get; set; }
    public int? UserId { get; set; }
    public ICollection<Channel> Channels { get; set; } = new List<Channel>();
    public ICollection<Category> Categories { get; set; } = new List<Category>();
  }
}
