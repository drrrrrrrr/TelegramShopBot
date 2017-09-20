using Newtonsoft.Json;
using Quartz;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
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
        UpdateDbContext bd = new UpdateDbContext();
     
        public void Execute(IJobExecutionContext context)
        {
            long lastUpdate = bd.LastUpDates.First().Lastupdate;
            string addres = BaseUrl + token + "/getUpdates?offset=" + (lastUpdate + 1);
            string res = client.DownloadString(addres);
            var k = JsonConvert.DeserializeObject<TelegramUpdate>(res);
            if (!k.ok || k.result.Length == 0)
                return;
            foreach (Result item in k.result)
            {
                lastUpdate = item.update_id;
                SendAnswer(item.message.chat.id, item.message.text);
            }
            using (UpdateDbContext bd = new UpdateDbContext())
            {
                bd.LastUpDates.First().Lastupdate = lastUpdate;
                bd.SaveChanges();
            }
          

        }
        void SendAnswer(long chat_id, string message)
        {
            string answer = "";
            switch (message)
            {
                case "привет": answer = "Пока"; break;
                case "как дела": answer = "Пошел"; break;
                case "пвет": answer = "Покввввва"; break;
                default: answer = "Вы написали какое то дерьмо " + message; break;
            }
            SendMessage(chat_id, answer);


        }
        void SendMessage(long chat_id, string message)
        {
            string address = BaseUrl + token + "/sendMessage";
            NameValueCollection nvc = new NameValueCollection();
            nvc.Add("chat_id", chat_id.ToString());
            nvc.Add("text", message);
            client.UploadValues(address, nvc);

        }

    }
}