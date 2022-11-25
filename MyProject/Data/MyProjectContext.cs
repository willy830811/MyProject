using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyProject.Models;
using MyProject.Models.Items;

namespace MyProject.Data
{
    public class MyProjectContext : DbContext
    {
        public MyProjectContext (DbContextOptions<MyProjectContext> options)
            : base(options)
        {
        }

        public DbSet<House> House { get; set; } = default!;

        public DbSet<Department>? Department { get; set; }

        public DbSet<Owner>? Owner { get; set; }

        public DbSet<HouseUser>? HouseUser { get; set; }

        public DbSet<Property>? Property { get; set; }

        public DbSet<RealEstateDetail> RealEstateDetail { get; set; }

        public DbSet<CaseSource> CaseSource { get; set; }

        public DbSet<AppendixItem> AppendixItem { get; set; }

        public DbSet<RealEstateDetailAppendixItem> RealEstateDetailAppendixItem { get; set; }
    }
}
