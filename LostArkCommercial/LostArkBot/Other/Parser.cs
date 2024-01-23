using Microsoft.Extensions.Options;
using PuppeteerSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostArkCommercial.LostArkBot.Other
{
    //нужна проверка на одежду и бижу и гравы


    public static class Parser
    {
        static readonly LaunchOptions options = new LaunchOptions() { Headless = false, DefaultViewport = new ViewPortOptions() { Width = 2000, Height = 5000 } };

        static private IBrowser Browser = null!;

        static async Task<Fetr?> GetFetrAsync(IPage Page)
        {
            var isHavefetr = await Page.EvaluateExpressionAsync<bool>(JSCode.isHaveFetr);
            if (!isHavefetr)
                return null;

            var Fetr = new Fetr();

            var FetrXpath = (await Page.XPathAsync(Xpath.Fetr))[0];

            var FetrBoundingBox = await FetrXpath.BoundingBoxAsync();

            await Page.Mouse.MoveAsync(FetrBoundingBox.X + FetrBoundingBox.Width / 2, FetrBoundingBox.Y + FetrBoundingBox.Height / 2);
            Fetr = await Page.EvaluateExpressionAsync<Fetr>(JSCode.GetFetr);

            return Fetr;
        }

        static async Task<Braclet?> GetBracletAsync(IPage Page)
        {
            var isHaveBraclet = await Page.EvaluateExpressionAsync<bool>(JSCode.isHaveBraclet);
            if (!isHaveBraclet)
                return null;

            var Braclet = new Braclet();

            var BracletXpath = (await Page.XPathAsync(Xpath.Braclet))[0];

            var BracletBoundingBox = await BracletXpath.BoundingBoxAsync();

            await Page.Mouse.MoveAsync(BracletBoundingBox.X + BracletBoundingBox.Width / 2, BracletBoundingBox.Y + BracletBoundingBox.Height / 2);
            Braclet = await Page.EvaluateExpressionAsync<Braclet>(JSCode.GetBracletInfo);

            return Braclet;
        }

        static async Task<Gear> GetWeaponAsync(IPage Page)
        {
            var Weapon = new Gear();

            var GunXpath = (await Page.XPathAsync(Xpath.Gun))[0];

            var GunBoundingBox = await GunXpath.BoundingBoxAsync();

            await Page.Mouse.MoveAsync(GunBoundingBox.X + GunBoundingBox.Width / 2, GunBoundingBox.Y + GunBoundingBox.Height / 2);
            var isEzdo = await Page.EvaluateExpressionAsync<bool>(JSCode.isEzdoGun);
            var isHaveSet = await Page.EvaluateExpressionAsync<bool>(JSCode.isHaveSet);
            if (isEzdo)
                Weapon=await Page.EvaluateExpressionAsync<Gear>(JSCode.GetEzdoGun);
            else
            {
                if (isHaveSet)
                    Weapon = await Page.EvaluateExpressionAsync<Gear>(JSCode.GetInfoSet);
                else
                    Weapon = await Page.EvaluateExpressionAsync<Gear>(JSCode.GetInfoWithoutSet);
            }

            return Weapon;
        }

        static async Task<List<Gear>> GetOtherGear(IPage Page)
        {
            List<Gear> Gears = new();

            List<IElementHandle> ElementsGear = new();
            foreach (var xpath in Xpath.Gear)
                ElementsGear.Add((await Page.XPathAsync(xpath.Value))[0]);

            List<BoundingBox> GearBoundingBoxes = new();
            foreach (var i in ElementsGear)
                GearBoundingBoxes.Add(await i.BoundingBoxAsync());

            foreach (var GBB in GearBoundingBoxes)
            {
                await Page.Mouse.MoveAsync(GBB.X + GBB.Width / 2, GBB.Y + GBB.Height / 2);
                var isHaveSet = await Page.EvaluateExpressionAsync<bool>(JSCode.isHaveSet);
                isHaveSet = await Page.EvaluateExpressionAsync<bool>(JSCode.isHaveSet);
                if (isHaveSet)
                    Gears.Add(await Page.EvaluateExpressionAsync<Gear>(JSCode.GetInfoSet));
                else
                    Gears.Add(await Page.EvaluateExpressionAsync<Gear>(JSCode.GetInfoWithoutSet));
            }
            return Gears;
        }

        static async Task<List<Jewelry>?> GetJewelries(IPage Page)
        {
            var isHave =await Page.EvaluateExpressionAsync<bool>(JSCode.isHaveJewelries);
            if(!isHave)
                return null;

            List<Jewelry> jewelries = new();

            List<IElementHandle> ElementsJewelries = new();
            foreach (var xpath in Xpath.Jewelries)
                ElementsJewelries.Add((await Page.XPathAsync(xpath.Value))[0]);

            List<BoundingBox> JewelriesBoundingBoxes = new();
            foreach (var i in ElementsJewelries)
                JewelriesBoundingBoxes.Add(await i.BoundingBoxAsync());

            foreach (var jew in JewelriesBoundingBoxes)
            {
                await Page.Mouse.MoveAsync(jew.X + jew.Width / 2, jew.Y + jew.Height / 2);
                jewelries.Add(await Page.EvaluateExpressionAsync<Jewelry>(JSCode.GetJewelry));
            }
            return jewelries;
        }

        public static async Task<dynamic?> ParseAsync(string NickName)
        {
            if (Browser == null)
                Browser = await Puppeteer.LaunchAsync(options);
            var Page = await Browser.NewPageAsync();
            await Page.GoToAsync($"https://lostarktree.ru/rating/{NickName}", timeout: 0, waitUntil: new[] { WaitUntilNavigation.Networkidle2 });

            if (await Page.EvaluateExpressionAsync<bool>(JSCode.isNotFound))
            {
                Logging.ConsoleLog("Page Not Found");
                return null;
            }

            var braclet = await GetBracletAsync(Page);
            var jewelries = await GetJewelries(Page);
            var fetr = await GetFetrAsync(Page);
            var weapon = await GetWeaponAsync(Page);
            var othergear = await GetOtherGear(Page);
            await Page.CloseAsync();
            return 2;
        }
    }


    public static class Xpath
    {
        public static string Gun => @"//*[@id=""wrapper""]/div[4]/div[3]/div[3]/div[6]";
        public static Dictionary<string, string> Gear => new Dictionary<string, string> {
            //Головной убор
        {"Helmet","//*[@id=\"wrapper\"]/div[4]/div[3]/div[3]/div[1]"},
            //Наплечник
        {"Scapular","//*[@id=\"wrapper\"]/div[4]/div[3]/div[3]/div[2]"},
            //Доспех
        {"Armor","//*[@id=\"wrapper\"]/div[4]/div[3]/div[3]/div[3]"},
            //Поножи
        {"Greaves","//*[@id=\"wrapper\"]/div[4]/div[3]/div[3]/div[4]"},
            //Перчатки
        {"Gloves","//*[@id=\"wrapper\"]/div[4]/div[3]/div[3]/div[5]"},
    };
        public static Dictionary<string, string> Jewelries => new Dictionary<string, string> {
            //Ожерелье
        {"Necklet","//*[@id=\"wrapper\"]/div[4]/div[3]/div[3]/div[7]"},
            //Сережка
        {"Earring1","//*[@id=\"wrapper\"]/div[4]/div[3]/div[3]/div[8]"},
            //Сережка
        {"Earring2","//*[@id=\"wrapper\"]/div[4]/div[3]/div[3]/div[9]"},
            //Кольцо
        {"Ring1","//*[@id=\"wrapper\"]/div[4]/div[3]/div[3]/div[10]"},
            //Кольцо
        {"Ring2","//*[@id=\"wrapper\"]/div[4]/div[3]/div[3]/div[11]"},
    };
        public static string Braclet => "//*[@id=\"wrapper\"]/div[4]/div[3]/div[3]/div[12]";
        public static string Fetr => "//*[@id=\"wrapper\"]/div[4]/div[3]/div[3]/div[13]";
    }

    public static class JSCode
    {
        public static string isHaveJewelries => @"document.querySelector(""div[class^='equip is-accessories']"")!=null";

        public static string isHaveBraclet => @"document.querySelector(""div[class^='equip is-bracelet']"")!=null";

        public static string isHaveFetr => @"document.querySelector(""div[class^='equip is-ability-stone']"")!=null";

        public static string isNotFound => @"document.querySelector(""div[class='error-msg']"")!=null";

        public static string isEzdoGun => @"(document.querySelector(""div[class='equip is-equip is-slot6']"").getAttribute('data-grade')=='7')";

        public static string isHaveSet => @"Number(document.querySelector(""div[class='equip-tooltip is-equip']"").getAttribute(""data-grade""))>=5";

        public static string GetEzdoGun => @"Array.from(document.querySelectorAll(""div[class^='equip-tooltip ']""))
    .map((t)=>
    ({
        Name:t.children[0].children[0].outerText,
        ImgSource:t.children[1].children[0].children[0].currentSrc,
        GearScore:Number(t.children[1].children[1].childNodes[5].data),
        Quality:Number(t.children[2].children[1].style.width.slice(0,-1)),
        Grade:Number(t.getAttribute(""data-grade"")),
        Level:Number(t.children[0].children[0].outerText.split(' ')[1].slice(0,-1)),
        Effects:{
            BaseName:t.children[3].children[0].children[0].outerText,
            BaseItems:Array.from(document.querySelectorAll(""div[class='equip-tooltip__effect-item']""))
                .filter((o)=>(o.parentNode.className=='equip-tooltip__effect-group equip-tooltip__base-effects'))
                .map(function(params) {
                    return params.outerText
                }),
            AddName:t.children[3].children[1].children[0].outerText,
            AddItems:Array.from(document.querySelectorAll(""div[class='equip-tooltip__effect-item']""))
                .filter((o)=>(o.parentNode.className=='equip-tooltip__effect-group equip-tooltip__add-effects'))
                .map(function(params) {
                    return params.outerText
                }),
        },
        Set:{
            Title:t.children[4].children[0].children[1].outerText.slice(1,-1),
            ItemSetLevel:null,
            EffectsTitle:null,
            EffectsDescriptions:Array.from(document.querySelectorAll(""div[class='equip-tooltip__set-item-desc']"")).map(function(params) {
                    return params.outerText.split(""\n"")
                }),
        },
    }))[0]";

        public static string GetEngraveBuild => @"Array.from(document.querySelectorAll(""div[class^='engrave equip is-engrave'][id]""))
    .map((t)=>
    ({
        Name:t.children[0].children[0].alt,
        Level:Number(t.getAttribute('data-lvl')),
        ImgSource:t.children[0].children[0].src
    }))";

        public static string GetEngravesEquipped => @"Array.from(document.querySelectorAll(""div[class^='equip is-engrave is']""))
    .map((t)=>
    ({
        Name:t.children[0].children[0].getAttribute(""alt""),
        ImgSource:t.children[0].children[0].src,
        Level:Number(t.children[1].innerText.slice(1,3))
    }))";

        public static string GetServer => @"Array.from(document.querySelectorAll(""div[class^='game_info__server']""))
    .map(function(params) {
        return params.children[1].outerText
    })[0]";

        public static string GetAvgGearScore => @"Array.from(document.querySelectorAll(""div[class^='level_info__item gs']""))
    .map(function(params) {
        return Number(params.children[1].childNodes[1].data)
    })[0]";

        public static string GetTopList => @"Array.from(document.querySelectorAll(""tr[aria-label]""))
    .map((t)=>
    ({
        Id: t['id'],
        Nickname:t.getAttribute('aria-label'),
        GearScore:t.children.item(4).children.item(0).childNodes[0].nodeValue,
        ServerName:t.children.item(3).children.item(0).childNodes[0].nodeValue,
        _LastDate:t.children.item(5).children.item(0).childNodes[0].nodeValue,
        ClassName:t.children.item(2).children.item(0).childNodes[0].nodeValue,
    }))";

        public static string GetCharacteristics => @"Array.from(document.querySelectorAll(""div[class^='profile-character-stats__item']""))
    .map((t)=>
    ({
        Key:t.children[0].innerText,
        Value:Number(t.children[1].innerText)
    }))";

        public static string GetLevel = @"Array.from(document.querySelectorAll(""div[class^='game_info__lvl']""))
    .map((t)=>
    ({
        Level:Number(t.children[1].childNodes.item(1).data.split(' ')[0]),
        Legacy:Number(t.children[1].childNodes.item(3).data.split(' ')[0].slice(0,3)),
    }))";

        public static string Get_Class_Title_PvPrank_Guildname => @"Array.from(document.querySelectorAll(""div[class^='game_info__class']""))
    .map((t)=>
    ({
        Key:t.children[0].outerText,
        Value:t.children[1].outerText
    }))";

        public static string GetCards => @"Array.from(document.querySelectorAll(""div[class^='profile-character-cards__item profile-character-card']""))
    .map((t)=>
    ({
        ImgSource:t.children[0].children[0].currentSrc,
        Name:t.children[1].outerText,
        AwakeCount:t.querySelectorAll(""div[class='profile-character-card__awake-item ']"").length,
        maxAwake:t.querySelectorAll(""div[class^='profile-character-card__awake-item ']"").length,
    }))";

        public static string GetBracletInfo => @"Array.from(document.querySelectorAll(""div[class^='equip-tooltip ']""))
    .map((t)=>
    ({
        Name:t.children[0].children[0].outerText,
        ImgSource:t.children[1].children[0].children[0].currentSrc,
        Grade:Number(t.getAttribute(""data-grade"")),
        Effects:{
            
            BaseItems:Array.from(document.querySelectorAll(""div[class='equip-tooltip__effect-item']""))
                .filter((o)=>(o.parentNode.className=='equip-tooltip__effect-group equip-tooltip__bracelet-effects'))
                .map(function(params) {
                    return params.outerText
                }),
        }
    }))[0]";

        public static string GetInfoSet => @"Array.from(document.querySelectorAll(""div[class^='equip-tooltip ']""))
    .map((t)=>
    ({
        Name:t.children[0].children[0].outerText,
        ImgSource:t.children[1].children[0].children[0].currentSrc,
        GearScore:Number(t.children[1].children[1].childNodes[5].data),
        Quality:Number(t.children[2].children[1].style.width.slice(0,-1)),
        Grade:Number(t.getAttribute(""data-grade"")),
        Level:Number(t.children[0].children[0].outerText.split(' ')[1].slice(0,-1)),
        Effects:{
            BaseName:t.children[3].children[0].children[0].outerText,
            BaseItems:Array.from(document.querySelectorAll(""div[class='equip-tooltip__effect-item']""))
                .filter((o)=>(o.parentNode.className=='equip-tooltip__effect-group equip-tooltip__base-effects'))
                .map(function(params) {
                    return params.outerText
                }),
            AddName:t.children[3].children[1].children[0].outerText,
            AddItems:Array.from(document.querySelectorAll(""div[class='equip-tooltip__effect-item']""))
                .filter((o)=>(o.parentNode.className=='equip-tooltip__effect-group equip-tooltip__add-effects'))
                .map(function(params) {
                    return params.outerText
                }),
        },
        Set:{
            Title:t.children[4].children[0].children[0].outerText,
            ItemSetLevel:Number(t.children[4].children[0].childNodes[3].data),
            EffectsTitle:Array.from(document.querySelectorAll(""div[class='equip-tooltip__set-item-title']"")).map((title)=>({
                Count:Number(title.children[0].children[0].childNodes[0].data.split('(')[1][0]),
                Level:Number(title.children[0].children[0].children[1].children[0].children[0].innerText.split(' ')[1])
            })),
            EffectsDescriptions:Array.from(document.querySelectorAll(""div[class='equip-tooltip__set-item-desc']"")).map(function(params) {
                    return params.children[0].children[0].innerText
                }),
        },
    }))[0]";

        public static string GetInfoWithoutSet => @"Array.from(document.querySelectorAll(""div[class^='equip-tooltip ']""))
    .map((t)=>
    ({
        Name:t.children[0].children[0].outerText,
        ImgSource:t.children[1].children[0].children[0].currentSrc,
        GearScore:Number(t.children[1].children[1].childNodes[5].data),
        Quality:Number(t.children[2].children[1].style.width.slice(0,2)),
        Grade:Number(t.getAttribute(""data-grade"")),
        Level:Number(t.children[0].children[0].outerText.split(' ')[1].slice(0,-1)),
        Effects:{
            BaseName:t.children[3].children[0].children[0].outerText,
            BaseItems:Array.from(document.querySelectorAll(""div[class='equip-tooltip__effect-item']""))
                .filter((o)=>(o.parentNode.className=='equip-tooltip__effect-group equip-tooltip__base-effects'))
                .map(function(params) {
                    return params.outerText
                }),
            AddName:t.children[3].children[1].children[0].outerText,
            AddItems:Array.from(document.querySelectorAll(""div[class='equip-tooltip__effect-item']""))
                .filter((o)=>(o.parentNode.className=='equip-tooltip__effect-group equip-tooltip__add-effects'))
                .map(function(params) {
                    return params.outerText
                }),
        }
    }))[0]";

        public static string GetJewelry => @"Array.from(document.querySelectorAll(""div[class^='equip-tooltip ']""))
    .map((t)=>
    ({
        Name:t.children[0].children[0].outerText,
        ImgSource:t.children[1].children[0].children[0].currentSrc,
        Quality:Number(t.children[2].children[1].style.width.slice(0,2)),
        Grade:Number(t.getAttribute(""data-grade"")),
        Effects:{
            BaseEffectName:t.children[3].children[0].children[0].outerText,
            BaseEffectItems:Array.from(document.querySelectorAll(""div[class='equip-tooltip__effect-item']""))
                .filter((o)=>(o.parentNode.className=='equip-tooltip__effect-group equip-tooltip__base-effects'))
                .map(function(params) {
                    return params.outerText
                }),
            AddEffectName:t.children[3].children[1].children[0].outerText,
            AddEffectItems:Array.from(document.querySelectorAll(""div[class='equip-tooltip__effect-item']""))
                .filter((o)=>(o.parentNode.className=='equip-tooltip__effect-group equip-tooltip__add-effects'))
                .map(function(params) {
                    return params.outerText
                }),
        },
        Engraves:Array.from(document.querySelectorAll(""div[class='engrave equip is-engrave']""))
                .filter((o)=>(o.parentNode.className=='equip-tooltip__effect-item'))
                .map((engrave)=>({
                    isNegative:engrave.getAttribute(""data-penalty"")==1,
                    ImgSource:engrave.children[0].children[0].currentSrc,
                    Name:engrave.children[1].childNodes[0].data.split(' ')[0],
                    Level:Number(engrave.children[1].childNodes[0].data.split(' ')[1].slice(1,2)),
            })),
    }))[0]";

        public static string GetFetr => @"Array.from(document.querySelectorAll(""div[class^='equip-tooltip ']""))
    .map((t)=>
    ({
        Name:t.children[0].children[0].outerText,
        ImgSource:t.children[1].children[0].children[0].currentSrc,
        Grade:Number(t.getAttribute(""data-grade"")),
        Effects:{
            BaseName:t.children[2].children[0].children[0].outerText,
            BaseItems:Array.from(document.querySelectorAll(""div[class='equip-tooltip__effect-item']""))
                .filter((o)=>(o.parentNode.className=='equip-tooltip__effect-group equip-tooltip__base-effects'))
                .map(function(params) {
                    return params.outerText
                }),
            AddName:t.children[2].children[1].children[0].outerText,
            AddItems:Array.from(document.querySelectorAll(""div[class='equip-tooltip__effect-item']""))
                .filter((o)=>(o.parentNode.className=='equip-tooltip__effect-group equip-tooltip__ability-stone-effects'))
                .map(function(params) {
                    return params.outerText
                }),
        },
        Engraves:Array.from(document.querySelectorAll(""div[class='engrave equip is-engrave']""))
                .filter((o)=>(o.parentNode.className=='equip-tooltip__effect-item'))
                .map((engrave)=>({
                    isNegative:engrave.getAttribute(""data-penalty"")==1,
                    ImgSource:engrave.children[0].children[0].currentSrc,
                    Name:engrave.children[1].childNodes[0].data.split(' ').splice(0,engrave.children[1].childNodes[0].data.split(' ').length-1).join(' '),
                    Level:Number(engrave.children[1].childNodes[0].data.split(' ').pop().slice(1)),
            })),
    }))[0]";

        public static string GetCardSets => @"Array.from(document.querySelectorAll(""div[class='profile-character-cards__effect']"")).map((t)=>
            ({
                Title:t.children[0].outerText,
                Description:t.children[1].outerText
            }))";

        public static string GetProfileCollections => @"Array.from(document.querySelectorAll(""div[class^='profile-character-collections__item']""))
    .map((t)=>
    ({
        Name:t.children[0].src.split('/').pop().split('.')[0],
        ImgSource:t.children[0].src,
        Count:Number(t.children[1].innerText.replace("","",""""))
    }))";

        public static string GetSkillBuild => @"Array.from(document.querySelectorAll(""div[class^='profile-character-skills__skill'][data-id]""))
    .map((t)=>
    ({
            Level:Number(t.children[0].children[0].innerText),
            ImgSource:t.children[0].children[1].src,
            SelectedTripodes:t.children[1].children[0].outerText.slice(1,4).split('').map(str=>Number(str)),
            Tripodes:Array.from(t.querySelectorAll(""div[class='profile-character-skills__tripode']"")).map((tripode)=>({
                ImgSource:tripode.children[0].src,
                Level:Number(tripode.children[1].childNodes.item(1).data),
            })),
        
            Rune:Array.from(t.querySelectorAll(""div[class='rune rune-list__item js-rune-tooltip']"")).map((rune)=>({
                ImgSource:rune.children[0].children[0].src,
                Name:rune.children[0].children[0].alt,
                Level:Number(rune.getAttribute('data-grade'))
        }))[0],
            Gems:Array.from(t.querySelectorAll(""div[class='rune rune-list__item js-jew-tooltip']"")).map((jewel)=>({
                ImgSource:jewel.children[0].children[0].src,
                Type:jewel.children[1].innerText.split(' ')[0],
                Level:Number(jewel.children[1].innerText.split(' ')[1].split('.')[1]),
                Description:jewel.children[2].outerText,
        }))
    }))";
    }

    public class BracletEffects
    {
        public List<string> BaseItems { get; set; } = null!;
    }

    public class Effects : BracletEffects
    {
        public string BaseName { get; set; } = null!;
        public string AddName { get; set; } = null!;
        public List<string> AddItems { get; set; } = null!;
    }

    public class Item
    {
        public override string ToString()
        {
            return Name;
        }
        public string Name { get; set; } = null!;
        public string ImgSource { get; set; } = null!;
        public int Grade { get; set; }
    }

    public class Braclet : Item
    {
        public BracletEffects Effects { get; set; } = null!;
    }

    public class Gear : Item
    {
        public int GearScore { get; set; }
        public int Quality { get; set; }
        public int Level { get; set; }
        public virtual Set? Set { get; set; }
        public Effects Effects { get; set; } = null!;
    }

    public class Jewelry : Fetr
    {
        public int Quality { get; set; }
    }
    public class Fetr : Item
    {
        public List<Engrave> Engraves { get; set; } = null!;
        public Effects Effects { get; set; } = null!;
    }
    public class EffectsTitle
    {
        public int Count { get; set; }
        public int Level { get; set; }
    }

    public class Set
    {
        public override string ToString()
        {
            return Title;
        }
        public string Title { get; set; } = null!;
        public int ItemSetLevel { get; set; }
        public List<EffectsTitle> EffectsTitle { get; set; } = null!;
        public List<string> EffectsDescriptions { get; set; } = null!;
    }


    public class Engrave
    {
        public override string ToString()
        {
            return Name;
        }
        public bool isNegative { get; set; }
        public string ImgSource { get; set; } = null!;
        public string Name { get; set; } = null!;
        public int Level { get; set; }
    }
}