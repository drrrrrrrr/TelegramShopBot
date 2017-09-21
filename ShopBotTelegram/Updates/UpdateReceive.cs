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
                case "привет": InlineMenu(chat_id); answer = "Пока"; break;
                case "как дела": answer = "Пошел"; break;
                case "пвет": answer = "Покввввва"; break;
                default: answer = "Вы написали какое то дерьмо " + message; break;
            }
            


        }
        void SendMessage(long chat_id, string message,string reply_markup="")
        {
            string address = BaseUrl + token + "/sendMessage";
            NameValueCollection nvc = new NameValueCollection();
            nvc.Add("chat_id", chat_id.ToString());
            nvc.Add("text", message);
            if (reply_markup != "")
                nvc.Add("reply_markup", reply_markup);
            client.UploadValues(address, nvc);

        }
        void MyMenu(long chat_id)
        {
            string address = BaseUrl + token + "/sendMessage";
            NameValueCollection nvc = new NameValueCollection();
            nvc.Add("chat_id", chat_id.ToString());
            nvc.Add("text", "привет");
            List<string> keyboardb1 = new List<string>()
            {
                "Да","Нет"
            };
            List<string> keyboardb2 = new List<string>()
            {
                "Ура","Не Ура"
            };
            List<List<string>> keybord = new List<List<string>>()
            {
                keyboardb1,keyboardb2
            };
            TeleButtons tel = new TeleButtons(keybord);
            string reply_markup = JsonConvert.SerializeObject(tel);
            nvc.Add("reply_markup", reply_markup);
            client.UploadValues(address, nvc);

        }
        void InlineMenu(long chat_id)
        {
 
            InlineKeyboardButton button1 = new InlineKeyboardButton("ya", "ya.ru");
            InlineKeyboardButton button2 = new InlineKeyboardButton("vk", "vk.ru");
            List<InlineKeyboardButton> listInline = new List<InlineKeyboardButton> { button1, button2 };
            List<List<InlineKeyboardButton>> listttInline = new List<List<InlineKeyboardButton>>() { listInline };
            InlineKeyboard kb = new InlineKeyboard(listttInline);
            string reply_markup = JsonConvert.SerializeObject(kb);
            SendMessage(chat_id, "Inline_menu", reply_markup);

        }

    }
}