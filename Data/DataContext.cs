﻿using Microsoft.EntityFrameworkCore;
using officeeatsbackendapi.Models;

namespace officeeatsbackendapi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Users> Users { get; set; }

    }
}
