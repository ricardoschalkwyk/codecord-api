namespace codecord_api
{
  public class MyPayload
  {
    public string? Name { get; set; }
    public string? Message { get; set; }
    public List<To> Contacts{get; set;} = new List<To>();
  }
}
