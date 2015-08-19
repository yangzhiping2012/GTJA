using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTJA.SystemManage.AppModel.Common
{
    public class LoginUserModel
    {
        public LoginUserModel(long id, string userName, DateTime expiration, bool isAdmin)
        {
            ID = id;
            UserName = userName;
            Expiration = expiration;
            IsAdmin = isAdmin;
        }

        public bool IsAdmin { get; set; }
        public long ID { get; set; }
        public string UserName { get; set; }
        public DateTime Expiration { get; set; }
    }
}
