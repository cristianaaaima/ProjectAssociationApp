using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SEProjectApp.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEProjectApp.DataAccess
{
    public class AssociationContext: DbContext
    {
        public AssociationContext(DbContextOptions options) : base(options)
        { 
        }

        public DbSet<Apartment> Apartment { get; set; }

        public DbSet<Building> Building { get; set; }

        public DbSet<Invoice> Invoice { get; set; }

        public DbSet<Furnisor> Furnisor { get; set; }

    }
}
