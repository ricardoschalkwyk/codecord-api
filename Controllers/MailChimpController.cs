using codecord_api.Models;
using Microsoft.AspNetCore.Mvc;


namespace codecord_api.Controllers
{

  [ApiController]
  [Route("[controller]")]
  public class MailChimpController : ControllerBase
  {
    private HttpClient _httpClient;
    public MailChimpController(IHttpClientFactory clientFactory)
    {
      _httpClient = clientFactory.CreateClient("EmailApiClient");
    }

    [HttpPost]
    public async Task<OkObjectResult> Post( [FromBody] MyPayload payload)
    {
      var data = new MailChimpApi();

      var response = await _httpClient.PostAsJsonAsync<MailChimpApi>("messages/send-template", data);

      // var data = await response.Content.ReadAsAsync<string>();

      // payload.Contacts = data;

      return Ok(payload);
    }
  }
}
