using Newtonsoft.Json;

namespace codecord_api.Models
{
  public class MailChimpApi
  {
    public string key { get; set; } = "md-1CCChX5P1JJKORuGsLPiGg";

    public string template_name { get; set; } = "Codecord";

    public TemplateContent? template_content { get; set; }

    public Message? message { get; set; } = new Message();
  }
}