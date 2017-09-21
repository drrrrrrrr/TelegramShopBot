using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopBotTelegram.Updates
{
    public class InlineKeyboard
    {
        public List<List<InlineKeyboardButton>> inline_keyboard{ get; set; }
        public InlineKeyboard(List<List<InlineKeyboardButton>> inline)
        {
            inline_keyboard = inline;
        }

    }
    public class InlineKeyboardButton
    {
        public string text { get; set; }
   //     public string url { get; set; }
        public string callback_data { get; set; }
        public InlineKeyboardButton(string _text,string _callback_data="")
        {
            text = _text;
            callback_data = _callback_data == "" ? _text : _callback_data;
        }
    }
}