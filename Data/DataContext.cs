﻿using Microsoft.EntityFrameworkCore;
using officeeatsbackendapi.Models;
using OfficeEatsBackendApi.Models;

namespace officeeatsbackendapi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Users> Users { get; set; }

        public DbSet<Offices> Offices { get; set; }

        public DbSet<Stores> Stores { get; set; }

        public DbSet<Addresses> Addresses { get; set; }

        public DbSet<Categories> Categories { get; set; }

        public DbSet<StoreMenu> StoreMenu { get; set; }

        public DbSet<OrderItem> OrderItem { get; set; }

        public DbSet<Order> Order { get; set; }

        public DbSet<Rate> Rate { get; set; }

        public DbSet<StoreMenuImages> StoreMenuImages { get; set; }

        public DbSet<StoreImages> StoreImages { get; set; }

        public DbSet<DeliveryPartner> DeliveryPartner { get; set; }

        public DbSet<StoreAdmin> StoreAdmin { get; set; }

        public DbSet<QuestionnaireOptions> QuestionnaireOptions { get; set; }

        public DbSet<QuestionnaireTitles> QuestionnaireTitles { get; set; }

        public DbSet<OrderCustomizations> OrderCustomizations { get; set; }

        public DbSet<OrderStatusHistory> OrderStatusHistory { get; set; }
        
    }
}
