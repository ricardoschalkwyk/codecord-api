using System.Text;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;


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
    public async Task<OkObjectResult> Post([FromBody] string value)
    {
      var request = new HttpRequestMessage(HttpMethod.Post, "/users/ping");

      // request.Content = JsonContent.Create(new {
      //   key = "md-1CCChX5P1JJKORuGsLPiGg"
      // });

      var response = await _httpClient.PostAsync("/users/ping", new StringContent(JsonConvert.SerializeObject(new { key = "md-1CCChX5P1JJKORuGsLPiGg" }), Encoding.UTF8, "application/json"));

      var data = await response.Content.ReadAsStringAsync();

      return Ok(data);
    }
  }
}

// "14e12033af714f4b80382cc3b85deb44-us11"

// md-1CCChX5P1JJKORuGsLPiGg



