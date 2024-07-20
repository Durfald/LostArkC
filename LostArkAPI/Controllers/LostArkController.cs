using LostArkAPI.DataBase;
using LostArkAPI.Models.API;
using LostArkAPI.Models.LostArk;
using LostArkAPI.Other;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.IO;

namespace LostArkAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LostArkController : ControllerBase
    {
        private string? GetAPIKey() => Request.Headers["apikey"];

        private bool Validate(string? key)
        {
            if(key is null)
                return false;
            var keys = DataBaseManager.Get<APIKey>();
            return keys.FirstOrDefault(x => x.Key == key) == null;
        }


        /// <summary>
        /// Add or update <see cref="Character"/> information
        /// </summary>
        /// <param name="Character">Character in game Lost Ark</param>
        /// <returns></returns>
        /// <response code="400">Character cannot be null</response>
        /// <response code="401">Unauthorized APIKey</response>
        [HttpPost]
        public IActionResult PostCharacter(Character Character)
        {
            //if (!Validate(GetAPIKey()))
            //    return Unauthorized(new Contract("Unauthorized APIKey"));
            if (Character == null)
                return BadRequest("Character cannot be null");
            var tempCharacter = DataBaseManager.Get<Character>().FirstOrDefault(x=>x.Class==Character.Class&&x.Nickname==Character.Nickname);
            if(tempCharacter is null)
            {
                DataBaseManager.Save(Character);
                return Ok("Character created and saved");
            }
            if (Math.Abs(Character.UnixDateUpdate - tempCharacter.UnixDateUpdate) >= 600)
            {
                Character.id = tempCharacter.id;
                DataBaseManager.Update(Character);
                return Ok("Character updated");
            }
            return Ok();
        }

        /// <summary>
        /// Get <see cref="Character"/> information
        /// </summary>
        /// <param name="Nickname">Nickname in Lost Ark</param>
        /// <returns></returns>
        [HttpGet("{Nickname}")]
        public IActionResult GetCharacter(string Nickname)
        {
            var Character=DataBaseManager.Get<Character>().FirstOrDefault(x=>x.Nickname==Nickname);
            if(Character is null)
                return NotFound($"Character {Nickname} Not Found");
            return Ok(Character);
        }

        [HttpPost]
        public IActionResult PostImage([FromBody] string base64Image, string ImageName,string Type)
        {
            //if (!Validate(GetAPIKey()))
            //    return Unauthorized(new Contract("Unauthorized APIKey"));
            try
            {
                byte[] imageBytes = Convert.FromBase64String(base64Image);

                string savePath = $@"{AppDomain.CurrentDomain.BaseDirectory}\Resources\Images\{Type}\" + ImageName;

                System.IO.File.WriteAllBytes(savePath, imageBytes);
                return Ok("Image uploaded successfully");
            }
            catch(Exception ex)
            {
                return new ObjectResult(ex.Message)
                {
                    StatusCode = (int)HttpStatusCode.InternalServerError
                };
            }
        }

        [HttpGet]
        public IActionResult GetImage(string Type,string ImageName)
        {
            string FilePath = $@"{AppDomain.CurrentDomain.BaseDirectory}\Resources\Images\{Type}\" + ImageName;
            return File();
        }
    }
}
