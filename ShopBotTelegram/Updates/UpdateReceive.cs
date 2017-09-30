using Newtonsoft.Json;
using Quartz;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Web;
using System.Data.Entity;
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
          //  var kzz = bd.Categorys.ToArray();
            if (!k.ok || k.result.Length == 0)
                return;
            foreach (Result item in k.result)
            {
                lastUpdate = item.update_id;
                //   item.call_back.
                if (item.message != null)
                    SendAnswer(item.message.chat.id, item.message.text);
                if (item.callback_query != null)
                    AnswerIqQuery(item);    
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
            string reply_markup = "";
            switch (message)
            {
                case @"/start": answer = MainMenu(out reply_markup); break;
                default: answer = "Я не знаю как ответить на  " + message; MainMenu(out reply_markup); break;
            }
            if (reply_markup != "")
                SendMessage(chat_id, answer, reply_markup);
            else
                SendMessage(chat_id, answer);

        }

        private string MainMenu(out string reply_markup)
        {
            List<Category> categories;
            List<InlineKeyboardButton> kb = new List<InlineKeyboardButton>();
            using (UpdateDbContext db = new UpdateDbContext())
            {
               categories = db.Categorys.ToList();
            }
            InlineKeyboard keyboard = new InlineKeyboard();
            int i = 0;
            foreach (var item in categories)
            {
                keyboard.AddButton(new InlineKeyboardButton(item.NameCategory, item.NameCategory),i++/2);
            }
            AddMainButton(keyboard);
            reply_markup = JsonConvert.SerializeObject(keyboard);
            return "Все категории магазина";
        }

        void AnswerIsMessage(Result item)
        {
       
     //   SendMessage(item.message.chat.id, answer); ;
        }
        void AnswerIqQuery(Result item)
        {
            //   SendMessage(item.callback_query.from.id, "Здарова");
            //MenuFrombd(item.callback_query.from.id);
            // ChangeMessage(item);

            string answer = "";
            string replyMarkup = "";
            switch(item.callback_query.data)
            {
                case "?": answer = "Вопрос в лс";MainMenu(out replyMarkup); break;
                case "about": answer = "Уэто магазин";MainMenu(out replyMarkup); break;
                default:
                    answer = Shop (item.callback_query.data,out replyMarkup);
                        break;
            }
            answer += Environment.NewLine + item.callback_query.data;
            ChangeMessage(item, answer, replyMarkup);
        }
        string Shop(string shop , out string reply_markup)
        {
            string answer = "Магазин продуктов" ;
            reply_markup = "";
            Category categories;
            char[] spl = { ' ' };
            string[] shops = shop.Split(spl,StringSplitOptions.RemoveEmptyEntries);
            string ncat = shops[0];
            string nproduct="q";
            if (shops.Length>1)
            nproduct = shops[1];
            Product pr=new Product();
            List<InlineKeyboardButton> kb = new List<InlineKeyboardButton>();
            using (UpdateDbContext db = new UpdateDbContext())
            {
                if (shops.Length == 1)
                {
                    var product = db.Products.ToList();
                    categories = db.Categorys.Where(x => x.NameCategory == ncat).First();
                }
                else
                {
                    var product = db.Products.ToList();
                    //categories = db.Categorys.Where(x => x.NameCategory == ncat).First();
                    categories = db.Categorys.Where(x => x.NameCategory == ncat).First();
                    pr = categories.Products.Where(x => x.NameProduct == nproduct).First();
                }
            }
            InlineKeyboard keyboard = new InlineKeyboard();
            int i = 0;
            if (shops.Length == 1)
            {
                foreach (var item in categories.Products)
                {
                    keyboard.AddButton(new InlineKeyboardButton(item.NameProduct,item.Category.NameCategory+" "+item.NameProduct), i++ / 2);
                }
            }
            if(shops.Length>1)
            {
                foreach (var item in categories.Products)
                {
                    keyboard.AddButton(new InlineKeyboardButton(item.NameProduct, item.Category.NameCategory + " " + item.NameProduct), i++ / 2);
                }
                answer = pr.NameProduct +"    " + pr.Price +"   " + pr.Description;
            }
            AddMainButton(keyboard);
            reply_markup = JsonConvert.SerializeObject(keyboard);
          

            return answer;
        }
        void AddMainButton(InlineKeyboard keyboard)
        {
            List<InlineKeyboardButton> line = new List<InlineKeyboardButton>()
            {
                new InlineKeyboardButton("Есть вопрос","?"),
                new InlineKeyboardButton("О нас","about")
            };
            keyboard.AddLine(line);


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
        void ChangeMessage(Result item,string message,string reply_markup="")
        {
            string adress = BaseUrl + token + "/editMessageText";
            NameValueCollection nvc = new NameValueCollection();
            nvc.Add("chat_id", item.callback_query.message.chat.id.ToString());
            nvc.Add("message_id", item.callback_query.message.message_id.ToString());
            nvc.Add("text", message);
            if (reply_markup != "")
                nvc.Add("reply_markup", reply_markup);
           client.UploadValues(adress, nvc);

        }

    }
}