using LostArkManager.LOSTARK.Extensions;
using LostArkManager.LOSTARK.Parser.LA_Arsenal_Models;
using LostArkManager.LOSTARK.Parser.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System.Diagnostics;
using System.Dynamic;
using System.IO;
using System.Net;
using System.Net.Http;

namespace LostArkManager.LOSTARK.Parser
{
    class LAParser
    {
        public static async Task<Character?> GetCharacter(string Nickname)
        {
            string apiUrl = $"https://api.lostarktree.ru/rating?filters[nickname]={Nickname}&filters[force]=true";

            using (HttpClient client = new HttpClient())
            {
                    client.DefaultRequestHeaders.Add("Origin", "https://lostarktree.ru");

                    HttpResponseMessage response = await client.GetAsync(apiUrl);
                
                    Debug.WriteLine(response.IsSuccessStatusCode);
                    if (!response.IsSuccessStatusCode)
                        return null;

                    string responseData = await response.Content.ReadAsStringAsync();
                    var q = JsonConvert.DeserializeObject<Character[]>(responseData, new EquipmentItemConverter());
                var w = new DateTime();
                w.UnixTimeConvert(q[0].UnixDate);
                    return q[0];
                
            }
        }

        static RestClient Client = new();

        public static async Task GetCharacterv2(string Nickname)
        {
            var req = new RestRequest($"https://xn--80aubmleh.xn--p1ai/%D0%9E%D1%80%D1%83%D0%B6%D0%B5%D0%B9%D0%BD%D0%B0%D1%8F/{Nickname}", Method.Get);
            var res = await Client.ExecuteAsync(req);
            if (res.StatusCode != HttpStatusCode.OK)
                throw new Exception(res.Content);

            if (res.Content == null)
                throw new Exception("res.Content is null");
            var document = new HtmlAgilityPack.HtmlDocument();
            //var file = File.ReadAllText("TestFiles/durfald.txt");
            document.LoadHtml(res.Content);
            var isFound = document.DocumentNode.SelectSingleNode("//div[@class='profile-attention']") == null;
            if (!isFound)
                throw new Exception("404 Not Found");
            var anotherprofilesnodes = document.DocumentNode.SelectNodes("//ul/li/span/button/img");
            List<string> imgsource = new();
            List<int> levels = new List<int>();
            List<string> nicknames = new();
            List<string> classNames = new();
            foreach(var node in anotherprofilesnodes)
            {
                imgsource.Add(node.Attributes["src"].Value);
                var levelnode = node.NextSibling;
                levels.Add(int.Parse(levelnode.InnerText.Split('.')[1]));
                var nicknamenode = levelnode.NextSibling;
                nicknames.Add(nicknamenode.InnerText);
                classNames.Add(node.Attributes["alt"].Value);
            }
            var servername = document.DocumentNode.SelectSingleNode("//span[@class='profile-character-info__server']").InnerText.Replace("@","");
            var expeditoonlevel = int.Parse(document.DocumentNode.SelectSingleNode("//div[@class='level-info__expedition']/span[last()]/text()").InnerText);
            var personlevel = int.Parse(document.DocumentNode.SelectSingleNode("//div[@class='level-info__item']/span[last()]/text()").InnerText);
            var currentgearscore = double.Parse((document.DocumentNode.SelectSingleNode("//div[@class='level-info2__expedition']/span[last()]/text()").InnerText.Replace(",", "") +
                document.DocumentNode.SelectSingleNode("//div[@class='level-info2__expedition']/span[last()]/small[last()]/text()").InnerText).Replace('.',','));
            var maxgearscore = double.Parse((document.DocumentNode.SelectSingleNode("//div[@class='level-info2__item']/span[last()]/text()").InnerText.Replace(",", "") +
                document.DocumentNode.SelectSingleNode("//div[@class='level-info2__item']/span[last()]/small[last()]/text()").InnerText).Replace('.', ','));
            var title = document.DocumentNode.SelectSingleNode("//div[@class='game-info__title']/span[last()]").InnerText;
            var guild = document.DocumentNode.SelectSingleNode("//div[@class='game-info__guild']/span[last()]").InnerText;
            var pvp = document.DocumentNode.SelectSingleNode("//div[@class='level-info__pvp']/span[last()]").InnerText;
            //Поместье
            var wisdom = document.DocumentNode.SelectSingleNode("//div[@class='game-info__wisdom']/span[last()]").InnerText;
            //Уровень Поместья
            var wisdomlevel = int.Parse(document.DocumentNode.SelectSingleNode("//div[@class='game-info__wisdom']/span[last()-1]/text()").InnerText);
            //AP Сила атаки
            var power = int.Parse(document.DocumentNode.SelectSingleNode("//div[@class='profile-ability-basic']/ul/li[1]/span[2]").InnerText);
            var powerdesc = document.DocumentNode.SelectSingleNode("//div[@class='profile-ability-basic']/ul/li[1]/div/ul/li").InnerText;

            var vitality = int.Parse(document.DocumentNode.SelectSingleNode("//div[@class='profile-ability-basic']/ul/li[2]/span[2]").InnerText);
            var vitalitydesc = document.DocumentNode.SelectSingleNode("//div[@class='profile-ability-basic']/ul/li[2]/div/ul/li").InnerText;
            //Смертоносность
            var crit = document.DocumentNode.SelectSingleNode("//div[@class='profile-ability-battle']/ul/li/span[last()]").InnerText;
            var critdesc = document.DocumentNode.SelectSingleNode("//div[@class='profile-ability-battle']/ul/li/div/ul/li").InnerText;
            //Мастерство
            var speciality = document.DocumentNode.SelectSingleNode("//div[@class='profile-ability-battle']/ul/li[2]/span[last()]").InnerText;
            var specialitydesc = document.DocumentNode.SelectSingleNode("//div[@class='profile-ability-battle']/ul/li[2]/div/ul/li").InnerText;
            //Подавление
            var subdue = document.DocumentNode.SelectSingleNode("//div[@class='profile-ability-battle']/ul/li[3]/span[last()]").InnerText;
            var subduedesc = document.DocumentNode.SelectSingleNode("//div[@class='profile-ability-battle']/ul/li[3]/div/ul/li").InnerText;
            //Сноровка
            var agility = document.DocumentNode.SelectSingleNode("//div[@class='profile-ability-battle']/ul/li[4]/span[last()]").InnerText;
            var agilitydesc = document.DocumentNode.SelectSingleNode("//div[@class='profile-ability-battle']/ul/li[4]/div/ul/li").InnerText;
            //Стойкость
            var endurance = document.DocumentNode.SelectSingleNode("//div[@class='profile-ability-battle']/ul/li[5]/span[last()]").InnerText;
            var endurancedesc = document.DocumentNode.SelectSingleNode("//div[@class='profile-ability-battle']/ul/li[5]/div/ul/li").InnerText;
            //Искусность
            var proficiency = document.DocumentNode.SelectSingleNode("//div[@class='profile-ability-battle']/ul/li[6]/span[last()]").InnerText;
            var proficiencydesc = document.DocumentNode.SelectSingleNode("//div[@class='profile-ability-battle']/ul/li[6]/div/ul/li").InnerText;
            var engraves = from node in document.DocumentNode.SelectNodes("//ul[@class='swiper-slide']/li/span/text()")
                           select node.InnerText.Remove(node.InnerLength-6,6);
            var engraveslevel = from node in document.DocumentNode.SelectNodes("//ul[@class='swiper-slide']/li/span/text()")
                                let array = node.InnerText.Split(' ')
                                select array[array.Length-2];

            var engravesdesc = from node in document.DocumentNode.SelectNodes("//div[@class='profile-ability-tooltip']/p")
                               select node.InnerText;
            var usedskillpoints = int.Parse(document.DocumentNode.SelectSingleNode("//div[@class='profile-skill__point']/em/text()").InnerText);
            var allskillpoints = int.Parse(document.DocumentNode.SelectSingleNode("//div[@class='profile-skill__point']/em[last()]/text()").InnerText);
            var skills = (from node in document.DocumentNode.SelectNodes("//a[@class='button button--profile-skill']")
                          select JsonConvert.DeserializeObject<Skill>(WebUtility.HtmlDecode(node.Attributes["data-skill"].Value))).ToArray();

            var craft_amulet_grade = Enum.Parse(typeof(Grade), document.DocumentNode.SelectSingleNode("//ul[@class='special-info__slot']/li[2]/div")?.Attributes["data-grade"].Value);
            var craft_amulet_UrlIcon = document.DocumentNode.SelectSingleNode("//ul[@class='special-info__slot']/li[2]/div/div/img")?.Attributes["src"].Value;
            var craft_amulet_name = document.DocumentNode.SelectSingleNode("//ul[@class='special-info__slot']/li[2]/div/span/p/font/text()")?.InnerText;


            var compass_grade = Enum.Parse(typeof(Grade), document.DocumentNode.SelectSingleNode("//ul[@class='special-info__slot']/li[1]/div")?.Attributes["data-grade"].Value);
            var compass_UrlIcon = document.DocumentNode.SelectSingleNode("//ul[@class='special-info__slot']/li[1]/div/div/img")?.Attributes["src"].Value;
            var compass_name = document.DocumentNode.SelectSingleNode("//ul[@class='special-info__slot']/li[1]/div/span/p/font/text()")?.InnerText;


            var sign_warrior_grade = Enum.Parse(typeof(Grade), document.DocumentNode.SelectSingleNode("//ul[@class='special-info__slot']/li[3]/div")?.Attributes["data-grade"].Value);
            var sign_warrior_UrlIcon = document.DocumentNode.SelectSingleNode("//ul[@class='special-info__slot']/li[3]/div/div/img")?.Attributes["src"].Value;
            var sign_warrior_name = document.DocumentNode.SelectSingleNode("//ul[@class='special-info__slot']/li[3]/div/span/p/font/text()")?.InnerText;

            var personImg = document.DocumentNode.SelectSingleNode("//div[@class='profile-equipment__character']/img").Attributes["src"].Value;

            var profile_craft_skills_name = from node in document.DocumentNode.SelectNodes("//li[contains(@class,'life-skill')]/strong")
                                            select node.InnerText;

            var profile_craft_skills_level = from node in document.DocumentNode.SelectNodes("//li[contains(@class,'life-skill')]/span")
                                            select int.Parse(node.InnerText.Split('.')[1]);

            var jewelries_level = from node in document.DocumentNode.SelectNodes("//span[@class='jewel_level']")
                                  select int.Parse(node.InnerHtml.Split(' ')[1]);
            var jewelries_img = from node in document.DocumentNode.SelectNodes("//span[@class='jewel_img']")
                               select node.FirstChild.Attributes["src"].Value;
            var jewelries_grade = from node in document.DocumentNode.SelectNodes("//span[@class='jewel_btn']")
                                select Enum.Parse(typeof(Grade),node.Attributes["data-grade"].Value);
            var jewelries_data_gemkey = from node in document.DocumentNode.SelectNodes("//span[@class='jewel_btn']")
                                        select node.Attributes["id"].Value;
            Dictionary<string, (string skillname,string jew_description)> jewelries_description = new();
            var jewelries_description_node = document.DocumentNode.SelectNodes("//div[@class='box_wrapper']/ul/li");

            foreach (var gemkey in jewelries_data_gemkey)
            {
                var node = jewelries_description_node.FirstOrDefault(x => x.ChildNodes["span"].Attributes["data-gemkey"].Value==gemkey);
                var description = node.ChildNodes["p"].InnerText;
                var skillname = node.ChildNodes["strong"].InnerText;
                jewelries_description.Add(gemkey,(skillname,description));
            }

            var card_img = from node in document.DocumentNode.SelectNodes("//div[@class='card-slot']/img")
                select node.Attributes["src"].Value;
            var card_name = from node in document.DocumentNode.SelectNodes("//div[@class='card-slot']/strong")
                            select node.InnerText;
            var card_grade = from node in document.DocumentNode.SelectNodes("//div[@class='card-slot']")
                             select node.Attributes["data-grade"].Value;
            var card_awake = from node in document.DocumentNode.SelectNodes("//div[@class='card-slot']")
                             select node.Attributes["data-awake"].Value;
            var card_awakemax = from node in document.DocumentNode.SelectNodes("//div[@class='card-slot']")
                             select node.Attributes["data-awakemax"].Value;
            var card_effect_titles = from node in document.DocumentNode.SelectNodes("//ul[@class='card-effect']/li/div[1]")
                                     select WebUtility.HtmlDecode(node.InnerText);
            var card_effect_desc = from node in document.DocumentNode.SelectNodes("//ul[@class='card-effect']/li/div[2]")
                                     select node.InnerText;
            var script = document.DocumentNode.SelectNodes("//script[@type='text/javascript']").FirstOrDefault(x => x.LinePosition==0);
            var text = script.InnerText.RemoveHTMLCode().Split('=')[1].Replace("\r\n","");
            text = text.Remove(text.Length-1,1);
            var obj = JObject.Parse(text);

        }
        private static int ParseInt(string value) => int.Parse(value.Replace(",", ""));

        public static async Task<CollectionsCount?> GetCollections(string memberNo, string worldNo,string pcId)
        {
            string apiUrl = $"https://api.lostarktree.ru/rating?filters[collections]=true&filters[memberNo]={memberNo}&filters[worldNo]={worldNo}&filters[pcId]={pcId}";

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    client.DefaultRequestHeaders.Add("Origin", "https://lostarktree.ru");

                    HttpResponseMessage response = await client.GetAsync(apiUrl);
                    if (!response.IsSuccessStatusCode)
                        return null;

                    string responseData = await response.Content.ReadAsStringAsync();
                    var jObject=JObject.Parse(responseData);
                    var q = jObject["collections_count"];
                    var result = new CollectionsCount
                    {
                        Heart = ParseInt(q["heart"].Value<string>()),
                        Island = ParseInt(q["island"].Value<string>()),
                        Mococo = ParseInt(q["mococo"].Value<string>()),
                        Masterpiece = ParseInt(q["masterpiece"].Value<string>()),
                        SeaAdventures = ParseInt(q["sea_adventures"].Value<string>()),
                        WorldTree = ParseInt(q["world_tree"].Value<string>()),
                        IgneaToken = ParseInt(q["ignea_token"].Value<string>()),
                        OrpheusStar = ParseInt(q["orpheus_star"].Value<string>()),
                        Orgel = ParseInt(q["orgel"].Value<string>())
                    };
                    return result;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }
    }
}
