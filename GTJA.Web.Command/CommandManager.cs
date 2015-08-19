using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using GTJA.Common.Interfaces;

namespace GTJA.Web.Command
{
    public class CommandManager
    {
        private static Dictionary<string, IWebCommand<CommandContext>> dic =
            new Dictionary<string, IWebCommand<CommandContext>>();


        public static IWebCommand<CommandContext> GetWebCommand(string cmd)
        {
            if (dic.ContainsKey(cmd))
            {
                return dic[cmd];
            }

            string file = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "bin", "GTJA.Web.Command.dll");
            var typeName = string.Format("GTJA.Web.Command.{0}Command", cmd);
            var ab = Assembly.LoadFrom(file);

            var command = (IWebCommand<CommandContext>)ab.CreateInstance(typeName);
            if (command != null)
            {
                dic.Add(cmd, command);
            }

            return command;
        }
    }
}
