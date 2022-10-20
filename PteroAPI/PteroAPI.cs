using System.Text;

namespace PteroAPI
{
    public class Pterodactyl
    {
        public string? APIUrl { get; set; }
        public string? APIKey { get; set; }
        public string? ServerResponseMessage { get; set; }
        public static readonly HttpClient httpClient = new();

        public Pterodactyl(string Url, string Key)
        {
            APIUrl = Url;
            APIKey = Key;
        }

        public async Task ConsoleCmdAsync(string server, string command)
        {
            using HttpRequestMessage request = new(new HttpMethod("POST"), $"{APIUrl}/api/client/servers/{server}/command");
            request.Headers.TryAddWithoutValidation("Content-Type", "application/json");
            request.Headers.TryAddWithoutValidation("Authorization", $"Bearer {APIKey}");
            request.Content = new FormUrlEncodedContent(new[] {
                                    new KeyValuePair<string, string>("command", command),
                                });
            HttpResponseMessage response = await httpClient.SendAsync(request);
            return;
        }

        public async Task ServerPowerAsync(string server, string power)
        {
            using HttpRequestMessage request = new(new HttpMethod("POST"), $"{APIUrl}/api/client/servers/{server}/power");
            request.Headers.TryAddWithoutValidation("Content-Type", "application/json");
            request.Headers.TryAddWithoutValidation("Authorization", $"Bearer {APIKey}");
            request.Content = new FormUrlEncodedContent(new[] {
                                    new KeyValuePair<string, string>("signal", power),
                                });
            HttpResponseMessage response = await httpClient.SendAsync(request);
        }

        public async Task ServerResourcesAsync(string server)
        {
            using HttpRequestMessage request = new(new HttpMethod("GET"), $"{APIUrl}/api/client/servers/{server}/resources");
            request.Headers.TryAddWithoutValidation("Content-Type", "application/json");
            request.Headers.TryAddWithoutValidation("Authorization", $"Bearer {APIKey}");
            HttpResponseMessage response = await httpClient.SendAsync(request);
            ServerResponseMessage = await response.Content.ReadAsStringAsync();
        }

        public async Task GetFileContents(string server, string file)
        {
            using HttpRequestMessage request = new(new HttpMethod("GET"), $"{APIUrl}/api/client/servers/{server}/files/contents?file=%2F{file}");
            request.Headers.TryAddWithoutValidation("Content-Type", "application/json");
            request.Headers.TryAddWithoutValidation("Authorization", $"Bearer {APIKey}");
            HttpResponseMessage response = await httpClient.SendAsync(request);
            ServerResponseMessage = await response.Content.ReadAsStringAsync();
        }

        public async Task WriteFile(string server, string file, string contents)
        {
            using HttpRequestMessage request = new(new HttpMethod("POST"), $"{APIUrl}/api/client/servers/{server}/files/write?file=%2F{file}");
            request.Headers.TryAddWithoutValidation("Content-Type", "application/json");
            request.Headers.TryAddWithoutValidation("Authorization", $"Bearer {APIKey}");
            request.Content = new StringContent(contents, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await httpClient.SendAsync(request);
        }

        public async Task ReinstallServer(string server)
        {
            using HttpRequestMessage request = new(new HttpMethod("POST"), $"{APIUrl}/api/client/servers/{server}/settings/reinstall");
            request.Headers.TryAddWithoutValidation("Content-Type", "application/json");
            request.Headers.TryAddWithoutValidation("Authorization", $"Bearer {APIKey}");
            HttpResponseMessage response = await httpClient.SendAsync(request);
        }

        public async Task CreateBackup(string server)
        {
            using HttpRequestMessage request = new(new HttpMethod("POST"), $"{APIUrl}/api/client/servers/{server}/backups");
            request.Headers.TryAddWithoutValidation("Content-Type", "application/json");
            request.Headers.TryAddWithoutValidation("Authorization", $"Bearer {APIKey}");
            HttpResponseMessage response = await httpClient.SendAsync(request);
        }

        public async Task GetWebSocketURI(string server)
        {
            using HttpRequestMessage request = new(new HttpMethod("GET"), $"{APIUrl}/api/client/servers/{server}/websocket");
            request.Headers.TryAddWithoutValidation("Content-Type", "application/json");
            request.Headers.TryAddWithoutValidation("Authorization", $"Bearer {APIKey}");
            HttpResponseMessage response = await httpClient.SendAsync(request);
            ServerResponseMessage = await response.Content.ReadAsStringAsync();
        }
    }
}