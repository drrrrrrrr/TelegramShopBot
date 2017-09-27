using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ShopBotTelegram.Updates;
using System.Data.Entity;

namespace ShopBotTelegram.Updates
{//"{\"ok\":true,\"result\":[{\"update_id\":632794788,\n\"callback_query\":{\"id\":\"1627791936277457802\",\"from\":{\"id\":378999844,\"is_bot\":false,\"first_name\":\"Dima\",\"last_name\":\"Rudoy\",\"language_code\":\"ru\"},\"message\":{\"message_id\":3960,\"from\":{\"id\":423465971,\"is_bot\":true,\"first_name\":\"testTsesa\",\"username\":\"tetristres_bot\"},\"chat\":{\"id\":378999844,\"first_name\":\"Dima\",\"last_name\":\"Rudoy\",\"type\":\"private\"},\"date\":1506075314,\"text\":\"Inline_menu\"},\"chat_instance\":\"-886745467697944370\",\"data\":\"ya.ru\"}},{\"update_id\":632794789,\n\"callback_query\":{\"id\":\"1627791936639219697\",\"from\":{\"id\":378999844,\"is_bot\":false,\"first_name\":\"Dima\",\"last_name\":\"Rudoy\",\"language_code\":\"ru\"},\"message\":{\"message_id\":3960,\"from\":{\"id\":423465971,\"is_bot\":true,\"first_name\":\"testTsesa\",\"username\":\"tetristres_bot\"},\"chat\":{\"id\":378999844,\"first_name\":\"Dima\",\"last_name\":\"Rudoy\",\"type\":\"private\"},\"date\":1506075314,\"text\":\"Inline_menu\"},\"chat_instance\":\"-886745467697944370\",\"data\":\"ya.ru\"}},{\"update_id\":632794790,\n\"callback_query\":{\"id\":\"1627791935982818804\",\"from\":{\"id\":378999844,\"is_bot\":false,\"first_name\":\"Dima\",\"last_name\":\"Rudoy\",\"language_code\":\"ru\"},\"message\":{\"message_id\":3960,\"from\":{\"id\":423465971,\"is_bot\":true,\"first_name\":\"testTsesa\",\"username\":\"tetristres_bot\"},\"chat\":{\"id\":378999844,\"first_name\":\"Dima\",\"last_name\":\"Rudoy\",\"type\":\"private\"},\"date\":1506075314,\"text\":\"Inline_menu\"},\"chat_instance\":\"-886745467697944370\",\"data\":\"ya.ru\"}},{\"update_id\":632794791,\n\"callback_query\":{\"id\":\"1627791936814053568\",\"from\":{\"id\":378999844,\"is_bot\":false,\"first_name\":\"Dima\",\"last_name\":\"Rudoy\",\"language_code\":\"ru\"},\"message\":{\"message_id\":3960,\"from\":{\"id\":423465971,\"is_bot\":true,\"first_name\":\"testTsesa\",\"username\":\"tetristres_bot\"},\"chat\":{\"id\":378999844,\"first_name\":\"Dima\",\"last_name\":\"Rudoy\",\"type\":\"private\"},\"date\":1506075314,\"text\":\"Inline_menu\"},\"chat_instance\":\"-886745467697944370\",\"data\":\"vk.ru\"}},{\"update_id\":632794792,\n\"callback_query\":{\"id\":\"1627791936988815978\",\"from\":{\"id\":378999844,\"is_bot\":false,\"first_name\":\"Dima\",\"last_name\":\"Rudoy\",\"language_code\":\"ru\"},\"message\":{\"message_id\":3960,\"from\":{\"id\":423465971,\"is_bot\":true,\"first_name\":\"testTsesa\",\"username\":\"tetristres_bot\"},\"chat\":{\"id\":378999844,\"first_name\":\"Dima\",\"last_name\":\"Rudoy\",\"type\":\"private\"},\"date\":1506075314,\"text\":\"Inline_menu\"},\"chat_instance\":\"-886745467697944370\",\"data\":\"ya.ru\"}}]}"


    public class LastUpDate
    {
        public int Id { get; set; }
        public long Lastupdate { get; set; }
        
    }
    public class UpdateDbContext:DbContext
    {
        public DbSet<LastUpDate> LastUpDates { get; set; }
        public DbSet<Category> Categorys { get; set; }
        public DbSet<Product> Products { get; set; }


    }
    public class Category
    {
        public int Id { get; set; }
        public string NameCategory { get; set; }
        public  ICollection<Product> Products { get; set; }

        public Category()
        {
           
       
            Products = new List<Product>();
        
    }
        
    }
    public class Product
    {
        public int Id { get; set; }
        public string NameProduct { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}