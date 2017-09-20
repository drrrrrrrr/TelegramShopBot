using Newtonsoft.Json;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;

namespace ShopBotTelegram.Updates
{
    public class UpdateReceive : IJob
    {
        string token = "423465971:AAHkZ5F-bf0XcLBCFELiLabrfxFQreQk_MA";
        string BaseUrl = "https://api.telegram.org/bot";
        WebClient client = new WebClient();
        long LastUpdate = 0;
        UpdateDbContext db = new UpdateDbContext();
        public void Execute(IJobExecutionContext context)
        {
            LastUpdate = long.Parse(db.LastUpDates.ToArray()[0].Lastupdate);
            string addres = BaseUrl + token + "/getUpdates?offset="+(LastUpdate+1);
            string res = client.DownloadString(addres);
            var k = JsonConvert.DeserializeObject<TelegramUpdate>(res);
            if (!k.ok)
                return;
            foreach(Result item in k.result)
            {
                string f = "asdfasd";

                db.LastUpDates.ToArray()[0].Lastupdate = (long.Parse(db.LastUpDates.ToArray()[0].Lastupdate) + 1).ToString() ;
            }
            
        }
    }
}