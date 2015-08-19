using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using GTJA.Common.Data;

namespace GTJA.SystemManage.DAL
{
    public class SysDbContext : DbContextBase
    {
        public SysDbContext()
            : base("SystemConnection")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Database.SetInitializer<SysDbContext>(null);
            Database.SetInitializer<SysDbContext>(new DropCreateDatabaseWithSeedData());

            ModelBuilderHelper.LoadModel(modelBuilder, "GTJA.SystemManage.Model");

            base.OnModelCreating(modelBuilder);
        }
    }
}
