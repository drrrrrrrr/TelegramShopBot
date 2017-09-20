using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ShopBotTelegram.Updates
{
    public class LastUpDate
    {
        public int Id{ get; set; }
        public long Lastupdate { get; set; }
    }
    public class UpdateDbContext:DbContext
    {
        public DbSet<LastUpDate> LastUpDates { get; set; }
    }
}