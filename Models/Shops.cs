﻿namespace officeeatsbackendapi.Models
{
    public class Shops
    {
        public int Id { get; set; }

        public string ShopName { get; set; }

        public int OfficeId { get; set; }

        public StoreImages StoreImages { get; set; }

    }
}
