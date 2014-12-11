using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Web;

namespace UserRatingService.Repository
{
    public class DataContext : DbContext
    {
        public DbSet<User> Users { get; set; } 

        public DataContext()
            : base("name=DataContext")
        {
        }

        public DataContext(string connString)
            : base(connString)
        {
            
        }
    }
}