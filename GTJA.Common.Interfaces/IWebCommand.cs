using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GTJA.Common.Interfaces
{
    public interface IWebCommand<T> where T : IWebCommandContext
    {
        object Execute(T context);
    }
}
