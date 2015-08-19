using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin;
using Owin;
using Microsoft.Owin.Cors;
using GTJA.ChatRoom.Server.Module;

[assembly: OwinStartupAttribute(typeof(GTJA.ChatRoom.Server.Startup))]
namespace GTJA.ChatRoom.Server
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            GlobalHost.HubPipeline.AddModule(new ErrorHandlingPipelineModule()); 
            app.UseCors(CorsOptions.AllowAll);//支持跨域
            var config = new HubConfiguration()
            {
                EnableJSONP = true
            };
            app.MapSignalR(config);
        }
    }
}