namespace codecord_api
{
  public class User : Base
  {
    public string? DisplayName { get; set; }
    public string? PhoneNumber { get; set; }
    public string? UserName { get; set; }
    public string? Email { get; set; }
    public string? Name { get; set; }
    public int? UserTag { get; set; }
    public Server? Server { get; set; }
  }
}
