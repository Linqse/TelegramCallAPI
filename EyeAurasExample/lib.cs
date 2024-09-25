using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

public class TelegramApiClient : ITelegramApiClient
{
    private static readonly HttpClient _httpClient = new HttpClient();

    public async Task<(bool isSuccess, string response)> SendTextMessageAsync(string username, string text)
        => await SendAsync(username, text: text, call: false);

    public async Task<(bool isSuccess, string response)> SendPhotoAsync(string username, string photoUrl, string caption = null)
        => await SendAsync(username, photoUrl: photoUrl, text: caption, call: false);

    public async Task<(bool isSuccess, string response)> MakeCallAsync(string username)
        => await SendAsync(username, call: true);

    public async Task<(bool isSuccess, string response)> SendTextAndCallAsync(string username, string text)
        => await SendAsync(username, text: text, call: true);

    private async Task<(bool isSuccess, string response)> SendAsync(string username, string text = null, string photoUrl = null, bool call = false)
    {
        var payload = new
        {
            username,
            text,
            photo_url = photoUrl,
            call
        };

        return await PostAsync(payload);
    }

    private async Task<(bool, string)> PostAsync(object payload)
    {
        try
        {
            var jsonContent = new StringContent(System.Text.Json.JsonSerializer.Serialize(payload), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("https://api.eyesquad.net/telegram", jsonContent);

            var responseContent = await response.Content.ReadAsStringAsync();
            return (response.IsSuccessStatusCode, responseContent);
        }
        catch (Exception ex)
        {
            return (false, ex.Message);
        }
    }
}

public interface ITelegramApiClient
{
    Task<(bool isSuccess, string response)> SendTextMessageAsync(string username, string text);
    Task<(bool isSuccess, string response)> SendPhotoAsync(string username, string photoUrl, string caption = null);
    Task<(bool isSuccess, string response)> MakeCallAsync(string username);
    Task<(bool isSuccess, string response)> SendTextAndCallAsync(string username, string text);
}
