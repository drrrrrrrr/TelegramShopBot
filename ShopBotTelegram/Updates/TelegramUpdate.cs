using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopBotTelegram.Updates
{//"last_name":"Rudoy","language_code":"ru"},"message":{"message_id":3960,"from":{"id":423465971,"is_bot":true,"first_name":"testTsesa","username":"tetristres_bot"},"chat":{"id":378999844,"first_name":"Dima","last_name":"Rudoy","type":"private"},"date":1506075314,"text":"Inline_menu"},"chat_instance":"-886745467697944370","data":"ya.ru"}},{"update_id":632794789,n"callback_query":{"id":"1627791936639219697","from":{"id":378999844,"is_bot":false,"first_name":"Dima","last_name":"Rudoy","language_code":"ru"},"message":{"message_id":3960,"from":{"id":423465971,"is_bot":true,"first_name":"testTsesa","username":"tetristres_bot"},"chat":{"id":378999844,"first_name":"Dima","last_name":"Rudoy","type":"private"},"date":1506075314,"text":"Inline_menu"},"chat_instance":"-886745467697944370","data":"ya.ru"}},{"update_id":632794790,n"callback_query":{"id":"1627791935982818804","from":{"id":378999844,"is_bot":false,"first_name":"Dima","last_name":"Rudoy","language_code":"ru"},"message":{"message_id":3960,"from":{"id":423465971,"is_bot":true,"first_name":"testTsesa","username":"tetristres_bot"},"chat":{"id":378999844,"first_name":"Dima","last_name":"Rudoy","type":"private"},"date":1506075314,"text":"Inline_menu"},"chat_instance":"-886745467697944370","data":"ya.ru"}},{"update_id":632794791,n"callback_query":{"id":"1627791936814053568","from":{"id":378999844,"is_bot":false,"first_name":"Dima","last_name":"Rudoy","language_code":"ru"},"message":{"message_id":3960,"from":{"id":423465971,"is_bot":true,"first_name":"testTsesa","username":"tetristres_bot"},"chat":{"id":378999844,"first_name":"Dima","last_name":"Rudoy","type":"private"},"date":1506075314,"text":"Inline_menu"},"chat_instance":"-886745467697944370","data":"vk.ru"}},{"update_id":632794792,n"callback_query":{"id":"1627791936988815978","from":{"id":378999844,"is_bot":false,"first_name":"Dima","last_name":"Rudoy","language_code":"ru"},"message":{"message_id":3960,"from":{"id":423465971,"is_bot":true,"first_name":"testTsesa","username":"tetristres_bot"},"chat":{"id":378999844,"first_name":"Dima","last_name":"Rudoy","type":"private"},"date":1506075314,"text":"Inline_menu"},"chat_instance":"-886745467697944370","data":"ya.ru"}}}"
 //{"ok":tr
    



    public class Callback_Query
    {
        public string id { get; set; }
        public From from { get; set; }
        public Message message { get; set; }
        public string chat_instance { get; set; }
        public string data { get; set; }
    }

    public class From
    {
        public int id { get; set; }
        public bool is_bot { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string language_code { get; set; }
    }

    public class Message
    {
        public int message_id { get; set; }
        public From1 from { get; set; }
        public Chat chat { get; set; }
        public int date { get; set; }
        public string text { get; set; }
    }

    public class From1
    {
        public int id { get; set; }
        public bool is_bot { get; set; }
        public string first_name { get; set; }
        public string username { get; set; }
    }

    public class Chat
    {
        public int id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string type { get; set; }
    }
//essage":{"message_id":3960,"from":{"id":423465971,"is_bot":true,"first_name":"testTsesa","username":"tetristres_bot"},"chat":{"id":378999844,"first_name":"Dima","last_name":"Rudoy","type":"private"},"date":1506075314,"text":"Inline_menu"},"chat_instance":"-886745467697944370","data":"ya.ru"}},{"update_id":632794797,"callback_query":{"id":"1627791939087566028","from":{"id":378999844,"is_bot":false,"first_name":"Dima","last_name":"Rudoy","language_code":"ru"},"message":{"message_id":3960,"from":{"id":423465971,"is_bot":true,"first_name":"testTsesa","username":"tetristres_bot"},"chat":{"id":378999844,"first_name":"Dima","last_name":"Rudoy","type":"private"},"date":1506075314,"text":"Inline_menu"},"chat_instance":"-886745467697944370","data":"ya.ru"}},{"update_id":632794798,"callback_query":{"id":"1627791937509015486","from":{"id":378999844,"is_bot":false,"first_name":"Dima","last_name":"Rudoy","language_code":"ru"},"message":{"message_id":3960,"from":{"id":423465971,"is_bot":true,"first_name":"testTsesa","username":"tetristres_bot"},"chat":{"id":378999844,"first_name":"Dima","last_name":"Rudoy","type":"private"},"date":1506075314,"text":"Inline_menu"},"chat_instance":"-886745467697944370","data":"ya.ru"}},{"update_id":632794799,"callback_query":{"id":"1627791937486754414","from":{"id":378999844,"is_bot":false,"first_name":"Dima","last_name":"Rudoy","language_code":"ru"},"message":{"message_id":3960,"from":{"id":423465971,"is_bot":true,"first_name":"testTsesa","username":"tetristres_bot"},"chat":{"id":378999844,"first_name":"Dima","last_name":"Rudoy","type":"private"},"date":1506075314,"text":"Inline_menu"},"chat_instance":"-886745467697944370","data":"ya.ru"}}]}
    public class Result
{
    public int update_id { get; set; }
    public Message message { get; set; }
    public Callback_Query callback_query { get; set; }

}



public class TelegramUpdate
{
    public bool ok { get; set; }
    public Result[] result { get; set; }

}
}