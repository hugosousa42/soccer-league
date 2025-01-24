﻿using SoccerLeagueLibrary.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace SoccerLeagueWeb.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Club> Clubs { get; set; }
    }
}