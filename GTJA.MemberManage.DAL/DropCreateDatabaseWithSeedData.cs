using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Text;
using GTJA.MemberManage.Model;
using GTJA.MemberManage.Model.Map;

namespace GTJA.MemberManage.DAL
{
    public class DropCreateDatabaseWithSeedData : CreateDatabaseIfNotExists<MemberDbContext>
    {
        protected override void Seed(MemberDbContext context)
        {
            Station station = new Station();
            station.ID = Guid.NewGuid().ToString();
            station.Name = "国泰君安四川分公司";
            context.Set<Station>().Add(station);

            context.SaveChanges();

            base.Seed(context);
        }
    }
}
