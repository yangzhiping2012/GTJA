using GTJA.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;


namespace GTJA.MemberManage.Command
{
    public class MemberCommandManager
    {
        private static Dictionary<string, IWebCommand<MemberCommandContext>> dic =
            new Dictionary<string, IWebCommand<MemberCommandContext>>();


        public static IWebCommand<MemberCommandContext> GetWebCommand(string cmd)
        {
            if (dic.ContainsKey(cmd))
            {
                return dic[cmd];
            }

            string file = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "bin", "GTJA.MemberManage.Command.dll");
            var typeName = string.Format("GTJA.MemberManage.Command.{0}Command", cmd);
            var ab = Assembly.LoadFrom(file);

            var command = (IWebCommand<MemberCommandContext>)ab.CreateInstance(typeName);
            if (command != null)
            {
                dic.Add(cmd, command);
            }

            return command;
        }
    }
}
