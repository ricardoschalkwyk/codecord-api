using Microsoft.AspNetCore.Mvc;

namespace codecord_api.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class JsonPlaceHolderController : ControllerBase
    {
        private HttpClient _httpClient;
        public JsonPlaceHolderController(IHttpClientFactory clientFactory)
        {
            _httpClient = clientFactory.CreateClient("TaskApiClient");
        }

        [HttpGet]
        public async Task<OkObjectResult> GetFromJsonAsync()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "/posts");

            var response = await _httpClient.SendAsync(request);

            var data = await response.Content.ReadAsStringAsync();

            return Ok(data);
        }
    }
}

