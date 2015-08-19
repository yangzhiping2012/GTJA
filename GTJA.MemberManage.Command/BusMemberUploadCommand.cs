using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using GTJA.Common.Interfaces;
using GTJA.MemberManage.DataImport;

namespace GTJA.MemberManage.Command
{
    public class BusMemberUploadCommand : IWebCommand<MemberCommandContext>
    {
        public object Execute(MemberCommandContext context)
        {
            var httpPostedFile = HttpContext.Current.Request.Files["file"];
            if (httpPostedFile != null && !string.IsNullOrEmpty(httpPostedFile.FileName))
            {
                string contentType = httpPostedFile.ContentType;
                string fileExtension = Path.GetExtension(httpPostedFile.FileName);
                if (!String.IsNullOrEmpty(fileExtension))
                    fileExtension = fileExtension.ToLowerInvariant();

                string fileName = "upload/file/" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + fileExtension;
                string path = Path.Combine(HttpContext.Current.Server.MapPath("/"), fileName.Replace("/", "\\"));
                httpPostedFile.SaveAs(path);

                var import = new MemberImport(path);
                if (!import.Save())
                {
                    return import.Error;
                }

                //删除文件
                File.Delete(path);

            }


            return true;
        }
    }
}
