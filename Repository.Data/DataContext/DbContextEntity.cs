using Data.Entity.Entities;
using Data.Entity.Entities.Qrm;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Data.DataContext
{
    public  partial class ApplicationDbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<PageLocalization> PageLocalization { get; set; }
        public DbSet<Page> Page { get; set; }
        public DbSet<Sections> Sections { get; set; }
        public DbSet<UnitArea> UnitArea { get; set; }
        public DbSet<KaizenCardDetails> KaizenCardDetails { get; set; }
        public DbSet<KaizenCardHeader> KaizenCardHeader { get; set; }
        public DbSet<KaizenCardIssuerDetails> KaizenCardIssuerDetails { get; set; }

        public DbSet<KaizenCardImprovment> KaizenCardImprovment { get; set; }
        public DbSet<A3details> A3details { get; set; }
        public DbSet<A3header> A3header { get; set; }
        public DbSet<ActionsPlan> ActionsPlan { get; set; }
        public DbSet<Statues> Statues { get; set; }
        public DbSet<TeamMembers> TeamMembers { get; set; }
        public DbSet<QrmImprovment> QrmImprovment { get; set; }
        public DbSet<QrmPerformance> QrmPerformance { get; set; }
        public DbSet<QrmHeader> QrmHeader { get; set; }
        public DbSet<QrmTeam> QrmTeam { get; set; }



    }
}
