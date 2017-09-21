using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopBotTelegram.Updates
{
    public class TeleButtons
    {
       public bool on_time_keyboard { get; set; }
       public List<List<string>> keyboard { get; set; }
       public TeleButtons(List<List<string>> keyboard,bool on_time=true)
       {
            this.keyboard = keyboard;
            on_time_keyboard = on_time;
       }

    }
   
}