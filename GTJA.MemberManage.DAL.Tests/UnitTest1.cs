using System;
using System.Linq;
using GTJA.MemberManage.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GTJA.MemberManage.DAL.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            using ( var da = MemberDbProvider.GetDbContext())
            {
                var list = da.All<Member>().ToList();
            }
        }
    }
}
