using LostArkManager.LOSTARK.Extensions;
using LostArkManager.LOSTARK.Parser.Models;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net.Http;

namespace LostArkManager.LOSTARK.Parser
{
    class LAParser
    {
        public static async void Send(string Nickname)
        {
            string apiUrl = $"https://api.lostarktree.ru/rating?filters[nickname]={Nickname}";

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    client.DefaultRequestHeaders.Add("Origin", "https://lostarktree.ru");

                    HttpResponseMessage response = await client.GetAsync(apiUrl);
                    Debug.WriteLine(response.IsSuccessStatusCode);
                    if (response.IsSuccessStatusCode)
                    {
                        string responseData = await response.Content.ReadAsStringAsync();
                        var q = JsonConvert.DeserializeObject<List<Character>>(responseData, new EquipmentItemConverter());
                        Console.WriteLine(responseData);
                    }
                    else
                    {
                        Console.WriteLine($"Ошибка: {response.StatusCode} - {response.ReasonPhrase}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка при отправке запроса: {ex.Message}");
                }
            }
        }

    }
}
