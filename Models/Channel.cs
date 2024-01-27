namespace codecord_api
{
  public class Channel : Base
  {
    public bool IsPrivate { get; set; }
    public string? Topic { get; set; }
    public bool IsVoice { get; set; }
    public string Name { get; set; } = "";
    public bool IsText { get; set; }

    public int? CategoryId { get; set; }
    public Category? Category { get; set; }
  }
}
