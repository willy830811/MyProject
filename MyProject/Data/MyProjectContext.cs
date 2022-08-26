﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyProject.Models;
using MyProject.Models.Enum;

namespace MyProject.Data
{
    public class MyProjectContext : DbContext
    {
        public MyProjectContext (DbContextOptions<MyProjectContext> options)
            : base(options)
        {
        }

        public DbSet<MyProject.Models.House> House { get; set; } = default!;

        public DbSet<MyProject.Models.Department>? Department { get; set; }

        public DbSet<MyProject.Models.Owner>? Owner { get; set; }
    }
}
