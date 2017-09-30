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
        public InlineKeyboard()
        {
            inline_keyboard = new List<List<InlineKeyboardButton>>();
        }
        public void AddButton(InlineKeyboardButton button)
        {
            inline_keyboard.Add(new List<InlineKeyboardButton> { button });
        }
        public void AddLine (List <InlineKeyboardButton> key)
        {
            inline_keyboard.Add(key);
        }
        public void AddButton(InlineKeyboardButton button,int n)
        {
            while (inline_keyboard.Count <= n)
               inline_keyboard.Add(new List<InlineKeyboardButton>());
             inline_keyboard[n].Add(button);
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