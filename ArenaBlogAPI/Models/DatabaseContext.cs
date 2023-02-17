using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ArenaBlogAPI.Models
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Users> Users { get; set; }
        public DbSet<Articles> Articles { get; set; }
        public DbSet<Contacts> Contacts { get; set; }


    }
}