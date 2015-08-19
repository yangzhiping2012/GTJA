using GTJA.Common.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace GTJA.MemberManage.DAL
{
    public class MemberDbContext: DbContextBase
    {
        public MemberDbContext()
            : base("MemberConnection")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
           
            Database.SetInitializer<MemberDbContext>(new DropCreateDatabaseWithSeedData());
            //Database.SetInitializer<MemberDbContext>(null);
            ModelBuilderHelper.LoadModel(modelBuilder, "GTJA.MemberManage.Model");

            base.OnModelCreating(modelBuilder);
        }
    }
}
