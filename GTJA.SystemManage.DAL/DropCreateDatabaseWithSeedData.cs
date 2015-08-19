using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using GTJA.SystemManage.Model;
using GTJA.SystemManage.Model.Domain;

namespace GTJA.SystemManage.DAL
{
    public class DropCreateDatabaseWithSeedData : CreateDatabaseIfNotExists<SysDbContext>
    {
        protected override void Seed(SysDbContext context)
        {
            #region 初始化管理员
            var adminRole = new SysRole() { RoleName = "管理员", State = 1 };
            var adminUser = new SysUser() { LoginName = "admin", LoginPass = "21232f297a57a5a743894a0e4a801fc3", TrueName = "超级管理员", State = 1 };
            context.Set<SysRole>().Add(adminRole);
            context.Set<SysUser>().Add(adminUser); 
            #endregion

            #region 初始化菜单 

            var module = new SysModule() { ModuleCode = "001", ModuleName = "系统管理", State = 1 };
            context.Set<SysModule>().Add(module);
            module = new SysModule() { ModuleCode = "001001", ModuleName = "系统参数", ParentCode = "001", Url = "/system/home/SysSettingList", State = 1 };
            context.Set<SysModule>().Add(module);
            module = new SysModule() { ModuleCode = "001002", ModuleName = "菜单管理", ParentCode = "001", Url = "/system/home/SysModuleList", State = 1 };
            context.Set<SysModule>().Add(module);
            module = new SysModule() { ModuleCode = "001003", ModuleName = "字典管理", ParentCode = "001", Url = "/system/home/SysDictionaryList", State = 1 };
            context.Set<SysModule>().Add(module);
            module = new SysModule() { ModuleCode = "001004", ModuleName = "日志管理", ParentCode = "001", Url = "/system/home/SysLogList", State = 1 };
            context.Set<SysModule>().Add(module);
            module = new SysModule() { ModuleCode = "001005", ModuleName = "用户管理", ParentCode = "001", Url = "/system/home/SysUserList", State = 1 };
            context.Set<SysModule>().Add(module);
            module = new SysModule() { ModuleCode = "001006", ModuleName = "角色管理", ParentCode = "001", Url = "/system/home/SysRoleList", State = 1 };
            context.Set<SysModule>().Add(module);



            module = new SysModule() { ModuleCode = "004", ModuleName = "基础业务", State = 1 };
            context.Set<SysModule>().Add(module);
            module = new SysModule() { ModuleCode = "004001", ModuleName = "分 公 司", ParentCode = "004", Url = "/system/member/BusStationList", State = 1 };
            context.Set<SysModule>().Add(module);
            module = new SysModule() { ModuleCode = "004002", ModuleName = "部门管理", ParentCode = "004", Url = "/system/member/BusDepartmentList", State = 1 };
            context.Set<SysModule>().Add(module);
            module = new SysModule() { ModuleCode = "004003", ModuleName = "员工管理", ParentCode = "004", Url = "/system/member/BusEmployeeList", State = 1 };
            context.Set<SysModule>().Add(module);
            module = new SysModule() { ModuleCode = "004004", ModuleName = "会员管理", ParentCode = "004", Url = "/system/member/BusMemberList", State = 1 };
            context.Set<SysModule>().Add(module);
            module = new SysModule() { ModuleCode = "004005", ModuleName = "直播频道", ParentCode = "004", Url = "/system/member/BusChatRoomList", State = 1 };
            context.Set<SysModule>().Add(module);


            module = new SysModule() { ModuleCode = "005", ModuleName = "内容管理", State = 1 };
            context.Set<SysModule>().Add(module);
            module = new SysModule() { ModuleCode = "005001", ModuleName = "内容分类", ParentCode = "005", Url = "/system/member/BusArticleCategoryList", State = 1 };
            context.Set<SysModule>().Add(module);
            module = new SysModule() { ModuleCode = "005002", ModuleName = "文章列表", ParentCode = "005", Url = "/system/member/BusArticleList", State = 1 };
            context.Set<SysModule>().Add(module);
            module = new SysModule() { ModuleCode = "005003", ModuleName = "评论列表", ParentCode = "005", Url = "/system/member/BusArticleCommentList", State = 1 };
            context.Set<SysModule>().Add(module);
            module = new SysModule() { ModuleCode = "005004", ModuleName = "短信列表 ", ParentCode = "005", Url = "/system/member/BusSMSList", State = 1 };
            context.Set<SysModule>().Add(module);

            module = new SysModule() { ModuleCode = "006", ModuleName = "投资组合", State = 1 };
            context.Set<SysModule>().Add(module);
            module = new SysModule() { ModuleCode = "006001", ModuleName = "组合列表", ParentCode = "006", Url = "/system/member/BusPortfolioList", State = 1 };
            context.Set<SysModule>().Add(module);
            module = new SysModule() { ModuleCode = "006002", ModuleName = "调仓记录", ParentCode = "006", Url = "/system/member/BusPortfolioChangeList", State = 1 };
            context.Set<SysModule>().Add(module);
            module = new SysModule() { ModuleCode = "006003", ModuleName = "组合评论", ParentCode = "006", Url = "/system/member/BusPortfolioCommentList", State = 1 };
            context.Set<SysModule>().Add(module);
            #endregion

            #region 初始化职位信息

            var dic = new SysDictionary() {Code="Position",Name="职位列表"};
            context.Set<SysDictionary>().Add(dic);
            dic = new SysDictionary() { Code = "P001", Name = "部门经理", ParentCode = "Position" };
            context.Set<SysDictionary>().Add(dic);
            dic = new SysDictionary() { Code = "P002", Name = "部门副经理", ParentCode = "Position" };
            context.Set<SysDictionary>().Add(dic);
            dic = new SysDictionary() { Code = "P003", Name = "投资顾问", ParentCode = "Position" };
            context.Set<SysDictionary>().Add(dic);

            #endregion

            #region 初始化会员类型
            dic = new SysDictionary() { Code = "MemberType", Name = "会员类型" };
            context.Set<SysDictionary>().Add(dic);
            dic = new SysDictionary() { Code = "M001", Name = "公司员工", ParentCode = "MemberType" };
            context.Set<SysDictionary>().Add(dic);
            dic = new SysDictionary() { Code = "M002", Name = "普通会员", ParentCode = "MemberType" };
            context.Set<SysDictionary>().Add(dic);
            dic = new SysDictionary() { Code = "M003", Name = "VIP会员", ParentCode = "MemberType" };
            context.Set<SysDictionary>().Add(dic);
            dic = new SysDictionary() { Code = "M004", Name = "高级VIP会员", ParentCode = "MemberType" };
            context.Set<SysDictionary>().Add(dic);

            #endregion

            dic = new SysDictionary() { Code = "PortfolioType", Name = "组合类型" };
            context.Set<SysDictionary>().Add(dic);
            dic = new SysDictionary() { Code = "P1", Name = "签约组合", ParentCode = "PortfolioType" };
            context.Set<SysDictionary>().Add(dic);
            dic = new SysDictionary() { Code = "P2", Name = "非签约组合", ParentCode = "PortfolioType" };
            context.Set<SysDictionary>().Add(dic);


            context.SaveChanges();

            base.Seed(context);
        }
    }
}
