using System.IO;
using System.Reflection;
using GTJA.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GTJA.SystemManage.Command
{
    public class SysCommandManager
    {
        private static Dictionary<string, IWebCommand<SysCommandContext>> dic =
            new Dictionary<string, IWebCommand<SysCommandContext>>();

 
        public static IWebCommand<SysCommandContext> GetWebCommand(string cmd)
        {
            if (dic.ContainsKey(cmd))
            {
                return dic[cmd];
            }

            string file = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "bin", "GTJA.SystemManage.Command.dll");
            var typeName = string.Format("GTJA.SystemManage.Command.{0}Command", cmd);
            var ab = Assembly.LoadFrom(file);

            var command = (IWebCommand<SysCommandContext>)ab.CreateInstance(typeName);
            if (command != null)
            {
                dic.Add(cmd,command);
            }

            return command;
        }
    }
}
