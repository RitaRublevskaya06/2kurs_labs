using System.Text.Json;

namespace ASPA008_1
{
    public class WikiInfoCelebrity
    {
        HttpClient client;
        Dictionary<string, string> wikiReferens { get; set; }
        string wikiURI;
        private WikiInfoCelebrity(string fullname)
        {
            this.client = new HttpClient();
            this.wikiReferens = new Dictionary<string, string>();
            this.wikiURI = string.Format("https://en.wikipedia.org/w/api.php?action=opensearch&search=\"{0}\"&prop=info&format=json", fullname);
        }

        public static async Task<Dictionary<string, string>> GetRefereces(string fullname)
        {
            try
            { 
            WikiInfoCelebrity info = new WikiInfoCelebrity(fullname);
            HttpResponseMessage message = await info.client.GetAsync(info.wikiURI);
            if (message.StatusCode == System.Net.HttpStatusCode.OK)
            {
                List<dynamic>? result = await message.Content.ReadFromJsonAsync<List<dynamic>>() ?? default(List<dynamic>);
                List<string>? ls1 = JsonSerializer.Deserialize<List<string>>(result[1]);
                List<string>? ls3 = JsonSerializer.Deserialize<List<string>>(result[3]);
                for (int i = 0; i < ls1.Count; i++)
                {
                    info.wikiReferens.Add(ls1[i], ls3[i]);
                }
            }
                return info.wikiReferens;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"HTTP Error: {ex.Message}");
                return new Dictionary<string, string>();
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"JSON Parsing Error: {ex.Message}");
                return new Dictionary<string, string>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected Error: {ex.Message}");
                return new Dictionary<string, string>();
            }
        
        }
    }
}
