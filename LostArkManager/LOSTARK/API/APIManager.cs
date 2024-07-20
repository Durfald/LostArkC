using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace LostArkManager.LOSTARK.API
{
    public class APIManager
    {
        //https://static.monopoly.la.gmru.net
        //jews
        static async Task<string> SendImage(byte[] ImagesBytes,string ImageName,string Type="NoFiltered")
        {
            string FolderName = "";
            switch(Type)
            {
                case "Jewelry":
                    FolderName = "Jewelries";
                    break;
                case "Skill":
                    FolderName = "Skills";
                    break;
                case "Tripod":
                    FolderName = "Tripodes";
                    break;
                case "Equipment":
                    FolderName = "Equipments";
                    break;
                default:
                    FolderName = "NoFiltered";
                    break;
            }
            using (var ImageContent = new ByteArrayContent(ImagesBytes))
            {
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.PostAsync("",ImageContent))
                    {
                        if(!response.IsSuccessStatusCode)
                            return $"Image: {ImageName} no sended\r\n" +
                                $"HTTP Code: {response.StatusCode}"; 
                    }
                }
            }
            return string.Empty;
        }
    }
}
